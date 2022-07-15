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
using Readerm5e.Validators;
using FluentValidation.Results;

namespace Readerm5e.UI
{
    public partial class EnrollForm : Form
    {
        //El lector
        Reader objReader;

        //Variable para controlar el estado de si esta leyendo.
        bool isReading;
        public EnrollForm(Reader pObjReader, bool pIsReading)
        {
            isReading = pIsReading;
            objReader = pObjReader;
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
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
                txtEpc.Text = tag.EpcString;
            }
        }

        private void btnEnrollSave_Click(object sender, EventArgs e)
        {
            Element element = new Element()
            {
                EPC = txtEpc.Text.ToLower(),
                Name = txtName.Text.ToLower(),
                Description = txtDescription.Text.ToLower(),
                CreationDate = Convert.ToString(DateTime.Now.ToString()),
                Status = null,
            };

            ElementValidator validator = new ElementValidator();

            ValidationResult result = validator.Validate(element);

            if (result.IsValid)
            {
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
            else
            {
                MessageBox.Show(result.Errors[0].ToString());
                
            }

        }
    }
}
