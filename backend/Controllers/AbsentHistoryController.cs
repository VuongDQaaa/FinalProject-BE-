using backend.Interfaces;
using backend.DTO;
using backend.Authorization;
using backend.AuthorizationStudent;
using backend.Enums;
using backend.Models.AbsentHistory;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbsentHistoryController : ControllerBase
    {
        private IAbsentHistoryService _service;
        public AbsentHistoryController(IAbsentHistoryService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Add-history")]
        public async Task AddAbsentHistory(int scheduleId, int teacherId, int studentId, UpdateReasonModel reason)
        {
            await _service.AddAbsentHistory(scheduleId, teacherId, studentId, reason);
        }

        [Authorize(Role.Teacher)]
        [HttpDelete("Delete-history/{historyId}")]
        public async Task DeleteHistory(int historyId)
        {
            await _service.DeleteHistory(historyId);
        }

        [AuthorizeAttributeStudent(Role.Student)]
        [HttpGet("Get-history-student/{studentId}")]
        public async Task<ActionResult<List<AbsentHistoryStudentDTO>>> GetAbsentHistoryByStudent(int studentId)
        {
            return await _service.GetAbsentHistoryStudent(studentId);
        }

        [Authorize(Role.Teacher)]
        [HttpGet("Get-history-teacher/{teacherId}")]
        public async Task<ActionResult<List<AbsentHistoryTeacherDTO>>> GetAbsentHistoryByTeacher(int teacherId)
        {
            return await _service.GetAbsentHistoryTeacher(teacherId);
        }

        [Authorize(Role.Teacher)]
        [HttpPut("Update-reason/{historyId}")]
        public async Task UpdateHistory(UpdateReasonModel model, int historyId)
        {
            await _service.UpdateHistory(model ,historyId);
        }
    }
}