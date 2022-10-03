using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Dto.Attribute;
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


        public async Task<List<AttributeSubDto>> GetAttributeDetailByParentId(int id)
        {
            return await _dbSet
                .Include(y => y.subNodes)
                .Where(p => p.ParentId == id)
                .Select(y => new AttributeSubDto
                {
                    Id = y.Id,
                    Value = y.Value,
                    Name = y.Name,
                    ParentId = y.ParentId,
                    subNodes = y.subNodes.Select
                    (
                        x => new AttributeSubDto()
                        { Id = x.Id, Name = x.Name, ParentId = x.ParentId, Value = x.Value }
                    ).ToList(),

                })
                .ToListAsync();
        }

        public async Task<List<AttributeSubDto>> GetAttributeDetailByNodeId(int id)
        {
            return await _dbSet
                .Include(y => y.subNodes)
                .Where(p => p.Id == id)
                .Select(y => new AttributeSubDto
                {
                    Id = y.Id,
                    Value = y.Value,
                    Name = y.Name,
                    ParentId = y.ParentId,
                    subNodes = y.subNodes.Select
                    (
                        x => new AttributeSubDto()
                            { Id = x.Id, Name = x.Name, ParentId = x.ParentId, Value = x.Value }
                    ).ToList(),

                })
                .ToListAsync();
        }

        public async Task<List<AttributeSubDto>> GetAttributeListAsync()
        {

            var temp = await _dbSet.Include(y => y.subNodes).Where(y => y.ParentNode == null).Select(y => new AttributeSubDto()
            {
                Id = y.Id,
                ParentId = y.ParentId,
                Name = y.Name,
                Value = y.Value,
                subNodes = y.subNodes.Select
                         (
                              x => new AttributeSubDto()
                              { Id = x.Id, Name = x.Name, ParentId = x.ParentId, Value = x.Value }
                         ).ToList(),

            }).ToListAsync();

            return temp;

        }



        public bool IsExistParent(string Title, string value)
        {

            return _dbSet
                 .Any(p => p.Name.ToLower().Trim() == Title.ToLower().Trim()
                 && p.Value.ToLower().Trim() == value.ToLower().Trim());
        }

        public async Task<List<AttributeSubDto>> GetAttributeListByProductId(int id)
        {
            var listAttribute = await _dbSet
                           .Include(y => y.ProductAttributeDetails)
                           .Where(p => p.ProductAttributeDetails.Any(m => m.ProductId == id))
                           .Select(y => new AttributeSubDto()
                           {
                               Id = y.Id,
                               ParentId = y.ParentId,
                               Name = y.Name,
                               Value = y.Value,
                               subNodes = y.subNodes.Select(
                                         x => new AttributeSubDto()
                                          { Id = x.Id, Name = x.Name, ParentId = x.ParentId, Value = x.Value }
                                        ).ToList(),

                           }).ToListAsync();
            return listAttribute;
        }


        public async Task Delete(AttributeSubDto entity)
        {
            var entityToDelete = _dbSet.Find(entity.Id);

            if (entityToDelete == null)
                return;

            _dbSet.Remove(entityToDelete);

            _unitOfWork.SaveChanges();
        }
    }
}

