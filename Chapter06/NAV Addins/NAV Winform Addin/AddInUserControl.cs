using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_Winform_Addin
{
    public partial class AddInUserControl : UserControl
    {
        public AddInUserControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<string> list)
        {
            ODPListBox.DataSource = list;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string ODP = txtODPBarcode.Text.Trim();
            ODPListBox.Items.Add(ODP);
            ODPListBox.Refresh();
            txtODPBarcode.Text = "";
            txtODPBarcode.Focus();
        }
    }
}
