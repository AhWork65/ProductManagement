using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PProductManagementFinal.Models.EntityConfig;
using ProductManagementDataAccess.Config;
using ProductManagementDomain.Models.BaseEntities;
using ProductManagementDomain.Models.Entites;
using ProductManagementFinal.Models.EntityConfig;
using Attribute = ProductManagementDomain.Models.Entites.Attribute;



namespace ProductManagementDataAccess.App_Context
{
    public partial class ManagementProductsContext :  DbContext, IManagementProductsContext
    {
        private IManagementProductsContext _managementProductsContextImplementation;

        public ManagementProductsContext()
        {
             
        }

        public ManagementProductsContext(DbContextOptions<ManagementProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttributeDetail> ProductAttributeDetails { get; set; } = null!;
        public virtual DbSet<RelatedProduct> RelatedProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettingConfiguration.ConnectionStrings);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1256_CI_AS");
            modelBuilder.ApplyConfiguration(new AttributeConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductAttributeDetailConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new RelatedProductConfig());

            OnModelCreatingPartial(modelBuilder);
        }

   
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public Task<int> SaveChangesAsync()
        {
           return  base.SaveChangesAsync();
        }

        public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : DomainEntity
        {
            return base.Entry(entity);
        }
    }
}
