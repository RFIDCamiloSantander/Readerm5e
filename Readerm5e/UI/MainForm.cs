using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThingMagic;
using Newtonsoft.Json;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Sockets;
using Readerm5e.UI;
using Readerm5e.DAOs;
using Readerm5e.Models;
using Readerm5e.BL;

namespace Readerm5e
{
    public partial class MainForm : Form
    {

        WriteTagForm writeTagForm;

        EnrollForm enrollForm;

        ReadingsForm readingsForm;

        ElementsForm elementForm;

        //Variable para poder delegar funciones
        Thread MyThread;

        //Lista para almacenar los Tags leidos y que no se repitan
        List<TagReadDataEventArgs> tagList = new List<TagReadDataEventArgs>();

        //Variable para almacenar temporalmente la respuesta de tag leído
        TagReadDataEventArgs resp = null;

        //Variable en donde se almacenara el objeto Lector
        Reader objReader = null;

        // Boolean variable to check Tcp Client connect or not
        //bool clientConnected = false;

        //Booleano para saber si se encuentra conectado al lector.
        bool isConnected = false;

        //Booleano para saber si se encuentra leyendo el lector.
        static bool isReading = false;

        //Booleano para saber si esta activa la auto escritura
        bool isAutoWriting = false;

        //Booleano para almacenar el ultimo epc escrito
        TagReadData lastWrote;

        //Socket for tcp streaming
        List<Socket> tagStreamSock = new List<Socket>();


        // Tag database object
        TagDatabase tagdb = new TagDatabase();

        //boolean variable to check Http post is enabled or not
        //bool isHttpPostServiceEnabled = false;

        /// <summary>
        /// Define a variable for selection criteria
        /// </summary>
        //TagFilter selectionOnEPC = null;


