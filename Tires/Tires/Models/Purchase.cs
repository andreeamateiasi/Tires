using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int TireId { get; set; }
        public virtual Tire Tire { get; set; }

       
    }
}