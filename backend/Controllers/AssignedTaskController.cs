using backend.Interfaces;
using backend.Entities;
using backend.Models.AsignedTasks;
using backend.Authorization;
using backend.Enums;
using Microsoft.AspNetCore.Mvc;
using backend.DTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignedTaskController : ControllerBase
    {
        private IAssignedTaskService _service;
        public AssignedTaskController(IAssignedTaskService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Add-task")]
        public async Task AddTask(CreateTaskModel taskModel)
        {
            await _service.AddTask(taskModel);
        }

        [Authorize(Role.Admin)]
        [HttpGet("All-tasks")]
        public async Task<List<AssignedTask>> GetAllAssignedTask()
        {
           return await _service.GetAllAssignedTask();
        }

        [Authorize(Role.Admin)]
        [HttpGet("detail-task/{taskId}")]
        public async Task<AssignedTask> GetTaskById(int taskId)
        {
            return await _service.GetTaskById(taskId);
        }

        [Authorize(Role.Admin)]
        [HttpGet("get-task/teacher-{teacherId}")]
        public async Task<ActionResult<List<AssignedTaskDTO>>> GetAssignedTasksByTeacherId(int teacherId)
        {
            return await _service.GetAssignedTasksByTeacherId(teacherId);
        }

        [Authorize(Role.Admin)]
        [HttpPut("Update-task/{taskId}")]
        public async Task UpdateTask(CreateTaskModel taskModel, int taskId)
        {
            await _service.UpdateTask(taskModel, taskId);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("Delete-task/{taskId}")]
        public async Task DeleteTask(int taskId)
        {
            await _service.DeleteTask(taskId);
        }
    }
}