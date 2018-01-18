using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoasterCredits.Models
{
    public class Park
    {
        public int ParkID { get; set; }
        public string ParkName { get; set; }
        public string ParkLocation { get; set; }
        public float ParkLatitude { get; set; }
        public float ParkLongitude { get; set; }
    }
}
