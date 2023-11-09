using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class DataContext : IdentityDbContext<IdentityUser>, IUnitOfWork
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
