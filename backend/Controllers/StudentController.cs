using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.Enums;
using backend.Models.Students;
using backend.Authorization;
using backend.AuthorizationStudent;
using backend.Entities;
using backend.DTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        private IStudentService _service;
        public StudentController(IStudentService service, IStudentService studentService)
        {
            _service = service;
            _studentService = studentService;
        }

        [AllowAnonymousAttribute]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateStudentRequest model)
        {
            var response = _service.Authenticate(model);
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet("all-student")]
        public IActionResult GetAll()
        {
            var users = _studentService.GetAll();
            return Ok(users);
        }

        [Authorize(Role.Admin)]
        [HttpGet("GetAllActiveStudent")]
        public async Task<List<StudentDTO>> GetAllActiveStudent()
        {
            return await _service.GetAllActiveStudent();
        }

        [Authorize(Role.Admin)]
        [HttpGet("student-detail/{studentId}")]
        public async Task<Student> GetStudentById(int studentId)
        {
            return await _service.GetStudentById(studentId);
        }

        [Authorize(Role.Teacher)]
        [HttpGet("student-list/classroom-{classroomId}")]
        public async Task<ActionResult<List<StudentListDTO>>> GetStudentByClassroomId(int classroomId)
        {
            return await _service.GetStudentByClassroomId(classroomId);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Add")]
        public async Task AddStudent([FromBody] CreateStudentModel studentModel)
        {
            await _service.AddStudent(studentModel);
        }

        [Authorize(Role.Admin)]
        [HttpPut("Update/{studentId}")]
        public async Task UpdateStudent([FromBody] UpdateStudentModel studentModel, int studentId)
        {
            await _service.UpdateStudent(studentModel, studentId);
        }

        [AuthorizeAttributeStudent(Role.Student)]
        [HttpPut("Change-password-student")]
        public async Task ChangePassword(UpdatePasswordModel changePassword)
        {
            await _service.ChangePassWord(changePassword);
        }

        [AuthorizeAttributeStudent(Role.Student)]
        [HttpPut("First-login-student")]
        public async Task ChangePasswordFirstLogin(StudentFirstLoginModel login)
        {
            await _service.ChangePasswordFirstLogin(login);
        }

        [Authorize(Role.Admin)]
        [HttpPut("Diable/{studentId}")]
        public async Task DisableStudent(int studentId)
        {
            await _service.DisableStudent(studentId);
        }
    }
}