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
        [HttpPut("Update-schedule")]
        public async Task UpdateSchedule(UpdateScheduleModel scheduleModel, int scheduleId)
        {
            await _service.UpdateSchedule(scheduleModel, scheduleId);
        }

        [AuthorizeAttributeStudent(Role.Student)]
        [HttpGet("Get-Schedule/Classroom-id-{classroomId}")]
        public async Task<ActionResult<List<ClassroomScheduleDTO>>> GetScheduleByClassrroomId(int classroomId)
        {
            return await _service.GetSchedulesByClassroomId(classroomId);
        }

        [Authorize(Role.Teacher)]
        [HttpGet("Get-Schedule/Teacher-id-{teacherId}")]
        public async Task<ActionResult<List<TeacherScheduleDTO>>> GetScheduleByTeacherId(int teacherId)
        {
            return await _service.GetSchedulesByTeacherId(teacherId);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("Delete-schedule/{scheduleId}")]
        public async Task DeleteSchedule(int scheduleId)
        {
            await _service.DeleteSchedule(scheduleId);
        }
    }
}