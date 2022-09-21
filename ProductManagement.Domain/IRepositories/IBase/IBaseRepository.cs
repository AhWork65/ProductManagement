using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Domain.Repositories.Base
{
    public  interface IBaseRepository<TEntity> where TEntity : DomainEntity

    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteById(int id);
        Task<IList<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate); 
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);

    }
}
