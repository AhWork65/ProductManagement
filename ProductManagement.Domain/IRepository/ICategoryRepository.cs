using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.Entites;

namespace ProductManagementDomain.IRepository
{
    public interface ICategoryRepository : IActiveableEntitesRepository<Category>
    {
    }
}
