using Readerm5e.DAOs;
using Readerm5e.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows;
using System.Windows.Forms;
using ThingMagic;
using MessageBox = System.Windows.MessageBox;

namespace Readerm5e.UI
{
    public partial class WriteTagForm : Form
    {
        //Variable para recibir el Reader enviado desde el MainForm
        Reader objReader;
        bool isReading;

        public WriteTagForm(Reader pObjReader, bool pIsReading)
        {
            objReader = pObjReader;
            isReading = pIsReading;
            InitializeComponent();
        }


        private void btnReadEpc_Click(object sender, EventArgs e)
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

            foreach (TagReadData tag in tagList)
            {
                txtReadEpc.Text = tag.EpcString;
            }
        }

        private void btnWriteEpc_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(validateHexEpc(txtWriteEpc.Text.Trim()));


            //Valida el largo del EPC, que no tenga espacios en blanco y que sea hex.
            if (((txtWriteEpc.Text.Length % 4) != 0) || txtWriteEpc.Text.Contains(" ") || !validateHexEpc(txtWriteEpc.Text.Trim()))
            {
                MessageBox.Show("Por favor ingrese un EPC valido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Element element = ElementDao.ReadElement(txtWriteEpc.Text);

                if (element.Id == 0)
                {
                    try
                    {
                        objReader.WriteTag(null, new TagData(txtWriteEpc.Text));

                        Thread.Sleep(100);

                        TagReadData[] tag = null;

                        while (tag == null || tag.Length == 0)
                        {
                            tag = objReader.Read(100);
                        }

                        if (tag.Length > 1)
                        {
                            MessageBox.Show("Se esta leyendo mas de un tag.");
                        }

                        if (tag[0].EpcString == txtWriteEpc.Text)
                        {
                            MessageBox.Show("El tag ha sido escrito correctamente.");
                        }

                        if (tag[0].EpcString != txtWriteEpc.Text)
                        {
                            MessageBox.Show("Hubo problemas en la escritura del tag.");
                        }

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        System.Diagnostics.Debug.WriteLine(err.Message);
                        //throw;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("El EPC ya esta asociado a un elemento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private bool validateHexEpc(string Epc)
        {
            bool isHex = true;
            foreach (char c in Epc)
            {
                isHex = ((c >= '0' && c <= '9') ||
                 (c >= 'a' && c <= 'f') ||
                 (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return isHex;
        }
    }
}
