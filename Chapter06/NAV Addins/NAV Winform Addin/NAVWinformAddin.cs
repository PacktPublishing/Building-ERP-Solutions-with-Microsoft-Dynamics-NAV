using Microsoft.Dynamics.Framework.UI.Extensibility;
using Microsoft.Dynamics.Framework.UI.Extensibility.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_Winform_Addin
{
    [ControlAddInExport("EID.NAVWinformAddin")] //Nome da utilizzare in NAV per richiamare l'addin
    [Description("NAV Button Controls Add-In")]
    public class NAVWinformAddin : WinFormsControlAddInBase
    {
        private Panel _panel;
        private AddInUserControl uc;

        [ApplicationVisible]
        [field: NonSerialized]
        public event MethodInvoker AddInReady = delegate { };

        protected override Control CreateControl() 
        {
            uc = new AddInUserControl { Dock = DockStyle.Fill };

            _panel = new Panel
            {
                Dock = DockStyle.Fill,
                Size = new Size(500, 300)
            };

            _panel.Controls.Add(uc);

            DAL _dal = new DAL();
            List<string> ODPlist = _dal.LoadODPData();
            uc.LoadData(ODPlist);

            _panel.HandleCreated += (s, e) => AddInReady();

            return _panel;
        }



    }
}
