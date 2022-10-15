using backend.Authorization;
using backend.Enums;
using backend.Interfaces;
using backend.Entities;
using backend.Models.Subject;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [Authorize(Role.Admin)]
        [HttpPost("Add-subject")]
        public async Task AddSubject(CreateSubjectModel subjectModel)
        {
            await _service.AddSubject(subjectModel);
        }

        [Authorize(Role.Admin)]
        [HttpGet("All-subjects")]
        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _service.GetAllSubjects();
        }

        [Authorize(Role.Admin)]
        [HttpGet("detail-subject/{subjectId}")]
        public async Task<Subject> GetSubjectById (int subjectId)
        {
            return await _service.GetSubjectById(subjectId);
        }

        [Authorize(Role.Admin)]
        [HttpPut("Update-subject/{subjectId}")]
        public async Task UpdateSubject(CreateSubjectModel subjectModel, int subjectId)
        {
            await _service.UpdateSubject(subjectModel, subjectId);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("Delete-subject/{subjectId}")]
        public async Task DeleteSubject(int subjectId)
        {
            await _service.DeleteSubject(subjectId);
        }
    }
}