using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoasterCreditsCloud.Models
{
    public class Credit
    {
        public int CreditID { get; set; }
        public string Coaster { get; set; }
        public string User { get; set; }
    }
}
