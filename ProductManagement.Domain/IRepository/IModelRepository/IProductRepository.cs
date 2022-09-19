
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.Entites;
using System.Linq.Expressions;

namespace ProductManagementDomain.IRepository.IModelRepository
{
    public interface IProductRepository : IActiveableEntitesRepository<Product>
    {

        Task<Product> GetWithAttributesById(int id);
        Task<IEnumerable<Product>> GetAllWithAttributes();
        Task<Product> GetActiveWithAttributesById(int id);
        Task<Product> GetDeactiveWithAttributesById(int id);
        Task<Product> FindActiveWithAttributesEntity(Expression<Func<Product, bool>> predicate);
        Task<Product> FindDeactiveWithAttributesEntity(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> FindActiveListWithAttributes(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> FindDeactiveListWithAttributes(Expression<Func<Product, bool>> predicate);

    }
}
