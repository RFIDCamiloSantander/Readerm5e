using System;
using System.Windows;
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

namespace Readerm5e
{
    public partial class MainForm : Form
    {

        WriteTagForm writeTagForm;

        EnrollForm enrollForm;

        ReadingsForm readingsForm;

        //Variable para poder delegar funciones
        Thread MyThread;

        //Lista para almacenar los Tags leidos y que no se repitan
        List<TagReadDataEventArgs> tagList = new List<TagReadDataEventArgs>();

        //Variable para almacenar temporalmente la respuesta de tag leído
        TagReadDataEventArgs resp = null;

        //Variable en donde se almacenara el objeto Lector
        Reader objReader = null;

        // Boolean variable to check Tcp Client connect or not
        bool clientConnected = false;

        //Booleano para saber si se encuentra leyendo el lector.
        bool isReading = false;

        //Socket for tcp streaming
        List<Socket> tagStreamSock = new List<Socket>();

        //boolean variable to check Http post is enabled or not
        bool isHttpPostServiceEnabled = false;

        /// <summary>
        /// Define a variable for selection criteria
        /// </summary>
        TagFilter selectionOnEPC = null;


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
                    }
                    else
                    {
                        objReader.Destroy();
                        objReader = null;
                        btnConnect.Text = "Conectar";
                        lblEstado.Text = "Desconectado";
                        lblEstado.ForeColor = Color.Red;
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
                System.Diagnostics.Debug.WriteLine(tagList);
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(tagList));
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err);
                throw;
            }
        }

        private void btnStartReading_Click(object sender, EventArgs e)
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
                    objReader.StopReading();
                    btnStartReading.Text = "Iniciar Lecturas";

                    lblEstado.Text = "Conectado";
                    lblEstado.ForeColor = Color.Blue;

                    isReading = false;
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err);
                    throw;
                }
            }
        }



        /// <summary>
        /// Function that processes the Tag Data produced by StartReading();
        /// </summary>
        /// <param name="read"></param>
        public void PrintTagRead(Object sender, TagReadDataEventArgs e)
        {

            addRow = new deleAddDataGridRow(addDataGridRow);


            if (!tagList.Exists(tag => tag.TagReadData.EpcString == e.TagReadData.EpcString))
            {
                //Tengo que hacer el if para que se elimine el epc de la lista si ya pasaron mas de 5 segs.
                if (true)
                {

                }


                tagList.Add(e);
                resp = e;
                MyThread = new Thread(new ThreadStart(ThreadFunction));
                MyThread.Start();
                System.Diagnostics.Debug.WriteLine("Dentro del Thread");
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject( tagList));
            }
            
            //Da error pq se manipula el dataGrid desde otro subproceso, no el que lo creo.
            //dtGridResults.Rows.Add(e.TagReadData.EpcString);

        }


        public delegate void deleAddDataGridRow();
        public deleAddDataGridRow addRow;


        public void addDataGridRow()
        {
            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(resp));
            Element element = ElementDao.ReadElement(resp.TagReadData.EpcString);
            if (element.EPC != null)
            {
                System.Diagnostics.Debug.WriteLine( JsonConvert.SerializeObject( element ));
                dtGridResults.Rows.Add(element.EPC, element.Name, element.Description);
                Reading reading = new Reading()
                {
                    ElementoId = element.Id,
                    TimeStamp = GetTimestamp(DateTime.Now)
                };
                ReadingsDao.CreateReading(reading);
            }
            else
            {
                dtGridResults.Rows.Add(resp.TagReadData.EpcString);
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
            writeTagForm = new WriteTagForm(objReader);
            writeTagForm.Show();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            enrollForm = new EnrollForm(objReader);
            enrollForm.Show();
        }

        private void btnReadings_Click(object sender, EventArgs e)
        {
            readingsForm = new ReadingsForm();
            readingsForm.Show();
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
