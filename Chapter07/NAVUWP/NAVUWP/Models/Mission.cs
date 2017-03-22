using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVUWP.Models
{
    public class Mission
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public string Note { get; set; }

    }
}