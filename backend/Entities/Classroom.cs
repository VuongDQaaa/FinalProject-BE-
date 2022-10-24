using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    [Table("Classroom")]
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public string ClassroomName { get; set; }
        [Required]
        public int StartYear { get; set; }
        [Required]
        public int EndYear { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}