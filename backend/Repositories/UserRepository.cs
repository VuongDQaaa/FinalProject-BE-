using backend.Data;
using backend.DTO;
using backend.Entities;
using backend.Enums;
using backend.Helpers;
using backend.Models.Users;
using backend.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(CreateUserModel user);
        public Task UpdateUser(UpdateUserModel user, int userId);
        public Task DisableUser(int id);
        public Task ChangePasswordFirstLogin(FirstLoginModel login);
        public Task ChangePassWord(ChangePasswordModel changePassword);
        public Task<List<UserDTO>> GetAllActiveUser();
        public Task<ActionResult<List<SearchTeacherDTO>>> SearchTeacher(string scheduleDate, string session, string day, int period);
        public Task<ActionResult<List<SearchTeacherDTO>>> SearchTeacherTask();
        public Task<User> GetUserById(int id);
    }
    public class UserRepository : IUserRepository
    {
        private MyDbContext _context;

        public UserRepository(MyDbContext context, IAssignedTaskRepository repository)
        {
            _context = context;
        }

        private Session SessionConverter(string inputValue)
        {
            if (inputValue == "morning")
            {
                return Session.Morning;
            }
            else
            {
                return Session.Afternoon;
            }
        }

        private Day DayConverter(string inputValue)
        {
            if (inputValue == "monday")
            {
                return Day.Monday;
            }
            else if (inputValue == "tuesday")
            {
                return Day.Tuesday;
            }
            else if (inputValue == "wednesday")
            {
                return Day.Wednesday;
            }
            else if (inputValue == "thursday")
            {
                return Day.Thursday;
            }
            else if (inputValue == "friday")
            {
                return Day.Friday;
            }
            else
            {
                return Day.Saturday;
            }
        }

        private bool checkValidPassowrd(string password)
        {
            int countSpace = 0;
            string str1;
            for (int i = 0; i < password.Length; i++)
            {
                str1 = password.Substring(i, 1);
                if (str1 == " ")
                    countSpace++;
            }

            if (countSpace > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckDateOfBirth(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GenerateUserName(string? firstname, string? lastname)
        {
            var prefix = "";
            var postfix = "";
            if (lastname == null)
            {
                prefix = "";
            }
            else
            {
                var lastnames = lastname.Trim().Split(' ');
                foreach (var fn in lastnames)
                {
                    prefix += fn.Trim();
                }
            }

            if (firstname == null)
            {
                postfix = "";
            }
            else
            {
                var firstnames = firstname.Trim().Split(' ');
                foreach (var ln in firstnames)
                {
                    if (ln != "") postfix += ln.Trim().Substring(0, 1);
                }
            }

            var rawusername = (prefix + postfix).ToLower();

            //generate code
            var checkInUserTable = _context.Users.Any(o => o.UserName.Equals(rawusername));
            if (checkInUserTable)
            {
                var postNumber = 0;
                var flag = true;
                var username = "";
                do
                {
                    postNumber++;
                    username = rawusername + postNumber.ToString();
                    flag = CheckUsernameDb(username);
                } while (flag);
                return username;
            }
            else
            {
                return rawusername;
            }
        }

        private bool CheckUsernameDb(string username)
        {
            var checkInUserTable = _context.Users.Any(o => o.UserName.Equals(username));
            if (checkInUserTable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenerateStaffCode(CreateUserModel userModel)
        {
            var userId = "";
            var lastUserId = _context.Users?.OrderByDescending(o => o.UserId).FirstOrDefault()?.UserId + 1;
            if (userModel.Role == "Admin")
            {
                userId = "AD" + String.Format("{0,0:D4}", lastUserId++);
            }
            if (userModel.Role == "Teacher")
            {
                userId = "TC" + String.Format("{0,0:D4}", lastUserId++);
            }
            return userId;
        }

        private string GeneratePassword(string username)
        {
            return username + "@123456";
        }

        public async Task<User> GetUserById(int id)
        {
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser != null)
            {
                return foundUser;
            }
            return null;
        }

        public async Task<List<UserDTO>> GetAllActiveUser()
        {
            var users = _context.Users.Where(x => x.IsDiabled == false);
            if (users != null)
            {
                return await users.Select(x => x.UserEntityToDTO()).ToListAsync();
            }
            return null;
        }

        public async Task AddUser(CreateUserModel user)
        {
            var username = GenerateUserName(user.FirstName, user.LastName);
            DateTime dateTimeParseResult;
            try
            {
                if (!CheckDateOfBirth(user.DateOfBirth))
                {
                    throw new AppException("Date of birth is in the future");
                }
                if (DateTime.Now.Year - user.DateOfBirth.Year < 18)
                {
                    throw new AppException("User is under 18. Please select a different date");
                }
                var newUser = new User
                {
                    UserName = username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(GeneratePassword(username)),
                    UserCode = GenerateStaffCode(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = !user.Gender.Equals("Male") ? Gender.Female : Gender.Male,
                    IsFirstLogin = true,
                    IsDiabled = false,
                    Role = !user.Role.Equals("Teacher") ? Role.Admin : Role.Teacher,
                    DateOfBirth = user.DateOfBirth
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateUser(UpdateUserModel user, int userId)
        {
            try
            {
                if (!CheckDateOfBirth(user.DateOfBirth))
                {
                    throw new AppException("Date of birth is in the future");
                }
                if (DateTime.Now.Year - user.DateOfBirth.Year < 18)
                {
                    throw new AppException("User is under 18. Please select a different date");
                }
                var foundUser = await _context.Users.FindAsync(userId);
                if (foundUser != null)
                {
                    foundUser.FirstName = user.FirstName;
                    foundUser.LastName = user.LastName;
                    foundUser.DateOfBirth = user.DateOfBirth;
                    foundUser.Gender = !user.Gender.Equals("Male") ? Gender.Female : Gender.Male;
                    foundUser.Role = !user.Role.Equals("Admin") ? Role.Teacher : Role.Admin;

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DisableUser(int id)
        {
            try
            {
                //Auto remove any Schedule relatec to thus disabled user
                var foundSchedules = _context.Schedules.Where(x => x.UserId == id);
                if (foundSchedules != null)
                {
                    _context.Schedules.RemoveRange(foundSchedules);
                    await _context.SaveChangesAsync();
                }
                //Auto remove any Assigned tasks related to this disabled user
                var foundAssignedTasks = _context.Tasks.Where(x => x.UserId == id);
                if (foundAssignedTasks != null)
                {
                    _context.Tasks.RemoveRange(foundAssignedTasks);
                    await _context.SaveChangesAsync();
                }

                var foundUser = await _context.Users.FindAsync(id);
                if (foundUser != null)
                {
                    foundUser.IsDiabled = true;
                    _context.Update(foundUser);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ChangePasswordFirstLogin(FirstLoginModel login)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(x => x.UserName == login.UserName);
                if (BCrypt.Net.BCrypt.Verify(login.NewPassword, foundUser.PasswordHash)) throw new AppException("New password has to be different from old password");
                if (login.NewPassword.Length > 255) throw new AppException("Your password should less than 255 chatacters");
                if (login.NewPassword.Length < 8) throw new AppException("Your password should more than 8 chatacters");
                if (!checkValidPassowrd(login.NewPassword)) throw new AppException("Password should not have any space");
                if (login.NewPassword != login.ConfirmPassword) throw new AppException("Confirm Password is wrong");
                if (foundUser.IsFirstLogin == false) throw new AppException("This is not your first login");
                if (foundUser != null

                    && login.NewPassword.Length >= 8
                    && login.NewPassword.Length < 255)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(login.NewPassword);
                    foundUser.IsFirstLogin = false;

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ChangePassWord(ChangePasswordModel changePassword)
        {
            try
            {
                var foundUser = _context.Users.FirstOrDefault(user => user.UserName == changePassword.UserName);
                if (!BCrypt.Net.BCrypt.Verify(changePassword.OldPassword, foundUser.PasswordHash)) throw new AppException("Wrong old password");
                if (changePassword.OldPassword == changePassword.NewPassword) throw new AppException("New password has to be different from old password");
                if (changePassword.NewPassword.Length > 255) throw new AppException("Password should less than 255 characters");
                if (changePassword.NewPassword.Length < 8) throw new AppException("Password should have more than 8 characters");
                if (!checkValidPassowrd(changePassword.NewPassword)) throw new AppException("Password should not have any space");
                if (changePassword.NewPassword != changePassword.ConfirmPassword) throw new AppException("Confirm Password is wrong");
                if (foundUser != null)
                {
                    foundUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);

                    _context.Users.Update(foundUser);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<SearchTeacherDTO>>> SearchTeacher(string scheduleDate, string session, string day, int period)
        {
            if (_context.Users != null)
            {
                try
                {
                    string[] date = scheduleDate.Split('-');
                    string newDate = date[0] + "/" + date[1] + "/" + date[2];
                    var teachers = await _context.Users.Where(user => user.IsDiabled == false
                                                                    && user.Role == Role.Teacher
                                                                    && user.Schedules.FirstOrDefault(a => a.ScheduleDate == DateTime.ParseExact(newDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                                                                                            && a.Session == SessionConverter(session)
                                                                                                            && a.Day == DayConverter(day)
                                                                                                            && a.Period == period) == null)
                                                        .Select(teacher => teacher.TeacherEntityToDTO())
                                                        .ToListAsync();
                    return new OkObjectResult(teachers);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<List<SearchTeacherDTO>>> SearchTeacherTask()
        {
            if (_context.Users != null)
            {
                try
                {
                    var teachers = await _context.Users.Where(user => user.IsDiabled == false
                                                                    && user.Role == Role.Teacher)
                                                        .Select(teacher => teacher.TeacherEntityToDTO())
                                                        .ToListAsync();
                    return new OkObjectResult(teachers);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }
    }
}