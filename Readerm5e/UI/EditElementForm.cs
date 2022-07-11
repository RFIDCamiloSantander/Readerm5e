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

namespace Readerm5e.UI
{
    public partial class EditElementForm : Form
    {
        Reader objReader;

        DataGridViewRow row;
        public EditElementForm(Reader pObjReader, DataGridViewRow pRow)
        {
            row = pRow;
            objReader = pObjReader;
            InitializeComponent();
            txtEpc.Text = pRow.Cells[0].Value.ToString();
            txtName.Text = pRow.Cells[1].Value.ToString();
            txtDescription.Text = pRow.Cells[2].Value.ToString();
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
            Element element = ElementDao.ReadElement(row.Cells[0].Value.ToString());
            if (element != null)
            {
                try
                {
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
        }
    }
}