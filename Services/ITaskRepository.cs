using LISTA_TAREFA_API.Models;

namespace LISTA_TAREFA_API.Services
{
    public interface ITaskRepository
    {
        Task<List<Entities.Task>> GetTasksAsync();
        Task<Entities.Task> GetTasksAsync(int id);
        Task<bool> TaskExistsAsync(int id);
        Task AddTasksAsync(int id, Entities.Task task);

        Task UpdateTasksAsync(int id, UpdateTasksDto task);
        void DeleteTask(Entities.Task task);
        Task<bool> SaveChangesAsync();

    }
}