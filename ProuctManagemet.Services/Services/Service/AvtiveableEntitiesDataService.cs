using ProuctManagemetServices.Services.IServices;
using System.Linq.Expressions;
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.BaseEntities;

namespace ProuctManagemetServices.Services.Service
{
    public class AvtiveableEntitiesDataService<TEntity>
        : DataService<TEntity>, IActiveableEntitesDataService<TEntity> where TEntity : DomainEntityActive
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

            return await _Repository.FindDeactiveEntity(predicate);

        }

        public async Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate)
        {

            return await _Repository.FindDeactiveList(predicate);

        }

        public async Task<IEnumerable<TEntity>> GetActiveList()
        {
            return await _Repository.GetActiveList();
        }

        public async Task<IEnumerable<TEntity>> GetDeActivList()
        {
            return await _Repository.GetDeActiveList();
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
