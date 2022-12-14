using backend.Entities;

namespace backend.Models.Students
{
    public class AuthenticateResponse
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string IsFirstLogin { get; set; }
        public string IsDiabled { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string ClassroomName { get; set; }
        public string Token { get; set; }
        public AuthenticateResponse(Student user, string token)
        {
            StudentId = user.StudentId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender.ToString();
            IsFirstLogin = user.IsFirstLogin.ToString();
            IsDiabled = user.IsDiabled.ToString();
            Role = user.Role.ToString();
            DateOfBirth = user.DateOfBirth;
            FullName = user.FullName;
            ClassroomName = user.ClassroomName;
            Token = token;
        }
    }
}