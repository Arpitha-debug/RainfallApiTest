using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallApiTest.Models
{
    public class LatestReading
    {
        public string Date { get; set; }
        public string DateTime { get; set; }
        public string Measure { get; set; }
        public double Value { get; set; }
    }
}

