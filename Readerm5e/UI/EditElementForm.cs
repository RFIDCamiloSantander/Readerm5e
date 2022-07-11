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
using System.Windows.Forms;
using ThingMagic;
using Newtonsoft.Json;

namespace Readerm5e.UI
{
    public partial class EditElementForm : Form
    {
        Reader objReader;

        string orEpc;

        
        //Abriendo el form desde la lista de elementos
        public EditElementForm(Reader pObjReader, DataGridViewRow pRow)
        {
            orEpc = pRow.Cells[0].Value.ToString();
            objReader = pObjReader;
            InitializeComponent();
            txtEpc.Text = pRow.Cells[0].Value.ToString();
            txtName.Text = pRow.Cells[1].Value.ToString();
            txtDescription.Text = pRow.Cells[2].Value.ToString();
            btnSearchElement.Hide();
        }


        //Abriendo el form desde el btnEditElement en mainForm.
        public EditElementForm(Reader pObjReader)
        {
            objReader = pObjReader;
            InitializeComponent();
        }

        private void btnLeerEpc_Click(object sender, EventArgs e)
        {
            try
            {
                TagReadData[] tagList = objReader.Read(100);

                foreach (TagReadData tag in tagList)
                {
                    txtEpc.Text = tag.EpcString;
                }
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err);
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Element checkElement = ElementDao.ReadElement(txtEpc.Text);

            System.Diagnostics.Debug.WriteLine(checkElement.EPC + " - " + orEpc);


            if (txtEpc.Text == orEpc) //Verifica si se esta cambiando el EPC.
            {
                saveElement();
            }
            else
            {
                Element element = ElementDao.ReadElement(txtEpc.Text); //Busca elementos con el EPC nuevo.

                if (element.Id == 0) //Revisa si se encontro algun elemento con el EPC nuevo.
                {
                    saveElement();
                }
                else
                {
                    MessageBox.Show("Este EPC ya está asociado a un elemento.");
                }
            }
        }



        public void saveElement()
        {
            try
            {
                Element element = ElementDao.ReadElement(orEpc);

                element.EPC = txtEpc.Text;
                element.Name = txtName.Text;
                element.Description = txtDescription.Text;

                int rsp = ElementDao.UpdateElement(element);

                if (rsp > 0)
                {
                    MessageBox.Show("Elemento editado con Exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo problemas al editar el elemento");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                System.Diagnostics.Debug.WriteLine(err);
                throw;
            }
        }

        private void btnSearchElement_Click(object sender, EventArgs e)
        {
            TagReadData[] tags = objReader.Read(100);

            if (tags.Length > 1)
            {
                MessageBox.Show("Se ha leído mas de 1 EPC/TAG.");
            }
            else if(tags.Length == 0)
            {
                MessageBox.Show("No se ha leído el EPC/TAG.");
            }
            else
            {
                Element element = ElementDao.ReadElement(tags[0].EpcString);

                txtEpc.Text = element.EPC;
                txtName.Text = element.Name;
                txtDescription.Text = element.Description;

                orEpc = element.EPC;
            }
        }
    }
}