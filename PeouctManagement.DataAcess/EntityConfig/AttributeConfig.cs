using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Attribute = ProductManagementDomain.Models.Entites.Attribute;

namespace ProductManagementDataAccess.EntityConfig
{
    public class AttributeConfig : IEntityTypeConfiguration<Attribute>
    {
        public void Configure(EntityTypeBuilder<Attribute> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.ParentId).HasDefaultValueSql("((0))");

            builder.Property(e => e.Value)
                .HasMaxLength(1000)
                .HasDefaultValueSql("('')");
        }
    }
}
