using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Tires.Models
{
    public class TireMap: EntityTypeConfiguration<Tire>
    {
        public TireMap()
        {
            this.HasKey(t => t.TireId);

            this.ToTable("Tire");
            this.Property(t => t.TireId).HasColumnName("TireId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Brand).HasColumnName("Brand").IsRequired().HasMaxLength(32);
            this.Property(t => t.TireHeight).HasColumnName("TireHeight").IsRequired().HasMaxLength(32);
            this.Property(t => t.TireWeight).HasColumnName("TireWeight").IsRequired().HasMaxLength(32);
            this.Property(t => t.TireType).HasColumnName("TireType").IsRequired().HasMaxLength(32);
            this.Property(t => t.TireDiameter).HasColumnName("TireDiameter").IsRequired().HasMaxLength(32);
            this.Property(t => t.Number).HasColumnName("Number").IsRequired().HasMaxLength(16);
            this.Property(t => t.CategoryId).HasColumnName("CategoryId").IsRequired();

            this.HasRequired(t => t.Category)
                .WithMany(t => t.Tires)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}