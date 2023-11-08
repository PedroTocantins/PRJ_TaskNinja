using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Core.Data;

namespace TaskNinja.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
