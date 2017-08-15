using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Tire> Tires { get; set; }
        public Category()
        {
            Tires = new List<Tire>();
        }

    }
}