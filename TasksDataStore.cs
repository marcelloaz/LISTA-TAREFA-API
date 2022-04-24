using LISTA_TAREFA_API.Models;

namespace LISTA_TAREFA_API
{
    public class TasksDataStore
    {
        public List<TasksDto> Tasks { get; set; }
        public static TasksDataStore Current { get; set; } = new TasksDataStore();

        public TasksDataStore()
        {
            Tasks = new List<TasksDto>()
            {
                 new TasksDto(){ Id = 1, Name = "TASK 1", Cost = 12, LimitDate = DateTime.Now.AddMonths(1), Order = 1 },
                 new TasksDto(){ Id = 2, Name = "TASK 2", Cost = 14, LimitDate = DateTime.Now.AddMonths(2), Order = 2 },
                 new TasksDto(){ Id = 3, Name = "TASK 3", Cost = 16, LimitDate = DateTime.Now.AddMonths(3), Order = 3 }
            };
        }
    }
}
