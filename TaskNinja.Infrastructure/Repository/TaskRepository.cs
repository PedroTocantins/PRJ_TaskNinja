using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Models.TaskModel;
using TaskNinja.Infrastructure.Data;

namespace TaskNinja.Infrastructure.Repository
{
    public class TaskRepository : Repository<TaskModel, Guid>, ITaskRepository
    {
        public TaskRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
