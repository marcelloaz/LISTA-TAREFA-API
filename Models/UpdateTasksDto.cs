using System.ComponentModel.DataAnnotations;

namespace LISTA_TAREFA_API.Models
{
    public class UpdateTasksDto
    {
        [Required(ErrorMessage = "Informe o nome da tarefa")]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime LimitDate { get; set; }
        public int Order { get; set; }
    }
}
