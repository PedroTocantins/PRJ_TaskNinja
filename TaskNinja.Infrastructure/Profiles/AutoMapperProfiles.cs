using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNinja.Domain.Models.TaskModel;
using TaskNinja.Domain.ViewModels;

namespace TaskNinja.Infrastructure.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<TaskViewModel, TaskModel>().ReverseMap();
        }
    }
}
