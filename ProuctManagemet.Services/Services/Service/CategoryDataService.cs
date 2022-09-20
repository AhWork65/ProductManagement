
using ProductManagementDomain.IRepository;
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.Entites;
using ProuctManagemetServices.Services.IServices;

namespace ProuctManagemetServices.Services.Service
{
    
    public class CategoryDataService :
        AvtiveableEntitiesDataService<Category>, ICategorDataService

    {
        private readonly ICategoryRepository _Repository; 
        public CategoryDataService(ICategoryRepository repository) : base(repository)
        {
            _Repository = repository; 
        }
    }
}
