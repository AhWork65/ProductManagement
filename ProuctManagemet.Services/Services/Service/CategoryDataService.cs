using ManagementProductProject.Models;
using ManagementProductProject.Repositories.IRepository;
using ManagementProductProject.Repositories.IRepository.Base;
using ManagementProductProject.Services.IServices;
using ManagementProductProject.Services.Service.DataServices.Base;

namespace ManagementProductProject.Services.Service
{
    public class CategoryDataService :
        AvtiveableEntitiesDataService<Category>, ICategorDataService

    {
        private readonly ICategoryRepository _Repository; 

        public CategoryDataService(ICategoryRepository repository) : base(repository)
        {
            _Repository = repository; 
        }


        public async Task<IEnumerable<Category>> GetActiveCategoiesList()
        {
                
                return await _Repository.GetActiveCategoiesList();
        }

        public async Task<IEnumerable<Category>> GetDeActiveCategoiesList()
        {

            return await _Repository.GetDeActiveCategoiesList(); 

        }
    }
}
