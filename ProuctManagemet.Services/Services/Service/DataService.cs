using System.Linq.Expressions;
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.BaseEntities;
using ProuctManagemetServices.Services.IServices;

namespace ProuctManagemetServices.Services.Service
{
    public class DataService<TEntity> : IDataService<TEntity> where TEntity : DomainEntity
    {
        private readonly IRepository<TEntity> _Repository;

        public DataService(IRepository<TEntity> repository)
        {

            _Repository = repository;

        }

        public async Task Create(TEntity entity)
        {

            await _Repository.Add(entity);

        }

        public async Task Delete(TEntity entity)
        {

            await _Repository.Delete(entity);

        }

        public async Task DeleteById(int id)
        {
            await _Repository.DeleteById(id);
        }

        public async Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Repository.FindEntity(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return await _Repository.FindList(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {

            return await _Repository.GetAll();

        }

        public Task<TEntity> GetById(int id)
        {

            return _Repository.GetById(id);

        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
