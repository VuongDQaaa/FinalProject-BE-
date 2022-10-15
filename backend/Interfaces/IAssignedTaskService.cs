using backend.Entities;
using backend.Models.AsignedTasks;

namespace backend.Interfaces
{
    public interface IAssignedTaskService
    {
        public Task AddTask(CreateTaskModel taskModel);
        public Task UpdateTask(CreateTaskModel taskModel, int taskId);
        public Task DeleteTask(int taskId);
        public Task<List<AssignedTask>> GetAllAssignedTask();
        public Task<AssignedTask> GetTaskById(int taskId);
    }
}