        public MainForm()
        {
            InitializeComponent();
            InitializeReaderUriBox();
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (btnConnect.Text.ToLower() == "conectar") //Revisa el estado del boton conectar.
            {
                try
                {
                    if (objReader != null) //Revisa que no haya un Reader creado.
                    {
                        objReader.Destroy();
                        objReader = null;
                        //ConfigureAntennaBoxes(null);
                        //ConfigureLogicalAntennaBoxes(null);
                        //ConfigureProtocols(null);
                    }

                    string readerUri = cmbReaderPort.Text;

                    MatchCollection mc = Regex.Matches(readerUri, @"(?<=\().+?(?=\))");
                    foreach (Match m in mc)
                    {
                        if (!string.IsNullOrWhiteSpace(m.ToString()))
                            readerUri = m.ToString();
                    }

                    objReader = Reader.Create(string.Concat("tmr:///", readerUri));
                    //objReader = Reader.Create("eapi:///com5");
                
                    //Se inicia la conección
                    objReader.Connect();
                    isConnected = true;
                    

                    //Seteamos la region para el lector,
                    //es necesario setear la region para poder iniciar lecturas
                    objReader.ParamSet("/reader/region/id", Reader.Region.NA);

                    objReader.ParamSet("/reader/radio/readPower", trackBarReadPower.Value * 100);


                    System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(readerUri));
                    System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(objReader));
                    lblEstado.Text = "Conectado";
                    lblEstado.ForeColor = Color.Blue;
                    btnConnect.Text = "Desconectar";
                    //objReader.StartReading();
                
                }
                catch (Exception ex)
                {
                    lblEstado.Text = "Desconectado";
                    lblEstado.ForeColor = Color.Red;
                    System.Diagnostics.Debug.WriteLine(ex);
                    isConnected = false;
                    throw;
                }
            }
            else if(btnConnect.Text.ToLower() == "desconectar")
            {
                try
                {
                    if (isReading)
                    {
                        objReader.StopReading();
                        objReader.Destroy();
                        objReader = null;
                        btnConnect.Text = "Conectar";
                        lblEstado.Text = "Desconectado";
                        lblEstado.ForeColor = Color.Red;

                        btnStartReading.Text = "Iniciar Lecturas";

                        isReading = false;
                        isConnected = false;
                    }
                    else
                    {
                        objReader.Destroy();
                        objReader = null;
                        btnConnect.Text = "Conectar";
                        lblEstado.Text = "Desconectado";
                        lblEstado.ForeColor = Color.Red;
                        isConnected = false;
                    }

                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err);
                    throw;

                }
            }
            Cursor = Cursors.Arrow;
        }


        private void InitializeReaderUriBox()
        {
            try
            {
                //Mouse.SetCursor(Cursors.Wait);

                Cursor = Cursors.WaitCursor;
                
                List<string> portNames = GetComPortNames();

                foreach (string portName in portNames)
                {
                    cmbReaderPort.Items.Add(portName);
                }

                
                if (portNames.Count > 0)
                {
                    cmbReaderPort.Text = portNames[0];
                }
                
                //Mouse.SetCursor(Cursors.Arrow);

                Cursor = Cursors.Arrow;
            }
            catch (Exception bonjEX)
            {
                //Mouse.SetCursor(Cursors.Arrow);
                Cursor = Cursors.Arrow;
                throw bonjEX;
            }
        }


        private List<string> GetComPortNames()
        {
            List<string> portNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0"))
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if ((queryObj != null) && (queryObj["Name"] != null))
                    {
                        if (queryObj["Name"].ToString().Contains("(COM"))
                            portNames.Add(queryObj["Name"].ToString());
                    }
                }
            }
            return portNames;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

            if (isConnected)
            {
                try
                {

                    TagReadData[] tagList;
                    if (isReading) //Revisa si esta leyendo
                    {
                        objReader.StopReading();
                        tagList = objReader.Read(100);
                        objReader.StartReading();
                    }
                    else
                    {
                        tagList = objReader.Read(100);
                    }

                    if (tagList.Length == 0)
                    {
                        MessageBox.Show("No se leyeron Tags.", "Error");
                    }

                    if (tagList.Length > 1)
                    {
                        MessageBox.Show("Se ha leído mas de un Tag.", "Error");
                    }

                    if (tagList.Length == 1)
                    {
                        foreach (TagReadData tag in tagList)
                        {
                            lblEPC.Text = tag.EpcString;
                        }
                    }
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err);
                    MessageBox.Show(err.Message.ToString());
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO' para leer y/o escribir.");
            }

        }

        private void btnStartReading_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (btnStartReading.Text.ToLower() == "iniciar lecturas")
                {
                    try
                    {   
                        //Seteamos la region para el lector,
                        //es necesario setear la region para poder iniciar lecturas
                        //objReader.ParamSet("/reader/region/id", Reader.Region.NA);

                        objReader.TagRead += PrintTagRead;
                        //objReader.TagRead += autoWrite;

                        objReader.StartReading();
                        btnStartReading.Text = "Detener Lecturas";

                        lblEstado.Text = "Leyendo";
                        lblEstado.ForeColor = Color.Green;

                        //Cambiamos el estado de isReading
                        isReading = true;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                        throw;
                    }
                }
                else if (btnStartReading.Text.ToLower() == "detener lecturas")
                {
                    try
                    {
                        objReader.TagRead -= PrintTagRead;
                        objReader.StopReading();
                        btnStartReading.Text = "Iniciar Lecturas";

                        lblEstado.Text = "Conectado";
                        lblEstado.ForeColor = Color.Blue;

                        isReading = false;
                        tagList.Clear();
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                        throw;
                    }
                }

            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO' para leer y/o escribir.");
            }
        }



        /// <summary>
        /// Function that processes the Tag Data produced by StartReading();
        /// </summary>
        /// <param name="read"></param>
        public void PrintTagRead(Object sender, TagReadDataEventArgs e)
        {
            tagdb.Add(e.TagReadData);
            addRow = new deleAddDataGridRow(addDataGridRow);

            MyThread = new Thread(new ThreadStart(ThreadFunction));
            MyThread.Start();
            
            //Da error pq se manipula el dataGrid desde otro subproceso, no el que lo creo.
            //dtGridResults.Rows.Add(e.TagReadData.EpcString);

        }


        public delegate void deleAddDataGridRow();
        public deleAddDataGridRow addRow;



        //Funcion para agregar datos al dataGridView
        public void addDataGridRow()
        {

            long qtyReadedTags = tagdb.TagList.Count; //Cantidad de Tags unicos leidos.

            int qtyRows = dtGridResults.RowCount; //Cantidad de filas en el DataGrid.

            System.Diagnostics.Debug.WriteLine(qtyReadedTags + " - " + qtyRows);

            if (qtyRows < qtyReadedTags) //Revisa si hay menos filas que tags unicos.
            {
                for (int i = qtyRows; i < qtyReadedTags; i++) //For para agregar las filas faltantes al DataGrid
                {
                    Element rowElement = ElementDao.ReadElement(tagdb.TagList[i].EPC);
                    dtGridResults.Rows.Add(tagdb.TagList[i].EPC, rowElement.Name, tagdb.TagList[i].ReadCount, tagdb.TagList[i].TimeStamp, rowElement.Description);
                    if (rowElement.Id != 0) //Crea lectura si el epc leido esta asociado.
                    {
                        CreateRead(rowElement.Id);
                    }
                }
            }
            else if(qtyRows == qtyReadedTags)
            {
                for (int i = 0; i < qtyRows; i++)
                {
                    System.Diagnostics.Debug.WriteLine(tagdb.TagList[i].EPC);
                    Element rowElement = ElementDao.ReadElement(tagdb.TagList[i].EPC);



                    if (rowElement.Id != 0)
                    {
                        DateTime lastSeen = (DateTime) dtGridResults.Rows[i].Cells[3].Value;

                        System.Diagnostics.Debug.WriteLine("lastseen: " + lastSeen + " - Id: " + rowElement.Id);
                        System.Diagnostics.Debug.WriteLine("lastseenGrid: " + lastSeen + " - LastSeenTagDB: " + tagdb.TagList[i].TimeStamp);

                        if (lastSeen.AddSeconds(5) < tagdb.TagList[i].TimeStamp)
                        {
                            CreateRead(rowElement.Id);
                        }
                    }

                    dtGridResults.Rows[i].Cells[2].Value = tagdb.TagList[i].ReadCount;
                    dtGridResults.Rows[i].Cells[3].Value = tagdb.TagList[i].TimeStamp;
                }
            }
        }



        private void CreateRead(int pId)
        {

            Reading reading = new Reading()
            {
                ElementoId = pId,
                TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
            };

            ReadingsDao.CreateReading(reading);

        }


        private void ThreadFunction()
        {
            MyThreadClass myThreadClassObject = new MyThreadClass(this);
            myThreadClassObject.Run();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbReaderPort.Items.Clear();
            InitializeReaderUriBox();
        }


        private void btnReWrite_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                writeTagForm = new WriteTagForm(objReader, isReading);
                writeTagForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO' para leer y/o escribir.");
            }
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (isReading)
                {

                }
                enrollForm = new EnrollForm(objReader, isReading);
                enrollForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO' para leer y/o escribir.");
            }
        }

        private void btnReadings_Click(object sender, EventArgs e)
        {
            readingsForm = new ReadingsForm();
            readingsForm.Show();
        }

        private void btnLimpiarTabla_Click(object sender, EventArgs e)
        {
            dtGridResults.Rows.Clear();
        }

        private void btnElementos_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                elementForm = new ElementsForm(objReader, isReading);
                elementForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO'.");
            }
        }

        

        private void btnEditElement_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                EditElementForm editElementForm = new EditElementForm(objReader, isReading);
                editElementForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO'.");
            }
            
        }

        private void btnAutoWrite_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (lblAutoWriteState.Text == "Desactivado")
                {
                    if (isReading)
                    {
                        lblAutoWriteState.Text = "Activado";
                        lblAutoWriteState.ForeColor = Color.Blue;
                        objReader.TagRead += autoWrite;
                    }
                    else
                    {
                        lblAutoWriteState.Text = "Activado";
                        lblAutoWriteState.ForeColor = Color.Blue;
                        objReader.TagRead += autoWrite;
                        objReader.StartReading();
                    }
                }
                else
                {
                    if (isReading)
                    {
                        objReader.TagRead -= autoWrite;
                        lblAutoWriteState.Text = "Desactivado";
                        lblAutoWriteState.ForeColor = Color.Red;
                    }
                    else
                    {
                        objReader.TagRead -= autoWrite;
                        objReader.StopReading();
                        lblAutoWriteState.Text = "Desactivado";
                        lblAutoWriteState.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO'.");
            }
        }

        private void autoWrite(Object sender, TagReadDataEventArgs e)
        {
            //SendKeys.SendWait("holiwi");

            if (lastWrote == null)
            {
                lastWrote = e.TagReadData;
                //System.Diagnostics.Debug.WriteLine("lastWrote: " + lastWrote.Time + "Evento: " + e.TagReadData.Time);
                SendKeys.SendWait(e.TagReadData.EpcString + "{ENTER}");
            }
            else
            {
                if (lastWrote.EpcString == e.TagReadData.EpcString)
                {
                    if (lastWrote.Time.AddSeconds(2) <= e.TagReadData.Time)
                    {
                        lastWrote = e.TagReadData;
                        SendKeys.SendWait(e.TagReadData.EpcString + "{ENTER}");
                        System.Diagnostics.Debug.WriteLine("lastWrote: " + lastWrote.Time + "Evento: " + e.TagReadData.Time);
                    }

                }
                else
                {
                    SendKeys.SendWait(e.TagReadData.EpcString + "{ENTER}");
                    lastWrote = e.TagReadData;
                }
            }
        }


        private void trackBarReadPower_Scroll(object sender, EventArgs e)
        {
            if (objReader != null)
            {
                objReader.ParamSet("/reader/radio/readPower", trackBarReadPower.Value * 100);
            }
        }
    }





    public class MyThreadClass
    {
        MainForm myFormControl1;

        public MyThreadClass(MainForm myForm)
        {
            myFormControl1 = myForm;
        }
        

        public void Run()
        {
            myFormControl1.Invoke(myFormControl1.addRow);
        }

    }
}
