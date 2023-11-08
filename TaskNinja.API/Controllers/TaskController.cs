using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskNinja.Domain.Core.Data;
using TaskNinja.Domain.Models.TaskModel;
using TaskNinja.Domain.ViewModels;

namespace TaskNinja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allTasks = await _taskRepository.GetAll();
            if(allTasks == null)
            {
                return NotFound();
            }

            return Ok(allTasks);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var selectedTask = await _taskRepository.GetById(Id);
            if(selectedTask == null)
            {
                return NotFound();
            }
            return Ok(selectedTask);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskViewModel request)
        {
            if (request == null)
            {
                return BadRequest("O objeto de solicitação é nulo");
            }

            var map = _mapper.Map<TaskModel>(request);
            _taskRepository.Create(map);    
            await _unitOfWork.SaveChangesAsync();

            var resposeViewModel = _mapper.Map<TaskViewModel>(map);
            return Ok(resposeViewModel);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(Guid Id, [FromBody] TaskViewModel request)
        {
            var existentTask = await _taskRepository.GetById(Id);

            if (existentTask == null)
            {
                return BadRequest("O objeto de solicitação é nulo");
            }

            var map = _mapper.Map(request, existentTask);

            _taskRepository.Update(existentTask);
            await _unitOfWork.SaveChangesAsync();

            return Ok(map);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var taskToDelete = await _taskRepository.GetById(Id);

            if (taskToDelete == null)
            {
                return BadRequest("O objeto de solicitação é nulo");
            }

            _taskRepository.Delete(taskToDelete);
            await _unitOfWork.SaveChangesAsync();

            return Ok("Task deletada com sucesso");
        }
    }
}
