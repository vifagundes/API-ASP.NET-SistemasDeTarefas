using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   

    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTask();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel task)
        {
            TaskModel newTask = await _taskRepository.AddTask(task);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel task, int id)
        {
            task.Id = id;
            TaskModel newTask = await _taskRepository.UpdateTask(task, id);
            return Ok(newTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete(int id)
        {
            bool IsDeleted = await _taskRepository.DeleteTask(id);
            return Ok(IsDeleted);                
        }
    }
}
