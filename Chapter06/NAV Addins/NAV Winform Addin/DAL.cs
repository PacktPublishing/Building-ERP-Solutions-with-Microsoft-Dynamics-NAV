using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAV_Winform_Addin
{
    public class DAL
    {
        public List<string> LoadODPData()
        {
            List<string> lst = new List<string>();
            lst.Add("ODP16-001");
            lst.Add("ODP16-005");
            lst.Add("ODP16-007");
            lst.Add("ODP16-013");
            return lst;
        }
    }
}
