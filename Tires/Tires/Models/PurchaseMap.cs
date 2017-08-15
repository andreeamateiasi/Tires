using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tires.Models
{
    public class PurchaseMap: EntityTypeConfiguration<Purchase>
    {
        public PurchaseMap()
        {
            this.HasKey(t => t.PurchaseId);

            this.ToTable("Purchase");
            this.Property(t => t.PurchaseId).HasColumnName("PurchaseId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.TireId).HasColumnName("TireId").IsRequired();

            this.HasRequired(t => t.Tire)
                .WithMany(t => t.Purchases)
                .HasForeignKey(t => t.TireId);
            

        }
    }
}