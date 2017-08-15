using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class TireDBContext: DbContext
    {
        static TireDBContext()
        {
            Database.SetInitializer<TireDBContext>(null);
        }
        public TireDBContext()
            : base("Name = TireDBContext")
        {

        }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TireMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new PurchaseMap());
        }


    }
}

