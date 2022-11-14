namespace backend.DTO
{
    public class AbsentHistoryStudentDTO
    {
        public DateTime CreatedDate { get; set; }
        public DateTime AbsentDate { get; set; }
        public string? Session { get; set; }
        public int Slot { get; set; }
        public string? SubjectName { get; set; }
        public string? TeacherFullName { get; set; }
        public string? Reason { get; set; }
    }
}