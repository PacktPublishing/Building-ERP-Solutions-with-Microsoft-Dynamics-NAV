using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynamicsNAVButtonPanel
{
    public class DAL
    { 
        public Dictionary<string,Boolean> GetItems()
        {
            Dictionary<string, Boolean> dict = new Dictionary<string, Boolean>();
            LoadProductionOrders(ref dict);
            
            return dict;
        }

        private void LoadProductionOrders(ref Dictionary<string, Boolean> dict)
        {
            //Fake method to retrive order's details from the external machine
            dict.Add("ODP16/001", true);
            dict.Add("ODP16/002", true);
            dict.Add("ODP16/003", false);
            dict.Add("ODP16/004", true);
            dict.Add("ODP16/005", false);
            dict.Add("ODP16/006", true);
            dict.Add("ODP16/008", false);
            dict.Add("ODP16/011", false);
            dict.Add("ODP16/023", true);
        }

        public ODP GetODPDetails(string ProdOrderNo)
        {
            ODP odp = new ODP();
            odp.Code = ProdOrderNo;
            odp.Machine1 = 10;
            odp.Machine2 = 48;
            odp.Machine3 = 32;
            return odp;
        } 
    }
}
