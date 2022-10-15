using backend.Interfaces;
using backend.Repositories;
using backend.Entities;
using backend.Models.AsignedTasks;

namespace backend.Services
{
    public class AssingedTaskService : IAssignedTaskService
    {
        private IAssignedTaskRepository _repository;
        public AssingedTaskService(IAssignedTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task AddTask(CreateTaskModel taskModel)
        {
            await _repository.AddTask(taskModel);
        }

        public async Task DeleteTask(int taskId)
        {
            await _repository.DeleteTask(taskId);
        }

        public async Task<List<AssignedTask>> GetAllAssignedTask()
        {
            return await _repository.GetAllAssignedTask();
        }

        public async Task<AssignedTask> GetTaskById(int taskId)
        {
            return await _repository.GetTaskById(taskId);
        }

        public async Task UpdateTask(CreateTaskModel taskModel, int taskId)
        {
            await _repository.UpdateTask(taskModel, taskId);
        }
    }
}