using backend.Interfaces;
using backend.DTO;
using backend.Repositories;
using backend.Models.AbsentHistory;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class AbsentHistoryService : IAbsentHistoryService
    {
        private IHistoryRepository _repository;
        public AbsentHistoryService(IHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAbsentHistory(int scheduleId, int teacherId, int studentId, UpdateReasonModel reason)
        {
            await _repository.AddAbsentHistory(scheduleId, teacherId, studentId, reason);
        }

        public async Task DeleteHistory(int historyId)
        {
            await _repository.DeleteHistory(historyId);
        }

        public async Task<ActionResult<List<AbsentHistoryStudentDTO>>> GetAbsentHistoryStudent(int studentId)
        {
            return await _repository.GetAbsentHistoryStudent(studentId);
        }

        public async Task<ActionResult<List<AbsentHistoryTeacherDTO>>> GetAbsentHistoryTeacher(int teacherId)
        {
            return await _repository.GetAbsentHistoryTeacher(teacherId);
        }

        public async Task UpdateHistory(UpdateReasonModel model, int historyId)
        {
            await _repository.UpdateHistory(model, historyId);
        }
    }
}