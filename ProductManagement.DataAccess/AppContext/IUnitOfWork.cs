using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.DataAccess.AppContext
{
    public interface IUnitOfWork
    {

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : DomainEntity;

        DbSet<TEntity> Set<TEntity>() where TEntity : DomainEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();


    }
}
