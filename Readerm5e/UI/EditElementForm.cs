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
                //System.Diagnostics.Debug.WriteLine(tagList);
                //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(tagList));
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err);
                throw;
            }
        }
    }
}
