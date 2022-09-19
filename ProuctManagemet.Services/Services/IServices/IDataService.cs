using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ProuctManagemetServices.Services.IServices
{
    public interface IDataService<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task DeleteById(int id);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);


    }
}
