using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementDomain.Models.Entites;


namespace ProductManagementFinal.Models.EntityConfig
{
    public class ProductAttributeDetailConfig:IEntityTypeConfiguration<ProductAttributeDetail>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeDetail> builder)
        {
            builder.ToTable("Product_AttributeDetail");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasOne(d => d.Attribute)
                .WithMany(p => p.ProductAttributeDetails)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_AttributeDetail_Attributes");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductAttributeDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_AttributeDetail_Products");
        }
    }
}
