using System.ComponentModel.DataAnnotations;

namespace LISTA_TAREFA_API.Models
{
    public class TasksDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Informe o nome da tarefa")]
        [MaxLength(100)]
        public string? Name { get; set; } = string.Empty;
        public decimal Cost { get; set; } = decimal.Zero;
        public DateTime LimitDate { get; set; } = DateTime.Now.AddDays(10);
        public int Order { get; set; } = 0;
    }
}
