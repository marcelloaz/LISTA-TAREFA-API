using LISTA_TAREFA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LISTA_TAREFA_API.Services
{
    public class TaskRepository : ITaskRepository
    {

        private readonly DbLTContext _context;

        public TaskRepository(DbLTContext context)
        {
             _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<Entities.Task?> GetTasksAsync(int id)
        {
            return await _context.Tasks
                  .Where(c => c.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<Entities.Task>> GetTasksAsync()
        {
            return await _context.Tasks.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<bool> TaskExistsAsync(int id)
        {
            return await _context.Tasks.AnyAsync(c => c.Id == id);
        }
     

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task AddTasksAsync(int id, Entities.Task task)
        {
            var result = await GetTasksAsync(id);
            if (result != null)
            {
                _context.Tasks.Add(task);
            }
        }

        public void DeleteTask(Entities.Task task)
        {
            _context.Tasks.Remove(task);
        }

        public async Task UpdateTasksAsync(int id, UpdateTasksDto task)
        {
            var result = await GetTasksAsync(id);
            result.Cost = task.Cost;
            result.Name = task.Name;
            result.Order = task.Order;
            result.LimitDate = task.LimitDate;

            _context.Tasks.Update(result);

            _context.SaveChanges();
        }

        //public async Task UpdateTasksAsync(int id, Entities.Task task)
        //{
        //    var result = await GetTasksAsync(id);
        //    if (result != null)
        //    {
        //        _context.Tasks.Add(task);
        //    }
        //}


    }
}
