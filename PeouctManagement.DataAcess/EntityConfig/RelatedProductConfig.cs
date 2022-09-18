using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagementDomain.Models.Entites;


namespace ProductManagementFinal.Models.EntityConfig
{
    public class RelatedProductConfig :IEntityTypeConfiguration<RelatedProduct>
    {
        public void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.BaseProductId).HasColumnName("BaseProduct_id");

            builder.Property(e => e.RelatedProductId).HasColumnName("RelatedProduct_id");

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
