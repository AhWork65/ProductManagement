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
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<Attribute> _dbSet;

        public AttributeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Set<Attribute>();
        }



        public int AddDto(Attribute entitiy)
        {
            _dbSet.Add(entitiy);
            _unitOfWork.SaveChanges();
            return entitiy.Id;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var subnodes = await _dbSet.Where(x => x.Id == id).ToListAsync();
            if (subnodes == null)
                return;
            foreach (var node in subnodes)
            {
                _dbSet.Remove(node);
            }
            await _unitOfWork.SaveChangesAsync();
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

        public List<Attribute> GetAttributeList(List<Attribute> attributes)
        {
            int z = 0;
            List<Attribute> Lists = new List<Attribute>();
            if (attributes.Count > 0)
            {
                Lists.AddRange(attributes);
            }
            foreach (Attribute a in attributes)
            {
                var dbNode = _dbSet.Include(y => y.subNodes)
                    .Where(y => y.Id == a.Id)
                    .Select(y => new Attribute
                    {
                        Id = y.Id,
                        ParentId = y.ParentId,
                        Name = y.Name,
                        Value = y.Value,
                        subNodes = y.subNodes
                    }).First();
                if (dbNode.subNodes == null)
                {
                    z++;
                    continue;
                }

                List<Attribute> subnodes = dbNode.subNodes.ToList();
                dbNode.subNodes = GetAttributeList(subnodes);
                Lists[z] = dbNode;
                z++;
            }

            return Lists;
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
            return GetAttributeList(temp);
        }



        public Attribute GetNodeAttribute(Attribute value)
        {
            return _dbSet.Include(a => a.subNodes).Where(p => p.Id == value.ParentId).FirstOrDefault();
        }


    }
}

