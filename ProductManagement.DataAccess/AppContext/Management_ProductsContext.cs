using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductManagementWebApi.Models;

using ProductManagementWebApi ; 

namespace ProductManagement.DataAccess.AppContext
{
    public partial class Management_ProductsContext : DbContext
    {
        public Management_ProductsContext()
        {
        }

        public Management_ProductsContext(DbContextOptions<Management_ProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductManagementWebApi.Models.Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttributeDetail> ProductAttributeDetails { get; set; } = null!;
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Management_Products;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.Entity<ProductManagementWebApi.Models.Attribute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            
                entity.Property(e => e.ParentId).HasDefaultValueSql("((0))");
            
                entity.Property(e => e.Value)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("('')");
            });
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
            
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength();
            
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Products_Category_id");
            
                entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            
                entity.Property(e => e.UnitStock).HasDefaultValueSql("((0.0))");
            
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Category");
            });
            
            modelBuilder.Entity<ProductAttributeDetail>(entity =>
            {
                entity.ToTable("Product_AttributeDetail");
            
                entity.HasIndex(e => e.AttributeId, "IX_Product_AttributeDetail_AttributeId");
            
                entity.HasIndex(e => e.ProductId, "IX_Product_AttributeDetail_ProductId");
            
                entity.Property(e => e.Id).HasColumnName("id");
            
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributeDetails)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AttributeDetail_Attributes");
            
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributeDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AttributeDetail_Products");
            });
            
            modelBuilder.Entity<RelatedProduct>(entity =>
            {
                entity.HasIndex(e => e.BaseProductId, "IX_RelatedProducts_BaseProductId");
            
                entity.HasIndex(e => e.RelatedProductId, "IX_RelatedProducts_RelatedProductId");
            
                entity.Property(e => e.Id).HasColumnName("id");
            
                entity.HasOne(d => d.BaseProduct)
                    .WithMany(p => p.RelatedProductBaseProducts)
                    .HasForeignKey(d => d.BaseProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelatedGoods_Goods_BaseGood");
            
                entity.HasOne(d => d.RelatedProductNavigation)
                    .WithMany(p => p.RelatedProductRelatedProductNavigations)
                    .HasForeignKey(d => d.RelatedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelatedGoods_Goods_Related");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
