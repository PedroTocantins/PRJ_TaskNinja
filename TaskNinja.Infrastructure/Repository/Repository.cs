using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Core.Data;
using TaskNinja.Infrastructure.Data;

namespace TaskNinja.Infrastructure.Repository
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DataContext _dataContext;
        protected DbSet<TEntity> _entity;
        public IUnitOfWork UnitOfWork => _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _entity = _dataContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _entity.Add(entity);
        }

        public void Delete(TEntity entity)
        {
             _entity.Remove(entity);

        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _entity;
        }

        public async Task<TEntity> GetById(TKey Id)
        {
            return await _entity.FindAsync(Id);
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return result;
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
