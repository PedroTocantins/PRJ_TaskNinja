using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Core.Data;

namespace TaskNinja.Domain.Models.TaskModel
{
    public interface ITaskRepository : IRepository<TaskModel, Guid>
    {
    }
}
