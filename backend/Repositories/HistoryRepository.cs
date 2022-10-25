using backend.Entities;
using backend.Data;
using backend.DTO;
using backend.Utilities;
using backend.Helpers;
using backend.Models.AbsentHistory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public interface IHistoryRepository
    {
        public Task AddAbsentHistory(int scheduleId, int teacherId, int studentId, UpdateReasonModel reason );
        public Task<ActionResult<List<AbsentHistoryStudentDTO>>> GetAbsentHistoryStudent(int studentId);
        public Task<ActionResult<List<AbsentHistoryTeacherDTO>>> GetAbsentHistoryTeacher(int teacherId);
        public Task UpdateHistory(UpdateReasonModel model, int historyId);
        public Task DeleteHistory(int historyId);
    }
    public class HistoryRepository : IHistoryRepository
    {
        private MyDbContext _context;
        public HistoryRepository(MyDbContext context)
        {
            _context = context;
        }

        private AssignedTask FindTask(int taskId)
        {
            var foundTask = _context.Tasks.Find(taskId);
            if (foundTask != null)
            {
                return foundTask;
            }
            else
            {
                return null;
            };
        }

        public async Task AddAbsentHistory(int scheduleId, int teacherId, int studentId, UpdateReasonModel reason)
        {
            try
            {
                var foundSchedule = _context.Schedules.Find(scheduleId);
                var foundTeacher = _context.Users.Find(teacherId);
                var foundStudent = _context.Students.Find(studentId);
                if(reason.Reason == "") throw new AppException("Require absent reason");
                if (foundSchedule != null
                    && foundTeacher != null
                    && foundStudent != null)
                {
                    var newAbsentHistory = new AbsentHistory
                    {
                        StudentId = foundStudent.StudentId,
                        TeacherId = foundTeacher.UserId,
                        SubjectName = FindTask(foundSchedule.TaskId).SubjectName,
                        StudentFullName = foundStudent.FullName,
                        StudentCode = foundStudent.StudentCode,
                        TeacherFullName = foundTeacher.FullName,
                        ClassroomName = foundStudent.ClassroomName,
                        CreatedDate = DateTime.Now,
                        Reason = reason.Reason
                    };
                    await _context.AbsentHistories.AddAsync(newAbsentHistory);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteHistory(int historyId)
        {
            try
            {
                var foundHistory = _context.AbsentHistories.Find(historyId);
                if(foundHistory != null)
                {
                    _context.AbsentHistories.Remove(foundHistory);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<AbsentHistoryStudentDTO>>> GetAbsentHistoryStudent(int studentId)
        {
            if(_context.AbsentHistories != null)
            {
                try
                {
                    var foundStudent = _context.Students.Find(studentId);
                    if(foundStudent != null)
                    {
                        var absentHistories = await _context.AbsentHistories.Where(histories => histories.StudentId == foundStudent.StudentId)
                                                                        .Select(history => history.HistoryStudentToDTO())
                                                                        .ToListAsync();
                        return new OkObjectResult(absentHistories);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<List<AbsentHistoryTeacherDTO>>> GetAbsentHistoryTeacher(int teacherId)
        {
            if(_context.AbsentHistories != null)
            {
                try
                {
                    var foundTeacher = _context.Users.Find(teacherId);
                    if(foundTeacher != null)
                    {
                        var AbsentHistories = await _context.AbsentHistories.Where(histories => histories.TeacherId == teacherId)
                                                                            .Select(history => history.HistoryTeacherToDTO())
                                                                            .ToListAsync();
                        return new OkObjectResult(AbsentHistories);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }

        public async Task UpdateHistory(UpdateReasonModel model, int historyId)
        {
            try
            {
                var foundAbsentHistory = _context.AbsentHistories.Find(historyId);
                if(model.Reason == "") throw new AppException("Require absent reason");
                if(foundAbsentHistory != null)
                {
                    foundAbsentHistory.Reason = model.Reason;
                    _context.AbsentHistories.Update(foundAbsentHistory);
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