using RainfallApiTest.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallApiTest.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public LatestReading LatestReading { get; set; }
    }
}
