using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCases_Balkaran.Models
{
    public class Judge
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Age { get; set; }
        public List<Case> Cases { get; set; }
    }
}