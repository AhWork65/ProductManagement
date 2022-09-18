

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDataAccess.App_Context
{
   public interface IManagementProductsContext
    {
       DbSet<TEntity> Set<TEntity>() where TEntity : class;
       int SaveChanges();
       Task<int> SaveChangesAsync();
       EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : DomainEntity;

   }
}
