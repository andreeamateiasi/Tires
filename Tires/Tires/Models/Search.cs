using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class Search
    {
        public string Brand { get; set; }
        public string TireHeight { get; set; }
        public string TireWeight { get; set; }
        public string TireDiameter { get; set; }
        public string TireType { get; set; }
        public int CategoryId { get; set; }
    }
}