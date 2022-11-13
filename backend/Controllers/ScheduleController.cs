using backend.Interfaces;
using backend.DTO;
using backend.Authorization;
using backend.AuthorizationStudent;
using backend.Enums;
using backend.Models.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _service;
        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Add-schedule")]
        public async Task AddSchedule(CreateScheduleModel scheduleModel, int classId)
        {
            await _service.AddSchedule(scheduleModel, classId);
        }

        [Authorize(Role.Admin)]
        [HttpGet("Get-Schedule/Classroom-id-{classroomId}")]
        public async Task<ActionResult<List<ClassroomScheduleDTO>>> GetScheduleByClassrroomId(int classroomId, int year, string week)
        {
            return await _service.GetSchedulesByClassroomId(classroomId, year, week);
        }

        [AuthorizeAttributeStudent(Role.Student)]
        [HttpGet("Get-schedule/student-id-{studentId}")]
        public async Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId, int year, string week)
        {
            return await _service.GetSchedulesByStudentId(studentId, year, week);
        }

        [Authorize(Role.Teacher)]
        [HttpGet("Get-Schedule/Teacher-id-{teacherId}")]
        public async Task<ActionResult<List<TeacherScheduleDTO>>> GetScheduleByTeacherId(int teacherId, int year, string week)
        {
            return await _service.GetSchedulesByTeacherId(teacherId, year, week);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("Delete-schedule/{scheduleId}")]
        public async Task DeleteSchedule(int scheduleId)
        {
            await _service.DeleteSchedule(scheduleId);
        }
    }
}