namespace backend.DTO
{
    public class UserDTO
    {
        public int userId { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? UserCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? IsFirstLogin { get; set; }
        public string? IsDiabled { get; set; }
        public string? Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? FullName { get; set; }
    }
}