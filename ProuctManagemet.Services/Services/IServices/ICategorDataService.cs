using ManagementProductProject.Models;
using ManagementProductProject.Repositories.IRepository;
using ManagementProductProject.Services.IServices.IDataServices.Base;

namespace ManagementProductProject.Services.IServices
{
    public interface ICategorDataService : IActiveableEntitesDataService<Category>
    {
        Task<IEnumerable<Category>> GetActiveCategoiesList();
        Task<IEnumerable<Category>> GetDeActiveCategoiesList();
    }
}
