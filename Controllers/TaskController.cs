using LISTA_TAREFA_API.Models;
using LISTA_TAREFA_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LISTA_TAREFA_API.Controllers
{
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskRepository taskRepo, ILogger<TasksController> logger)
        {
            _taskRepo = taskRepo;
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        // GET: TaskController
        [HttpGet("api/tasks")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TasksDto>>> GetTasks()
        {
            var tasks = await _taskRepo.GetTasksAsync();
            var results = new List<TasksDto>();

            foreach (var task in tasks)
            {
                results.Add(new TasksDto()
                { 
                    Id = task.Id, 
                    Name = task.Name, 
                    Cost = task.Cost, 
                    LimitDate = task.LimitDate, 
                    Order = task.Order 
                });
            }

            return Ok(results);
        }

     
        [HttpPost("api/tasks")]
        public async Task<ActionResult<TasksDto>> CreateTasks(
            int id,
            TasksDto taskDto)
        {  
            if (!await _taskRepo.TaskExistsAsync(id))
            {
                return NotFound();
            }

            var finalTaskt = new Entities.Task();
            finalTaskt.Id = taskDto.Id;
            finalTaskt.Order = taskDto.Order;
            finalTaskt.Name = taskDto.Name;
            finalTaskt.Cost = taskDto.Cost;
            finalTaskt.LimitDate = taskDto.LimitDate;

            await _taskRepo.AddTasksAsync(
                     id, finalTaskt);

            await _taskRepo.SaveChangesAsync();

            var tasksDto = new TasksDto();
            taskDto.Id = taskDto.Id;
            taskDto.Order = taskDto.Order;
            taskDto.Name = taskDto.Name;
            taskDto.Cost = taskDto.Cost;
            taskDto.LimitDate = taskDto.LimitDate;

            return CreatedAtRoute("api/tasks",
                 new
                 {
                     Id = id,
                     taskId = tasksDto.Id
                 },
                 tasksDto);
        }

        [HttpGet("api/tasks/{id}")]
        public ActionResult<TasksDto> GetTasks(int id)  
        {
            try
            {
                var task = TasksDataStore.Current.Tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    _logger.LogInformation($"A tarefa id {id} não foi localizada para busca do registro");
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Um exceção foi gerado ao tentar recuperar o registro de id: {id}", ex);
                return StatusCode(500, "Falha oa recuperar a tarefa");
            }
        }

      [HttpPut("api/tasks/{id}")]
      public async Task<ActionResult> TaskUpdate(int id, [FromBody] UpdateTasksDto patchDocument)
        {
            try
            {
                var result = await _taskRepo.GetTasksAsync(id);
                if (result == null)
                {
                    return NotFound();
                }

                await _taskRepo.UpdateTasksAsync(id, patchDocument);

                if (!ModelState.IsValid) { return BadRequest(); }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Um exceção foi gerado ao tentar recuperar o registro de id: {id}", ex);
                return StatusCode(500, "Falha oa recuperar a tarefa");
            }  
        }

      

    }
}
