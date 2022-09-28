using System.Linq.Expressions;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;

using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.DataAccess.Repositories
{
    public class AttributeRepository : BaseRepository<Attribute>, IAttributesRepository
    {

        public AttributeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


        public async Task DeleteByIdAsync(int id)
        {
            var subnodes = await _dbSet.Where(x => x.Id == id && x.ParentId != null).ToListAsync();
            if (subnodes == null)
                return;

            await DeleteById(id);

        }

        public async Task DeleteByParentId(int id)
        {

            var entitList = await _dbSet.Where(e => e.ParentId == id).ToListAsync();
            if (entitList == null)
                return;
            foreach (var e in entitList)
            {
                if (e.ParentId != null)
                {
                    Delete(e);
                }
            }
            await DeleteById(id);

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
                            subNodes = y.subNodes
                        }).ToListAsync();
            return temp;
        }


        public Attribute GetNodeAttribute(Attribute value)
        {
            return _dbSet.Include(y => y.subNodes)
                .Where(y => y.Id == value.Id)
                .Select(y => new Attribute
                {
                    Id = y.Id,
                    ParentId = y.ParentId,
                    Name = y.Name,
                    Value = y.Value,
                    subNodes = y.subNodes
                }).First();
        }

        public bool IsExistParent(string Title)
        {
            _dbSet
                  .Include(y=>y.subNodes)
                  .Where(p =>p.Name.ToLower() == Title.ToLower());

            return true;
        }
    }
}

