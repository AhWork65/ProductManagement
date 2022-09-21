using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public  class ProductRepository :IProductRepository
    {
        private readonly Management_ProductsContext _Context;

        public ProductRepository(Management_ProductsContext context)
        {
            _Context = context; 
        }

        public async Task<Product> GetById(int id)
        {

            return await _Context.Products.FindAsync(id); 

        }

        public async Task<IList<Product>> GetAll()
        {

            return await _Context.Products.ToListAsync(); 

        }

        public async  Task Add(Product entity)
        {
            
           await _Context.Products.AddAsync(entity);  

        }

        public void Delete(Product entity)
        {

             _Context.Products.Remove(entity); 

        }

        public async Task DeleteById(int id)
        {

            var obj = await _Context.Products.FindAsync(id);
            _Context.Products.Remove(obj); 

        }

        public  async Task<IList<Product>> FindList(Expression<Func<Product, bool>> predicate)
        {

            return await _Context.Products.Where(predicate).ToListAsync(); 

        }

        public async Task<Product> FindEntity(Expression<Func<Product, bool>> predicate)
        {

            return await _Context.Products.Where(predicate).FirstAsync(); 

        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Any(Expression<Func<Product, bool>> predicate)
        {
            return await _Context.Products.AnyAsync(predicate);
        }

        public async Task<Product> FindById(int Id)
        {
            return await _Context.Products.FindAsync(Id); 
        }


        public async  Task<IList<Product>> GetProductByClassification(int classificationId)
        {

            return await _Context.Products.Where(mdl => mdl.Classification == classificationId).ToListAsync(); 

        }

        public async Task<Product> GetProductByCode(string code)
        {

            return await _Context.Products.Where(mdl => mdl.Code == code).FirstAsync(); 

        }

        public async  Task<IList<Product>> GetProductByCategory(int categoryId)
        {

            return await _Context.Products.Where(mdl => mdl.CategoryId == categoryId).ToListAsync(); 

        }

        public async  Task<IList<Product>> GetProductByCategory(Category category)
        {

            return await _Context.Products.Where(mdl => mdl.Category == category).ToListAsync(); 

        }

        public async  Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            return await  _Context.Products.Where(mdl => mdl.ProductAttributeDetails.Contains(attribute)).ToListAsync();

        }

        public async  Task<Product> GetByIdWithAttributes(int productId)
        {

            return  await _Context.Products
                .Include(mdl => mdl.ProductAttributeDetails)
                .ThenInclude(mdl => mdl.Attribute)
                .Where(mdl => mdl.Id == productId)
                .FirstAsync();

        }


        public async  Task<IList<Product>> GetActiveList()
        {

            return await _Context.Products
                .Where(mdl => mdl.IsActive == true && mdl.Category.IsActive == true)
                .ToListAsync(); 

        }

        public async  Task<IList<Product>> GetInactiveList()
        {

            return await _Context.Products
                .Where(mdl => mdl.IsActive == false )
                .ToListAsync();

        }
    }
}
