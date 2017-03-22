using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicsNAVButtonPanel
{
    [Serializable]
    public class ODP
    {
        public string Code { get; set; }
        public decimal Machine1 { get; set; }
        public decimal Machine2 { get; set; }
        public decimal Machine3 { get; set; }

    }
}
