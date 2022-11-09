using backend.DTO;
using backend.Models.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IScheduleService
    {
        public Task AddSchedule(CreateScheduleModel scheduleModel, int classroomId);
        public Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId);
        public Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId);
        public Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId);
        public Task DeleteSchedule(int scheduleId);
    }
}