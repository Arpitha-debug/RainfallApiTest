using RainfallApiTest.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallApiTest.Models
{
    public class ApiResponse
    {
        public Meta Meta { get; set; }
        public List<Item> Items { get; set; }
    }
}

