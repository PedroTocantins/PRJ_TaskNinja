using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNinja.Domain.Core.Data
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        Task<TEntity> GetById(TKey Id);
        void Update(TEntity entity);
        Task<IQueryable<TEntity>> GetAll();
        void Delete(TEntity entity);
        IUnitOfWork UnitOfWork { get; }
    }
}
