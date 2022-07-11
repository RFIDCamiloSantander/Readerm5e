﻿using Readerm5e.DAOs;
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
    public partial class ElementsForm : Form
    {
        List<Element> elementList;

        EditElementForm editElementForm;

        Reader objReader;

        public ElementsForm(Reader pObjReader)
        {
            objReader = pObjReader;
            InitializeComponent();
            getElements();
            populateDataGridElement();
        }

        public void getElements()
        {
            elementList = ElementDao.ReadAllElements();
        }

        public void populateDataGridElement()
        {
            foreach (Element element in elementList)
            {
                System.Diagnostics.Debug.WriteLine("entre al foreach");
                dtGridElements.Rows.Add(element.EPC, element.Name, element.Description);
            }
        }

        private void dtGridElements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //System.Diagnostics.Debug.WriteLine("rowClickadc");
            //System.Diagnostics.Debug.WriteLine(e.ColumnIndex.ToString());
            //System.Diagnostics.Debug.WriteLine(dtGridElements.Rows[e.RowIndex].Cells[2].Value.ToString() );


            DataGridViewRow row = dtGridElements.Rows[e.RowIndex];
            
            
            editElementForm = new EditElementForm(objReader, row);
            editElementForm.ShowDialog();

            dtGridElements.Rows.Clear();
            getElements();
            populateDataGridElement();

        }
    }
}
