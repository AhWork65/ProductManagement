using System.Linq.Expressions;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDomain.IRepository.Base
{
    public interface IRepository<TEntity> where TEntity : DomainEntity
    {

        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Delete(TEntity entity); 
        Task DeleteById(int id);
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate); //Specification
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);

    }
}
