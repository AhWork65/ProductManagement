using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.ModelsConfug
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.ToTable("Category");

            builder.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength().IsRequired();

            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false).IsRequired();
        }
    }
}
