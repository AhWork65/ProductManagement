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


        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            return await _dbSet.Include(y => y.ValuesAttributes).Where(x=>x.ParentId==id).ToListAsync();

        }

        public async Task<IList<Attribute>> GetAttributeList()
        {
            return await _dbSet.ToListAsync();

        }

    }
}

