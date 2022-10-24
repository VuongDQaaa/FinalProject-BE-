using backend.DTO;
using backend.Entities;
using backend.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public Task<List<UserDTO>> GetAllActiveUser();
        public Task AddUser(CreateUserModel user);
        public Task UpdateUser(UpdateUserModel user, int userId);
        public Task DisableUser(int id);
        public Task ChangePasswordFirstLogin(FirstLoginModel login);
        public Task ChangePassWord(ChangePasswordModel changePassword);
        public Task<ActionResult<List<SearchTeacherDTO>>> SearchTeacher();
    }
}