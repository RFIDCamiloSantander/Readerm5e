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
            InitializeComponent();
            getReadings();
            foreach (Reading reading in readingsList)
            {

                string date = DateTimeOffset.FromUnixTimeSeconds(reading.TimeStamp).ToString();
                //int cortarString = date.IndexOf("+");
                date = date.Substring(0, date.IndexOf("+"));
                
                System.Diagnostics.Debug.WriteLine(date + " - " + date);
                dtGridReadings.Rows.Add( reading.ElementoId, reading.ElementoName, date, reading.ElementoDescription );
            }
        }

        public void getReadings()
        {
            readingsList = ReadingsDao.ReadAllReadings();
        }
    }
}
