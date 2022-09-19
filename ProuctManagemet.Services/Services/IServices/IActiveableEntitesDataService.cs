using ProductManagementDomain.Models.BaseEntities;
using System.Linq.Expressions;

namespace ProuctManagemetServices.Services.IServices
{
    public interface IActiveableEntitesDataService<TEntity>
        : IDataService<TEntity> where TEntity : DomainEntityActive
    {
        Task<TEntity> GetActiveById(int id);
        Task<TEntity> GetDeactiveById(int id);
        Task<TEntity> FindActiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindDeactiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindActiveList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetActiveList();
        Task<IEnumerable<TEntity>> GetDeActivList();
    }
}
