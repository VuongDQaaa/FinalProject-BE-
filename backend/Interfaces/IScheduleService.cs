using backend.DTO;
using backend.Models.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IScheduleService
    {
        public Task AddSchedule(CreateScheduleModel scheduleModel, int classroomId);
        public Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId, int year, string week);
        public Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId, int year, string week);
        public Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId, int year, string week);
        public Task DeleteSchedule(int scheduleId);
    }
}