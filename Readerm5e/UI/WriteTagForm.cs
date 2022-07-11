using Readerm5e.DAOs;
using Readerm5e.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using ThingMagic;

namespace Readerm5e.UI
{
    public partial class WriteTagForm : Form
    {
        //Variable para recibir el Reader enviado desde el MainForm
        Reader objReader;

        public WriteTagForm(Reader pObjReader)
        {
            objReader = pObjReader;
            InitializeComponent();
        }


        private void btnReadEpc_Click(object sender, EventArgs e)
        {
            TagReadData[] tagList = objReader.Read(100);

            foreach (TagReadData tag in tagList)
            {
                txtReadEpc.Text = tag.EpcString;
            }
        }

        private void btnWriteEpc_Click(object sender, EventArgs e)
        {
            if (((txtWriteEpc.Text.Length % 4) != 0) || txtWriteEpc.Text.Contains(" ")) //Valida el largo del EPC y que no tenga espacios en blanco.
            {
                System.Windows.MessageBox.Show("Por favor ingrese un EPC valido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Element element = ElementDao.ReadElement(txtWriteEpc.Text);

                if (element.Id == 0)
                {
                    objReader.WriteTag(null, new TagData(txtWriteEpc.Text));
                }
                else
                {
                    System.Windows.MessageBox.Show("El EPC ya esta asociado a un elemento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
