﻿using System.Linq.Expressions;
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

        public async Task<Attribute> GetById(int id)
        {

            return await _dbSet.FindAsync(id);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Attribute>> GetAll()
        {

            return await _dbSet.ToListAsync();

        }
       
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

    
        public async Task DeleteByIdAsync(int id)
        {

            var subnodes = await _dbSet.Where(x=>x.ParentId==id).ToListAsync();
            if (subnodes == null)
                return;
            foreach (var node in subnodes)
            {
                await DeleteByIdAsync(node.Id);
                _dbSet.Remove(node);

            }
           
           await _unitOfWork.SaveChangesAsync();

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
          
            return await _dbSet.Include(y => y.subNodes).Where(p => p.ParentId == id)
                .Select(y => new Attribute { Id=y.Id,Name=y.Name,ParentNode = y.ParentNode, ParentId = y.ParentId ,subNodes = y.subNodes})
                .ToListAsync();
        }

        public async Task<IQueryable<Attribute>> GetAttributeList()
        {
            return _dbSet.SelectMany(c => c.subNodes).Include(c => c.ParentNode).AsQueryable();
        }


        public async Task<bool> IsExsistAttrbiute(int id)
        {
            return await _dbSet.AnyAsync(a => a.Id == id);
        }

        public async Task<Attribute> updateAttrbiute(Attribute entityToUpadet)
        {
            try
            {
                var entry = _unitOfWork.Entry(entityToUpadet);
                var attachedEntity = _dbSet.Find(entityToUpadet.Id);
                if (attachedEntity != null)
                {
                    var attachedEntry = _unitOfWork.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entityToUpadet);
                    attachedEntry.State = EntityState.Modified;

                }
                else
                {
                    entry.State = EntityState.Modified;
                }

            }
            catch (Exception e)
            {
                _dbSet.Attach(entityToUpadet);
                _unitOfWork.Entry(entityToUpadet).State = EntityState.Modified;
            }

            await  _unitOfWork.SaveChangesAsync();
            return entityToUpadet;
        }

        public Attribute GetNodeAttribute(Attribute value)
        {
            return _dbSet.Include(a => a.subNodes).Where(p => p.Id == value.ParentId).FirstOrDefault();

        }

      
    }
}

