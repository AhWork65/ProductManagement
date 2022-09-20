using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductManagementDomain.IRepository;
using ProductManagementDataAccess.App_Context;
using ProductManagementDataAccess.Repositories.Repository.Base;
using ProductManagementDomain.Models.Entites;

namespace ProductManagementDataAccess.Repositories.Repository
{
    public class CategoryRepository : ActiveableEntitesRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(IManagementProductsContext context) : base(context)
        {
        }
    }
}
