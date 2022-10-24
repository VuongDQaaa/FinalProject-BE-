using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public virtual ICollection<AssignedTask> AssignedTasks { get; set; }
    }
}