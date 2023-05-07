using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTask();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel user);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
