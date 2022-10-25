using backend.Entities;
using backend.DTO;
using backend.Models.Students;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IStudentService
    {
        AuthenticateResponse Authenticate(AuthenticateStudentRequest model);
        public IEnumerable<Student> GetAll();
        public Student GetById(int id);
        public Task<List<StudentDTO>> GetAllActiveStudent();
        public Task<Student> GetStudentById(int studentId);
        public Task<ActionResult<List<StudentListDTO>>> GetStudentByClassroomId(int classroomId);
        public Task AddStudent(CreateStudentModel studentModel);
        public Task UpdateStudent(UpdateStudentModel studentModel, int studentId);
        public Task DisableStudent(int id);
        public Task ChangePasswordFirstLogin(StudentFirstLoginModel login);
        public Task ChangePassWord(UpdatePasswordModel changePassword);
    }
}