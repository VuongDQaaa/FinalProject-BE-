using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Enums;

namespace backend.Entities
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        public Session Session { get; set; }
        [Required]
        public int Period { get; set; }
        [Required]
        public Day Day { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string AutoFillClassroom { get; set; }
        [Required]
        public string AutoFillTeacher { get; set; }
        [Required]
        public int ClassroomId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual AssignedTask AssignedTask { get; set; }
    }
}