using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProductManagementDataAccess.App_Context;
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDataAccess.Repositories.Repository.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainEntity
    {
        protected readonly IManagementProductsContext _Context;
        protected readonly DbSet<TEntity> db;

        public Repository(IManagementProductsContext context)
        {
            _Context = context;
            db = _Context.Set<TEntity>();

        }

        public async Task Add(TEntity entity)
        {

            await db.AddAsync(entity);

        }

        public async Task Delete(TEntity entity)
        {

            db.Remove(entity);

        }

        public async Task DeleteById(int id)
        {
            var entity = await db.SingleAsync(e => e.Id == id);
            db.Remove(entity);

        }

        public async Task<TEntity> GetById(int id)
        {

            return await db.FindAsync(id);

        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {

            return await db.ToListAsync();

        }


        public async Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return await db.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate)
        {

            return await db.FirstOrDefaultAsync(predicate);

        }
    }
}
