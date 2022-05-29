using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitis
{
    [Table("Tasks")]
    public class ToDoTask : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? DeadLine { get; set; }

        public ToDoTask()
        {

        }

        public ToDoTask(int id, string title, string description, DateTime deadLine)
        {
            (Id, Title, Description, DeadLine) = (id, title, description, deadLine);
        }
    }
}
