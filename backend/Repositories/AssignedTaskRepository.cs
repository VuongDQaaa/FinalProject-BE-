using backend.Models.AsignedTasks;
using backend.Entities;
using backend.Data;
using backend.Helpers;
using backend.Enums;

namespace backend.Repositories
{
    public interface IAssignedTaskRepository
    {
        public Task AddTask(CreateTaskModel taskModel);
        public Task UpdateTask(CreateTaskModel taskModel, int taskId);
        public Task DeleteTask(int taskId);
        public Task<List<AssignedTask>> GetAllAssignedTask();
        public Task<AssignedTask> GetTaskById(int taskId);
    }
    public class AssignedTaskRepository : IAssignedTaskRepository
    {
        private MyDbContext _context;
        public AssignedTaskRepository(MyDbContext context)
        {
            _context = context;
        }

        private bool CheckValidTeacher(string userName)
        {
            var foudTeacher = _context.Users.FirstOrDefault(a => a.UserName == userName
                                                        && a.Role == Role.Teacher
                                                        && a.IsDiabled != true);
            if (foudTeacher == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckExistedTask(string userName, string subjectName)
        {
            var foudAssignedTask = _context.Tasks.FirstOrDefault(a => a.UserName == userName
                                                            && a.SubjectName == subjectName);
            if (foudAssignedTask != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task AddTask(CreateTaskModel taskModel)
        {
            if (!CheckValidTeacher(taskModel.UserName)) throw new AppException("Teacher not found");
            if (CheckExistedTask(taskModel.UserName, taskModel.SubjectName)) throw new AppException("This task have been created");
            try
            {
                var foudTeacher = _context.Users.FirstOrDefault(a => a.UserName == taskModel.UserName);
                var foudSubject = _context.Subjects.FirstOrDefault(a => a.SubjectName == taskModel.SubjectName);
                if(foudSubject == null) throw new AppException("Subject not found");
                if (foudTeacher != null && foudSubject != null)
                {
                    var newTask = new AssignedTask
                    {
                        UserId = foudTeacher.UserId,
                        UserName = taskModel.UserName,
                        SubjectId = foudSubject.SubjectId,
                        SubjectName = taskModel.SubjectName,
                        AutoFill = taskModel.SubjectName + "-" + taskModel.UserName
                    };
                    await _context.Tasks.AddAsync(newTask);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteTask(int taskId)
        {
            try
            {
                var foudAssignedTask = await _context.Tasks.FindAsync(taskId);
                if (foudAssignedTask != null)
                {
                    _context.Tasks.Remove(foudAssignedTask);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AssignedTask>> GetAllAssignedTask()
        {
            return _context.Tasks.ToList();
        }

        public async Task<AssignedTask> GetTaskById(int taskId)
        {
            var foudAssignedTask = await _context.Tasks.FindAsync(taskId);
            if (foudAssignedTask != null)
            {
                return foudAssignedTask;
            }
            else
            {
                throw new AppException("This class is not exist");
            }
        }

        public async Task UpdateTask(CreateTaskModel taskModel, int taskId)
        {
            if (!CheckValidTeacher(taskModel.UserName)) throw new AppException("Teacher not found");
            if (CheckExistedTask(taskModel.UserName, taskModel.SubjectName)) throw new AppException("This task have been created");
            try
            {
                var foudTeacher = _context.Users.FirstOrDefault(a => a.UserName == taskModel.UserName);
                var foudSubject = _context.Subjects.FirstOrDefault(a => a.SubjectName == taskModel.SubjectName);
                if(foudSubject == null) throw new AppException("Subject not found");
                var foudAssignedTask = await _context.Tasks.FindAsync(taskId);
                if (foudTeacher != null
                    && foudSubject != null
                    && foudAssignedTask != null)
                {
                    foudAssignedTask.UserId = foudTeacher.UserId;
                    foudAssignedTask.UserName = taskModel.UserName;
                    foudAssignedTask.SubjectId = foudSubject.SubjectId;
                    foudAssignedTask.SubjectName = taskModel.SubjectName;
                    foudAssignedTask.AutoFill = taskModel.SubjectName + "-" + taskModel.UserName;

                    _context.Tasks.Update(foudAssignedTask);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}