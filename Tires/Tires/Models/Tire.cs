using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class Tire
    {
        public int TireId { get; set; }
        public string Brand { get; set; }
        public string TireHeight { get; set; }
        public string TireWeight { get; set; }
        public string TireDiameter { get; set; }
        public string TireType { get; set; }
        public string Number { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public Tire()
        {
            Purchases = new List<Purchase>();
        }

    }
}