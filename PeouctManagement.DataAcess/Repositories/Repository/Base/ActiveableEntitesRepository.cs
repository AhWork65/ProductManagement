
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProductManagementDataAccess.App_Context;
using ProductManagementDomain.Models.BaseEntities;
using ProductManagementDomain.IRepository.Base;

namespace ProductManagementDataAccess.Repositories.Repository.Base
{
    public class ActiveableEntitesRepository<TEntity> :
        Repository<TEntity>, IActiveableEntitesRepository<TEntity> where TEntity : DomainEntityActive
    {
        public ActiveableEntitesRepository(IManagementProductsContext context) : base(context)
        {
        }

        public async Task<TEntity> GetActiveById(int id )
        {

            return await db.Where(mdl => mdl.Id == id & mdl.IsActive == true).FirstOrDefaultAsync(); 

        }


        public async Task<TEntity> GetDeactiveById(int id)
        {

            return await db.Where(mdl => mdl.Id == id & mdl.IsActive == false).FirstOrDefaultAsync();

        }

        public async Task<TEntity> FindActiveEntity(Expression<Func<TEntity, bool>> predicate)
        {
           
            return await db.Where((predicate)).Where(mdl=>mdl.IsActive==true).FirstOrDefaultAsync(); 

        }

        public async Task<IEnumerable<TEntity>> FindActiveList(Expression<Func<TEntity, bool>> predicate)
        {

            return await db.Where(predicate).Where(mdl => mdl.IsActive == true ).ToListAsync();

        }

        public async  Task<TEntity> FindDeactiveEntity(Expression<Func<TEntity, bool>> predicate)
        {

            return await db.Where((predicate)).Where(mdl => mdl.IsActive == false).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate)
        {

            return await db.Where(predicate).Where(mdl => mdl.IsActive == true).ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetActiveList()
        {
            return await db.Where(mdl => mdl.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetDeActiveList()
        {
            return await db.Where(mdl => mdl.IsActive == false).ToListAsync();
        }
    }
}
