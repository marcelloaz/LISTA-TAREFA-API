using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LISTA_TAREFA_API.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public DateTime LimitDate { get; set; }
        public int Order { get; set; }
    }
}
