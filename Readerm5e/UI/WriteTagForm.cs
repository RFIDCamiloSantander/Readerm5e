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
            objReader.WriteTag(null, new TagData( txtWriteEpc.Text ));
        }
    }
}
