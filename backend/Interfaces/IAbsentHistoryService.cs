using backend.Models.AbsentHistory;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Interfaces
{
    public interface IAbsentHistoryService
    {
        public Task AddAbsentHistory(int scheduleId, int teacherId, int studentId, UpdateReasonModel reason);
        Task<ActionResult<List<AbsentHistoryStudentDTO>>> GetAbsentHistoryStudent(int studentId);
        Task<ActionResult<List<AbsentHistoryTeacherDTO>>> GetAbsentHistoryTeacher(int teacherId);
        public Task UpdateHistory(UpdateReasonModel model, int historyId);
        public Task DeleteHistory(int historyId);
    }
}