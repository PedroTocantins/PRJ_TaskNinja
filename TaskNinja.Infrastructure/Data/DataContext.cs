using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Core.Data;
using TaskNinja.Domain.Models.TaskModel;

namespace TaskNinja.Infrastructure.Data
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
