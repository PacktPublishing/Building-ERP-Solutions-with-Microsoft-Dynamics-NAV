﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLocation.Classes
{
    public class MissionTicket
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude  { get; set; }

    }
}
