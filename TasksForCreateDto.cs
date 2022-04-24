using System.ComponentModel.DataAnnotations;

namespace LISTA_TAREFA_API
{
    public class TasksForCreateDto
    {
        [Required(ErrorMessage = "Informe um título para a tarefa.")]
        [MaxLength(100)]

        public string? Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public DateTime LimitDate { get; set; }
    }
}
