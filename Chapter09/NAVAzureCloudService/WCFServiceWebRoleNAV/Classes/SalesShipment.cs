using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceWebRoleNAV.Classes
{
    public class SalesShipment
    {
        public string No { get; set; }
        public string CustomerNo { get; set; }
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
        public string UoM { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? ShipmentDate { get; set; }
    }
}