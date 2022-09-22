using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.ModelsConfug
{
    public  class RelatedProductConfig : IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.HasIndex(e => e.BaseProductId, "IX_RelatedProducts_BaseProductId");

            builder.HasIndex(e => e.RelatedProductId, "IX_RelatedProducts_RelatedProductId");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.HasOne(d => d.BaseProduct)
                .WithMany(p => p.RelatedProductBaseProducts)
                .HasForeignKey(d => d.BaseProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RelatedGoods_Goods_BaseGood");

            builder.HasOne(d => d.RelatedProductNavigation)
                .WithMany(p => p.RelatedProductRelatedProductNavigations)
                .HasForeignKey(d => d.RelatedProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RelatedGoods_Goods_Related");
        }
    }
}
