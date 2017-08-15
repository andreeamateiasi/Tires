using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tires.Models
{
    public class CategoryMap: EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {

            this.HasKey(t => t.CategoryId);

            this.ToTable("Category");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.CategoryName).HasColumnName("CategoryName").IsRequired().HasMaxLength(32);

        }
    }
}