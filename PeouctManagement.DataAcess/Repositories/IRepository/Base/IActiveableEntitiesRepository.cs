using System.Linq.Expressions;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDataAccess.Repositories.IRepository.Base
{
    public interface IActiveableEntitesRepository<TEntity> : IRepository<TEntity> where TEntity : DomainEntityActive
    {

        Task<TEntity> GetActiveById(int id);
        Task<TEntity> GetDeactiveById(int id);
        Task<TEntity> FindActiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindDeactiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindActiveList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetActiveList();
        Task<IEnumerable<TEntity>> GetDeActiveList();

    }
}
