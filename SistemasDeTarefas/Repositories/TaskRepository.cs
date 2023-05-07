using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public TaskRepository(TaskSystemDBContext taskSystemDBContext) 
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetAllTask()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel TaskById = await GetTaskById(id);

            if(TaskById == null)
            {
                throw new Exception($"Can't find any Task by this Id: {id}");
            }

            TaskById.Name  = task.Name;
            TaskById.Description = task.Description;
            TaskById.Status = task.Status;
            TaskById.UserId = task.UserId;

            _dbContext.Update(TaskById);
            await _dbContext.SaveChangesAsync();

            return TaskById;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Can't find any Task by this Id: {id}");
            }

            _dbContext.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
