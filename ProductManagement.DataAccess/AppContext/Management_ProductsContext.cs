using Microsoft.EntityFrameworkCore;
using ProductManagementDataAccess.Config;
using ProductManagementWebApi.Models;
using ProductManagement.Domain.ModelsConfug;

namespace ProductManagement.DataAccess.AppContext
{
    public partial class Management_ProductsContext : DbContext, IUnitOfWork
    {
        public Management_ProductsContext()
        {
        }

        public Management_ProductsContext(DbContextOptions<Management_ProductsContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseSqlServer(AppSettingConfiguration.ConnectionStrings);
        }

        public virtual DbSet<ProductManagementWebApi.Models.Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttributeDetail> ProductAttributeDetails { get; set; } = null!;
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.UseCollation("SQL_Latin1_General_CP1256_CI_AS");

            modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfiguration(new AttributeConfig());

            modelBuilder.ApplyConfiguration(new ProductConfig());

            modelBuilder.ApplyConfiguration(new ProductAttributeDetailConfig());

            modelBuilder.ApplyConfiguration(new RelatedProductConfig());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
