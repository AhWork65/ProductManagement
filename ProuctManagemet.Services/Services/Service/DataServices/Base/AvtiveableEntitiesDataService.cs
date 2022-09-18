using ManagementProductProject.Models.BaseModel;
using ManagementProductProject.Repositories.IRepository.Base;
using ManagementProductProject.Services.IServices.IDataServices.Base;
using System.Linq.Expressions;

namespace ManagementProductProject.Services.Service.DataServices.Base
{
    public class AvtiveableEntitiesDataService<TEntity>
        : DataService<TEntity> , IActiveableEntitesDataService<TEntity> where TEntity : IActiveableEntitesModel
    {

        protected readonly IActiveableEntitesRepository<TEntity> _Repository;

        public AvtiveableEntitiesDataService(IActiveableEntitesRepository<TEntity> repository) : base(repository)
        {
            _Repository = repository; 
        }


        public async Task<TEntity> FindActiveEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Repository.FindActiveEntity(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindActiveList(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Repository.FindActiveList(predicate); 
        }

        public async Task<TEntity> FindDeactiveEntity(Expression<Func<TEntity, bool>> predicate)
        {
            
            return await (_Repository.FindDeactiveEntity(predicate));

        }

        public async Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate)
        {

            return await _Repository.FindDeactiveList(predicate); 

        }

        public async Task<TEntity> GetActiveById(int id)
        {
            
            return await _Repository.GetActiveById(id);
        }

      
 
        public async Task<TEntity> GetDeactiveById(int id)
        {
            return await _Repository.GetDeactiveById(id); 
        }

       
    }
}
