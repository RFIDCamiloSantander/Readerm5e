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

namespace Readerm5e.UI
{
    public partial class ReadingsForm : Form
    {
        List<Reading> readingsList;
        public ReadingsForm()
        {
            //readingsList = ReadingsDao.ReadAllReadings();
            InitializeComponent();

            dtGridReadings.Rows.Add("nombre", "EPC");
        }
    }
}
