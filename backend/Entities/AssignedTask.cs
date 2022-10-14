using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("AssignedTask")]
    public class AssignedTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string AutoFill { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }
        public virtual User Teacher { get; set; }
    }
}