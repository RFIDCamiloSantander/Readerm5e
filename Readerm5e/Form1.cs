using System.Windows.Shell;
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
using Application = System.Windows.Application;

namespace Readerm5e
{
    public partial class Form1 : Form
    {
        public delegate void PrintTagReadThread();

        PrintTagReadThread myDelegate;

        

        BindingSource bindingSource = new BindingSource();

        List<string> tagList = new List<string>();

        Reader objReader = null;

        // Boolean variable to check Tcp Client connect or not
        bool clientConnected = false;

        //Socket for tcp streaming
        List<Socket> tagStreamSock = new List<Socket>();

        //boolean variable to check Http post is enabled or not
        bool isHttpPostServiceEnabled = false;

        /// <summary>
        /// Define a variable for selection criteria
        /// </summary>
        TagFilter selectionOnEPC = null;


        public Form1()
        {
            InitializeComponent();
            InitializeReaderUriBox();
        }




        private void btnConnect_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Click Made");

            try
            {
                if (objReader != null)
                {
                    System.Diagnostics.Debug.WriteLine("Entra al IF");

                    objReader.Destroy();
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
                objReader.ParamSet("/reader/region/id", Reader.Region.NA);
                objReader.Connect();
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(readerUri));
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(objReader));
                lblEstado.Text = "Conectado";
                lblEstado.ForeColor = Color.Blue;
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
            catch (Exception)
            {

                throw;
            }
        }

        private void btnStartReading_Click(object sender, EventArgs e)
        {
           
                //dtGridResults.Rows.Add("Holiwi");
                try
                {

                    objReader.ParamSet("/reader/region/id", Reader.Region.NA);

                    objReader.TagRead += PrintTagRead;

                    objReader.StartReading();
                    //bindingSource.DataSource = tagList;
                    //dtGridResults.DataSource = bindingSource;
                }
                catch (Exception)
                {
                    throw;
                }


        }



        /// <summary>
        /// Function that processes the Tag Data produced by StartReading();
        /// </summary>
        /// <param name="read"></param>
        public void PrintTagRead(Object sender, TagReadDataEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new ThreadStart(delegate ()
            {
                //dtGridResults.Rows.Clear();
                //dtGridResults.Columns.Clear();
                System.Diagnostics.Debug.WriteLine("Dentro del Thread");

                tagList.Add(e.TagReadData.EpcString);
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject( tagList));
                dtGridResults.Rows.Add("holiwi");
            }));
            


            //Da error pq se manipula el dataGrid desde otro subproceso, no el que lo creo.
            //dtGridResults.Rows.Add(e.TagReadData.EpcString);


            //Dispatcher.BeginInvoke(new ThreadStart(delegate ()
            //{
            //    if (clientConnected)
            //    {
            //        foreach (Socket tempSocket in tagStreamSock)
            //        {
            //            if (tempSocket.Connected)
            //                PrintTagReads(e, tempSocket);
            //        }
            //    }
            //    else if (!isHttpPostServiceEnabled)
            //    {
            //        broadcastOFF();
            //    }
            //}));

        }




        ///// <summary>
        ///// Function that processes the Tag Data produced by StartReading();
        ///// </summary>
        ///// <param name="read"></param>
        //void PrintTagRead(Object sender, TagReadDataEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(new ThreadStart(delegate ()
        //    {
        //        if (clientConnected)
        //        {
        //            foreach (Socket tempSocket in tagStreamSock)
        //            {
        //                if (tempSocket.Connected)
        //                    PrintTagReads(e, tempSocket);
        //            }
        //        }
        //        else if (!isHttpPostServiceEnabled)
        //        {
        //            broadcastOFF();
        //        }
        //    }));
        //    Dispatcher.BeginInvoke(new ThreadStart(delegate ()
        //    {
        //        // Enable the read/stop-reading button when URA is able to connect 
        //        // to the reader or URA is able to get the tags.
        //        btnRead.IsEnabled = true;
        //        tagdb.Add(e.TagReadData);
        //        //If warning is there, remove it
        //        if (null != lblWarning.Text)
        //        {
        //            string temperature = lblReaderTemperature.Content.ToString().TrimEnd('C', '°');
        //            if (lblWarning.Text.ToString() != "")
        //            {
        //                if (int.Parse(temperature) < 85)
        //                {
        //                    lblWarning.Dispatcher.BeginInvoke(new ThreadStart(delegate ()
        //                    {
        //                        GUIturnoffWarning();
        //                    }));
        //                }
        //            }
        //        }
        //    }));
        //    Dispatcher.BeginInvoke(new ThreadStart(delegate ()
        //    {
        //        txtTotalTagReads.Content = tagdb.TotalTagCount.ToString();
        //        totalUniqueTagsReadTextBox.Content = tagdb.UniqueTagCount.ToString();
        //    }
        //    ));
        //}



        ///// Sending tags to TCP server Through Async read
        ///// </summary>
        ///// <param name="e"></param>
        //void PrintTagReads(TagReadDataEventArgs e, Socket tempSocket)
        //{
        //    string data = StreamDataFormat(e.TagReadData);
        //    Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(delegate ()
        //    {
        //        byte[] ba = Encoding.ASCII.GetBytes(data);
        //        var SentBytesLen = 0;
        //        while (SentBytesLen < ba.Length)
        //        {
        //            try
        //            {
        //                SentBytesLen += tempSocket.Send(ba.Skip(SentBytesLen).ToArray());
        //            }
        //            catch (SocketException ex)
        //            {
        //                SentBytesLen = ba.Length;
        //                DisplayMessageOnStatusBar(ex.Message, Brushes.Red);
        //            }
        //        }
        //    }));
        //}


        ///// <summary>
        ///// Disables the broadcast status. 
        ///// </summary
        //private void broadcastOFF()
        //{
        //    Dispatcher.BeginInvoke(new ThreadStart(delegate ()
        //    {
        //        imgTcpStreamStatus.Source = new BitmapImage(new Uri(@"..\Icons\broadcast-icon-off.png",
        //                                    UriKind.RelativeOrAbsolute));
        //    }));
        //}
    }
}
