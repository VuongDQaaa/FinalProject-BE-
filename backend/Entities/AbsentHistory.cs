using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Enums;


namespace backend.Entities
{
    [Table("AbsentHistory")]
    public class AbsentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string StudentFullName { get; set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        public string TeacherFullName { get; set; }
        [Required]
        public string? ClassroomName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime AbsentDate { get; set; }
        public string? Reason { get; set; }
        [Required]
        public int Slot { get; set; }
        public Session Session { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}