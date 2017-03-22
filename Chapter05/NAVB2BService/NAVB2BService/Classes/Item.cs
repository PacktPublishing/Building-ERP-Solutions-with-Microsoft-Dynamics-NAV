using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVB2BService.Classi
{
    public class Item
    {
        public string No { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public decimal? Inventory { get; set; }
        public int? Lot { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ItemType { get; set; }
        public string ItemBrand { get; set; }
        public string BrandDescription { get; set; }
    }
}