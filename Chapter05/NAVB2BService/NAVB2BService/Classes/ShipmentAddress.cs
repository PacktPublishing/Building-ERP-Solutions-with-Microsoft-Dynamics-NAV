using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVB2BService.Classi
{
    public class ShipmentAddress
    {
        public string CustomerNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CAP { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public Boolean? Default { get; set; }
    }
}