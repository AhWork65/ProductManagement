
using ProductManagementDomain.IRepository.Base;
using ProductManagementDomain.Models.Entites;
using ProuctManagemetServices.Services.IServices;

namespace ProuctManagemetServices.Services.Service
{
    public class CategoryDataService :
        AvtiveableEntitiesDataService<Category>, ICategorDataService

    {
        private readonly IActiveableEntitesRepository<Category> _Repository;

        public CategoryDataService(IActiveableEntitesRepository<Category> repository) : base(repository)
        {
            _Repository = repository;
        }



    }
}
