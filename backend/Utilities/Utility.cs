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
                ScheduleId = entity.ScheduleId,
                Session = entity.Session.ToString(),
                Period = entity.Period,
                Day = entity.Day.ToString(),
                AutoFill = entity.AutoFillClassroom
            };
            return result;
        }

        public static StudentScheduleDTO ScheduleEntitytoStudentDTO(this Schedule entity)
        {
            StudentScheduleDTO result = new StudentScheduleDTO
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
                ScheduleId = entity.ScheduleId,
                ClassroomId = entity.ClassroomId,
                Session = entity.Session.ToString(),
                Period = entity.Period,
                Day = entity.Day.ToString(),
                AutoFill = entity.AutoFillTeacher
            };
            return result;
        }

        public static AbsentHistoryStudentDTO HistoryStudentToDTO(this AbsentHistory entity)
        {
            AbsentHistoryStudentDTO result = new AbsentHistoryStudentDTO
            {
                CreatedDate = entity.CreatedDate,
                SubjectName = entity.SubjectName,
                TeacherFullName = entity.TeacherFullName,
                Reason = entity.Reason
            };
            return result;
        }

        public static AbsentHistoryTeacherDTO HistoryTeacherToDTO(this AbsentHistory entity)
        {
            AbsentHistoryTeacherDTO result = new AbsentHistoryTeacherDTO
            {
                CreatedDate = entity.CreatedDate,
                ClassroomName = entity.ClassroomName,
                StudentFullName = entity.StudentFullName,
                StudentCode = entity.StudentCode,
                Reason = entity.Reason,
            };
            return result;
        }

        public static SearchTeacherDTO TeacherEntityToDTO(this User entity)
        {
            SearchTeacherDTO result = new SearchTeacherDTO
            {
                UserId = entity.UserId,
                Suggestion = entity.UserCode + " - " + entity.FullName + " - " + entity.UserName
            };
            return result;
        }

        public static AssignedTaskDTO AssignedTaskEntityToDTO(this AssignedTask entity)
        {
            AssignedTaskDTO result = new AssignedTaskDTO
            {
                TaskId = entity.TaskId,
                SubjectName = entity.SubjectName,
                AutoFill = entity.AutoFill
            };
            return result;
        }

        public static StudentListDTO StudentListEntityToDTO(this Student entity)
        {
            StudentListDTO result = new StudentListDTO
            {
                StudentId = entity.StudentId,
                StudentCode = entity.StudentCode,
                StudentFullName = entity.FullName
            };
            return result;
        }
    }
}