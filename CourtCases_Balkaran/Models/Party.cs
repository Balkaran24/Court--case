using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases_Balkaran.Models
{
    public class Party
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public List<Case> Cases { get; set; }
    }
}