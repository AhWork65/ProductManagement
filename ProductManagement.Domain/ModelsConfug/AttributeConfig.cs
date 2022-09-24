using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.ModelsConfug
{
    public class AttributeConfig : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
         
            
            builder.Property(e => e.Name)
                 .HasMaxLength(100)
                 .IsUnicode(false)
                 .IsRequired()
                 .HasDefaultValueSql("('')");

           

           builder.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasDefaultValueSql("('')");



           builder
               .HasMany(d => d.subNodes)
               .WithOne(p => p.ParentNode)
               .HasForeignKey(w=>w.ParentId)
               .IsRequired(false);



        }
    }
}
