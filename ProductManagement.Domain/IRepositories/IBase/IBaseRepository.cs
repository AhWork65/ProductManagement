using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Repositories.Base
{
    public  interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteById(int id);
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate); 
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);

    }
}
