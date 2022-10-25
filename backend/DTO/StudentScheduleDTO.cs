namespace backend.DTO
{
    public class StudentScheduleDTO
    {
        public string? Session { get; set; }
        public int Period { get; set; }
        public string? Day { get; set; }
        public string? AutoFill { get; set; }
    }
}