using backend.Authorization;
using backend.Helpers;
using backend.Interfaces;
using backend.Repositories;
using backend.Models.Students;
using Microsoft.Extensions.Options;
using backend.Data;
using backend.Entities;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        private MyDbContext _context;
        private IJwtUtils _jwtUtilsStudent;
        private readonly AppSettings _appSettings;
        public StudentService(
            MyDbContext context,
            IStudentRepository repository,
            IJwtUtils jwtUtilsStudent,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _repository = repository;
            _jwtUtilsStudent = jwtUtilsStudent;
            _appSettings = appSettings.Value;
        }
        public Models.Students.AuthenticateResponse Authenticate(Models.Students.AuthenticateStudentRequest model)
        {
            var student = _context.Students.SingleOrDefault(x => x.UserName == model.UserName);
            // validate
            if (student == null || !BCrypt.Net.BCrypt.Verify(model.Password, student.PasswordHash))
                throw new AppException("Username or password is incorrect. Please try again");
            // When account have been disable    
            if (student.IsDiabled == true) throw new AppException("This account has been disabled");
            // authentication successful so generate jwt token
            var jwtToken = _jwtUtilsStudent.GenerateStudentJwtToken(student);

            return new AuthenticateResponse(student, jwtToken);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public async Task<List<StudentDTO>> GetAllActiveStudent()
        {
            return await _repository.GetAllActiveStudent();
        }

        public Student GetById(int id)
        {
            var student = _context.Students.Find(id);
            return student;
        }

        public async Task AddStudent(CreateStudentModel studentModel)
        {
            await _repository.AddStudent(studentModel);
        }

        public async Task UpdateStudent(UpdateStudentModel studentModel, int studentId)
        {
            await _repository.UpdateStudent(studentModel, studentId);
        }

        public async Task DisableStudent(int id)
        {
            await _repository.DisableStudent(id);
        }

        public async Task ChangePasswordFirstLogin(StudentFirstLoginModel login)
        {
            await _repository.ChangePasswordFirstLogin(login);
        }

        public async Task ChangePassWord(UpdatePasswordModel changePassword)
        {
            await _repository.ChangePassWord(changePassword);
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _repository.GetStudentById(studentId);
        }

        public async Task<ActionResult<List<StudentListDTO>>> GetStudentByClassroomId(int classroomId)
        {
            return await _repository.GetStudentByClassroomId(classroomId);
        }
    }
}