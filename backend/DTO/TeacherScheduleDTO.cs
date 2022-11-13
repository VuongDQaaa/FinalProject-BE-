namespace backend.DTO
{
    public class TeacherScheduleDTO
    {
        public int ScheduleId { get; set; }
        public int ClassroomId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string? Session { get; set; }
        public int Period { get; set; }
        public string? Day { get; set; }
        public string? AutoFill { get; set; }
    }
}