using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.ModelsConfug
{
    public class ProductAttributeDetailConfig : IEntityTypeConfiguration<ProductAttributeDetail>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeDetail> builder)
        {
            builder.ToTable("Product_AttributeDetail");

            builder.HasIndex(e => e.AttributeId, "IX_Product_AttributeDetail_AttributeId");

            builder.HasIndex(e => e.ProductId, "IX_Product_AttributeDetail_ProductId");

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
