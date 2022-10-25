namespace backend.DTO
{
    public class ClassroomScheduleDTO
    {
        public int ScheduleId { get; set; }
        public string? Session { get; set; }
        public int Period { get; set; }
        public string? Day { get; set; }
        public string? AutoFill { get; set; }
    }
}