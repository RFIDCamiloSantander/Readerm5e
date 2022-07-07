using Readerm5e.Models;
using Readerm5e.DAOs;
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
    public partial class EnrollForm : Form
    {
        Reader objReader;
        public EnrollForm(Reader pObjReader)
        {
            objReader = pObjReader;
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            TagReadData[] tagList = objReader.Read(100);

            foreach (TagReadData tag in tagList)
            {
                txtEpc.Text = tag.EpcString;
            }
        }

        private void btnEnrollSave_Click(object sender, EventArgs e)
        {
            Element element = new Element()
            {
                EPC = txtEpc.Text,
                Name = txtName.Text,
                Description = txtDescription.Text,
                CreationDate = Convert.ToString(DateTime.Now.ToString()),
                Status = null,
            };

            int rsp = ElementDao.CreateElement(element);

            if (rsp > 0)
            {
                MessageBox.Show("Elemento agregado con exito.");
            }
            else
            {
                MessageBox.Show("Hubo problemas al agregar el elemento.");
            }
        }
    }
}
