namespace backend.DTO
{
    public class AbsentHistoryTeacherDTO
    {
        public int HistoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AbsentDate { get; set; }
        public string? Session { get; set; }
        public int Slot { get; set; }
        public string? ClassroomName { get; set; }
        public string? SubjectName { get; set; }
        public string? StudentFullName { get; set; }
        public string? StudentCode { get; set; }
        public string? Reason { get; set; }
    }
}