using System.Linq.Expressions;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.DataAccess.Repositories
{
    public class AttributeRepository : BaseRepository<Attribute>, IAttributesRepository
    {

        public AttributeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            return await _dbSet
                .Include(y => y.subNodes)
                .Where(p => p.Id == id)
                .Select(y => new Attribute
                {
                    Id = y.Id,
                    Value = y.Value,
                    Name = y.Name,
                    ParentId = y.ParentId,
                    subNodes = y.subNodes

                })
                .ToListAsync();
        }

    public async Task<List<Attribute>> GetAttributeListAsync()
        {
            List<Attribute> temp = await _dbSet
                        .Include(y => y.subNodes)
                        .Where(x => x.ParentNode == null)
                        .Select(y => new Attribute
                        {
                            Id = y.Id,
                            ParentId = y.ParentId,
                            Name = y.Name,
                            Value = y.Value,
                            subNodes = y.subNodes,
                          
                            
                        }).ToListAsync();
            return temp;
        }


        public Attribute GetNodeAttribute(Attribute value)
        {
            return _dbSet
                .Include(y => y.subNodes)
                .Include(y => y.ProductAttributeDetails)
                .Where(y => y.Id == value.Id)
                .Select(y => new Attribute
                {
                    Id = y.Id,
                    ParentId = y.ParentId,
                    Name = y.Name,
                    Value = y.Value,
                    subNodes = y.subNodes,
                    ProductAttributeDetails = y.ProductAttributeDetails
                }).First();
        }

        public bool IsExistParent(string Title,string value)
        {
           
            return _dbSet
                 .Any(p =>p.Name.ToLower().Trim() == Title.ToLower().Trim()
                 && p.Value.ToLower().Trim() == value.ToLower().Trim());
        }

        public async Task<List<Attribute>> GetAttributeListByProductId(int id)
        {
          var listAttribute= await _dbSet
                       .Include(y=>y.subNodes)
                       .Include(y => y.ProductAttributeDetails)
                       .Where(p =>p.ProductAttributeDetails
                       .Any(m => m.ProductId == id))
                       .ToListAsync();
          return listAttribute;
        }
    }
}

