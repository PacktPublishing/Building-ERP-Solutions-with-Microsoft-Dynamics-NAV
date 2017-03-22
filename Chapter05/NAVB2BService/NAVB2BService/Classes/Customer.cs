using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVB2BService.Classi
{
    public class Customer
    {
        public string No { get; set; }
        //public string Username { get; set; }
        //public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CAP { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string FiscalCode { get; set; }
        public string VATNo { get; set; }
        public string EmailEcommerce { get; set; }
        public Boolean? Active { get; set; }
        //public Boolean? IsHiddenPrice { get; set; }
        //public string B2BPassword { get; set; }
        //public string HiddenPricePassword { get; set; }
        //public Boolean? OrdiniBloccati { get; set; }
    }
}