using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : DomainEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await  _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            var entityToDelete = _dbSet.Find(entity.Id);

            if (entityToDelete == null)
                return;

            _dbSet.Remove(entityToDelete);

            _unitOfWork.SaveChanges();
        }

        public async Task DeleteById(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete == null)
                return;

            _dbSet.Remove(entityToDelete);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstAsync();

        }

        public async Task Update(TEntity entity)
        {
            try
            {
                var entry = _unitOfWork.Entry(entity);

                var attachedEntity = _dbSet.Find(entity.Id);
                if (attachedEntity != null)
                {
                    var attachedEntry = _unitOfWork.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                    attachedEntry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Modified;
                }

            }
            catch
            {
                _dbSet.Attach(entity);
                _unitOfWork.Entry(entity).State = EntityState.Modified;
            }

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<TEntity> FindById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }
    }
}

  
