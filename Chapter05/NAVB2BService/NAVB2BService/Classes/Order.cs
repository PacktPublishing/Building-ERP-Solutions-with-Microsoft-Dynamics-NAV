using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVB2BService.Classi
{
    public class Order
    {
        public string OrderNo { get; set; }
        public int LineNo { get; set; }
        public string CustomerNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipmentAddressCode { get; set; }
        public string ItemNo { get; set; }
        public decimal Quantity { get; set; }
        public string Note { get; set; }
    }
}