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
using System.Windows.Input;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Net.Sockets;
using Cursors = System.Windows.Input.Cursors;
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
        bool isReading = false;

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
            if (btnConnect.Text.ToLower() == "conectar")
            {
                try
                {
                    if (objReader != null)
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
        }



        private void InitializeReaderUriBox()
        {
            try
            {
                Mouse.SetCursor(Cursors.Wait);
                
                List<string> portNames = GetComPortNames();

                foreach (string portName in portNames)
                {
                    cmbReaderPort.Items.Add(portName);
                }

                
                if (portNames.Count > 0)
                {
                    cmbReaderPort.Text = portNames[0];
                }
                
                Mouse.SetCursor(Cursors.Arrow);
            }
            catch (Exception bonjEX)
            {
                Mouse.SetCursor(Cursors.Arrow);
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
                    TagReadData[] tagList = objReader.Read(100);

                    foreach (TagReadData tag in tagList)
                    {
                        System.Diagnostics.Debug.WriteLine("EPC: " + tag.EpcString);
                        System.Diagnostics.Debug.WriteLine("prd: " + JsonConvert.SerializeObject(tag.prd));
                        System.Diagnostics.Debug.WriteLine("Data: " + JsonConvert.SerializeObject(tag.Data));
                        System.Diagnostics.Debug.WriteLine("Tag: " + tag.Tag);
                        System.Diagnostics.Debug.WriteLine("Tag: " + tag.ReadCount);
                        lblEPC.Text = tag.EpcString;
                    }
                    //System.Diagnostics.Debug.WriteLine(tagList);
                    //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(tagList));
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err);
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


            if (!tagList.Exists(tag => tag.TagReadData.EpcString == e.TagReadData.EpcString))//Si el epc ya fue agregado a la lista
            {
                tagList.Add(e);
                resp = e;
                MyThread = new Thread(new ThreadStart(ThreadFunction));
                MyThread.Start();
            }
            else
            {
                TagReadDataEventArgs tag = tagList.Find( t => t.TagReadData.EpcString == e.TagReadData.EpcString);

                //Tengo que hacer el if para que se elimine el epc de la lista si ya pasaron mas de 5 segs.
                if (DateTime.Compare(tag.TagReadData.Time.AddSeconds(5), e.TagReadData.Time) < 0)
                {
                    int fnd = tagList.FindIndex(t => t.TagReadData.EpcString == e.TagReadData.EpcString);
                    tagList[fnd].TagReadData.ReadCount += e.TagReadData.ReadCount;


                    //tagList.Remove(tag);
                    tagList.Add(e);

                    resp = e;

                    MyThread = new Thread(new ThreadStart(ThreadFunction));
                    MyThread.Start();
                }
            }
            
            //Da error pq se manipula el dataGrid desde otro subproceso, no el que lo creo.
            //dtGridResults.Rows.Add(e.TagReadData.EpcString);

        }


        public delegate void deleAddDataGridRow();
        public deleAddDataGridRow addRow;



        //Funcion para agregar datos al dataGridView
        public void addDataGridRow()
        {
            System.Diagnostics.Debug.WriteLine("Cantidad 1 - " + tagdb.TagList[0].ReadCount);
            //System.Diagnostics.Debug.WriteLine("Cantidad 2 - " + tagdb.TagList[1].ReadCount);
            //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject("entra a dataGrid - " + JsonConvert.SerializeObject(tagdb.TagList[0])));

            long qtyReadedTags = tagdb.TagList.Count;

            int qtyRows = dtGridResults.RowCount;

            if (qtyRows < qtyReadedTags)
            {
                for (int i = qtyRows; i < qtyReadedTags; i++)
                {
                    Element rowElement = ElementDao.ReadElement(tagdb.TagList[i].EPC);
                    dtGridResults.Rows.Add(tagdb.TagList[i].EPC, rowElement.Name, rowElement.Description, tagdb.TagList[i].ReadCount);
                }
            }
            else if(qtyRows == qtyReadedTags)
            {

            }





            System.Diagnostics.Debug.WriteLine(qtyReadedTags + " - " + qtyRows);
            
            Element element = ElementDao.ReadElement(resp.TagReadData.EpcString);
            if (element.EPC != null)
            {
                int readCount = 0;

                

                readCount += resp.TagReadData.ReadCount;
                //System.Diagnostics.Debug.WriteLine( JsonConvert.SerializeObject( element ));
                dtGridResults.Rows.Add(element.EPC, element.Name, element.Description, tagdb.TotalTagCount);
                Reading reading = new Reading()
                {
                    ElementoId = element.Id,
                    //TimeStamp = GetTimestamp(DateTime.Now)
                    TimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()
                };
                ReadingsDao.CreateReading(reading);
                //resp = null;
            }
            else
            {
                dtGridResults.Rows.Add(resp.TagReadData.EpcString, "", "", resp.TagReadData.ReadCount);
                //resp = null;
            }
        }


        private void ThreadFunction()
        {
            MyThreadClass myThreadClassObject = new MyThreadClass(this);
            myThreadClassObject.Run();
        }


        //Para convertir en TimeStamp.
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
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
                writeTagForm = new WriteTagForm(objReader);
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
                enrollForm = new EnrollForm(objReader);
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
                elementForm = new ElementsForm(objReader);
                elementForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO'.");
            }
        }









            ///// <summary>
            ///// Merge new tag read with existing one
            ///// </summary>
            ///// <param name="data">New tag read</param>
            //public void Update(TagReadData mergeData)
            //{
            //    mergeData.ReadCount += ReadCount;
            //    TimeSpan timediff = mergeData.Time.ToUniversalTime() - this.TimeStamp.ToUniversalTime();
            //    // Update only the read counts and not overwriting the tag
            //    // read data of the existing tag in tag database when we 
            //    // receive tags in incorrect order.
            //    if (0 <= timediff.TotalMilliseconds)
            //    {
            //        RawRead = mergeData;
            //    }
            //    else
            //    {
            //        RawRead.ReadCount = mergeData.ReadCount;
            //    }
            //    OnPropertyChanged(null);
            //}
        

        private void btnEditElement_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                EditElementForm editElementForm = new EditElementForm(objReader);
                editElementForm.Show();
            }
            else
            {
                MessageBox.Show("Necesita estar 'CONECTADO'.");
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
