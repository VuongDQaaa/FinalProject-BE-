using backend.DTO;
using backend.Entities;
using backend.Enums;

namespace backend.Utilities
{
    public static class Utility
    {
        public static UserDTO UserEntityToDTO(this User entity)
        {
            UserDTO result = new UserDTO
            {
                userId = entity.UserId,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                UserCode = entity.UserCode,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender.ToString(),
                IsFirstLogin = entity.IsFirstLogin.ToString(),
                IsDiabled = entity.IsDiabled.ToString(),
                Role = entity.Role.ToString(),
                DateOfBirth = entity.DateOfBirth,
                FullName = entity.FullName
            };
            return result;
        }
        public static StudentDTO StudentEntityToDTO(this Student entity)
        {
            StudentDTO result = new StudentDTO
            {
                StudentId = entity.StudentId,
                UserName = entity.UserName,
                PasswordHash = entity.PasswordHash,
                StudentCode = entity.StudentCode,
                ClassroomName = entity.ClassroomName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender.ToString(),
                IsFirstLogin = entity.IsFirstLogin.ToString(),
                IsDiabled = entity.IsDiabled.ToString(),
                Role = entity.Role.ToString(),
                DateOfBirth = entity.DateOfBirth,
                FullName = entity.FullName
            };
            return result;
        }
        public static ClassroomScheduleDTO ScheduleEntitytoClassroomDTO(this Schedule entity)
        {
            ClassroomScheduleDTO result = new ClassroomScheduleDTO
            {
                Session = entity.Session.ToString(),
                Period = entity.Period,
                Day = entity.Day.ToString(),
                AutoFill = entity.AutoFillClassroom
            };
            return result;
        }

        public static TeacherScheduleDTO ScheduleEntitytoTeacherDTO(this Schedule entity)
        {
            TeacherScheduleDTO result = new TeacherScheduleDTO
            {
                Session = entity.Session.ToString(),
                Period = entity.Period,
                Day = entity.Day.ToString(),
                AutoFill = entity.AutoFillTeacher
            };
            return result;
        }
    }
}