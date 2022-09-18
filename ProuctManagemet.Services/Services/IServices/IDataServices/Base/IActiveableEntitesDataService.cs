using ManagementProductProject.Models.BaseModel;
using System.Linq.Expressions;

namespace ManagementProductProject.Services.IServices.IDataServices.Base
{
    public interface IActiveableEntitesDataService<TEntity>
        : IDataService<TEntity> where TEntity : IActiveableEntitesModel
    {
        Task<TEntity> GetActiveById(int id);
        Task<TEntity> GetDeactiveById(int id);
        Task<TEntity> FindActiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindDeactiveEntity(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindActiveList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindDeactiveList(Expression<Func<TEntity, bool>> predicate);
    }
}
