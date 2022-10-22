namespace backend.Models.Schedule
{
    public class CreateScheduleModel
    {
        public string Session { get; set; }
        public int Period { get; set; }
        public string Day { get; set; }
        public string UserName { get; set; }
        public int TaskId { get; set; }
    }
}