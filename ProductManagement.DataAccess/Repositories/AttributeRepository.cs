using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;
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


      

        public async Task<Attribute> GetById(int id)
        {

            return await _dbSet.FindAsync(id);

        }

        public async Task<IList<Attribute>> GetAll()
        {

            return await _dbSet.ToListAsync();

        }
        /// <summary>
        /// over load get all
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<IList<Attribute>> GetAll(string title)
        {

            return await _dbSet.Include(y => y.subNodes).Where(e => e.Name.ToLower() == title.ToLower()).ToListAsync();

        }

        public async Task Add(Attribute entity)
        {

            await _dbSet.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public int AddDto(Attribute entitiy)
        {
            _dbSet.Add(entitiy);
            _unitOfWork.SaveChanges();
            return entitiy.Id;
        }

        public void Delete(Attribute entity)
        {

            _dbSet.Remove(entity);

        }

        public async Task DeleteById(int id)
        {

            var obj = await _dbSet.FindAsync(id);
            _dbSet.Remove(obj);

        }

        public async Task<IList<Attribute>> FindList(Expression<Func<Attribute, bool>> predicate)
        {

            return await _dbSet.Where(predicate).ToListAsync();

        }

        public async Task<Attribute> FindEntity(Expression<Func<Attribute, bool>> predicate)
        {

            return await _dbSet.Where(predicate).FirstAsync();

        }

        public async Task Update(Attribute entityToUpdate)
        {
            throw new NotImplementedException();

        }

        public async Task<bool> Any(Expression<Func<Attribute, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<Attribute> FindById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }


        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            return await _dbSet.Include(y => y.subNodes).Where(p => p.ParentId == id).ToListAsync();

        }

        public async Task<IList<Attribute>> GetAttributeList()
        {
            return await _dbSet.ToListAsync();

        }


        //public async Task<IEnumerable<AttributeDto>> GetCollectionNodes(string Title)
        //{
        //    var items = await  GetAll(e => e.Name.ToLower() == Title.ToLower());


        //    return (IEnumerable<AttributeDto>)items;
        //}

        public async Task<bool> IsExsistAttrbiute(int id)
        {
            return await _dbSet.AnyAsync(a => a.Id == id);
        }

        public async Task<AttributeDto> updateAttrbiute(AttributeDto valueDto, int id)
        {
            //_dbSet.Update();
            //await _unitOfWork.SaveChangesAsync();
            return valueDto;
        }

        public Attribute GetNodeAttribute(AttributeDto valueDto)
        {
            return _dbSet
                    .Include(a => a.subNodes).Where(p => p.Id == valueDto.ParentId).FirstOrDefault();

        }


    }
}

