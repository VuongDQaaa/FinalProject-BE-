using backend.Entities;
using backend.Data;
using backend.Models.Schedule;
using backend.Helpers;
using backend.Enums;
using backend.DTO;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace backend.Repositories
{
    public interface IScheduleRepository
    {
        public Task AddSchedule(CreateScheduleModel scheduleModel, int classroomId);
        public Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId, int year, string week);
        public Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId, int year, string week);
        public Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId, int year, string week);
        public Task DeleteSchedule(int scheduleId);
    }
    public class ScheduleRepository : IScheduleRepository
    {
        private MyDbContext _context;
        public ScheduleRepository(MyDbContext context)
        {
            _context = context;
        }
        private bool CheckValidSchedule(CreateScheduleModel scheduleModel)
        {
            var foundUser = _context.Users.FirstOrDefault(a => a.UserName == scheduleModel.UserName);
            if (foundUser != null)
            {
                var foundSchedule = _context.Schedules.FirstOrDefault(a => a.Session == SessionConverter(scheduleModel.Session)
                                                                        && a.Period == scheduleModel.Period
                                                                        && a.Day == DayConverter(scheduleModel.Day)
                                                                        && a.UserId == foundUser.UserId);
                if (foundSchedule == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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
        public async Task AddSchedule(CreateScheduleModel scheduleModel, int classroomId)
        {
            if (!CheckValidSchedule(scheduleModel)) throw new AppException("Invalid Schedule");
            try
            {
                var foundUser = _context.Users.FirstOrDefault(a => a.UserName == scheduleModel.UserName);
                var foundAssignedTask = _context.Tasks.Find(scheduleModel.TaskId);
                var foundClassroom = _context.Classrooms.FirstOrDefault(a => a.ClassroomId == classroomId);
                if (foundUser != null
                    && foundClassroom != null
                    && foundAssignedTask != null)
                {
                    var foundSubject = _context.Subjects.Find(foundAssignedTask.SubjectId);
                    if (foundSubject != null)
                    {
                        var newSchedule = new Schedule
                        {
                            Session = SessionConverter(scheduleModel.Session),
                            Period = scheduleModel.Period,
                            Day = DayConverter(scheduleModel.Day),
                            UserId = foundUser.UserId,
                            TaskId = scheduleModel.TaskId,
                            AutoFillClassroom = foundAssignedTask.AutoFill,
                            AutoFillTeacher = foundSubject.SubjectName + "-" + foundClassroom.ClassroomName,
                            ClassroomId = foundClassroom.ClassroomId
                        };
                        await _context.Schedules.AddAsync(newSchedule);
                        await _context.SaveChangesAsync();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            try
            {
                var foundSchedule = _context.Schedules.Find(scheduleId);
                if (foundSchedule != null)
                {
                    _context.Schedules.Remove(foundSchedule);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId, int year, string week)
        {
            if (_context.Schedules != null)
            {
                try
                {
                    var foundClassroom = _context.Classrooms.Find(classroomId);
                    if (foundClassroom != null)
                    {
                        string[] date = week.Split(" - ");
                        string[] start = date[0].Split('/');
                        string startDay = start[0];
                        string startMoth = start[1];
                        string startYear = year.ToString();
                        string newDate = startDay + "/" + startMoth + "/" + startYear;
                        DateTime startDate = DateTime.ParseExact(newDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var schedules = await _context.Schedules.Where(schedules => schedules.ClassroomId == classroomId
                                                                                    && schedules.ScheduleDate == startDate
                                                                                    || schedules.ScheduleDate == startDate.AddDays(1)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(2)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(3)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(4)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(5)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(6))
                                                                .Select(schedule => schedule.ScheduleEntitytoClassroomDTO())
                                                                .ToListAsync();
                        return new OkObjectResult(schedules);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId, int year, string week)
        {
            if (_context.Schedules != null)
            {
                try
                {
                    var foundUser = _context.Users.Find(teacherId);
                    if (foundUser != null)
                    {
                        string[] date = week.Split(" - ");
                        string[] start = date[0].Split('/');
                        string startDay = start[0];
                        string startMoth = start[1];
                        string startYear = year.ToString();
                        string newDate = startDay + "/" + startMoth + "/" + startYear;
                        DateTime startDate = DateTime.ParseExact(newDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var schedules = await _context.Schedules.Where(schedules => schedules.UserId == teacherId
                                                                                    && schedules.ScheduleDate == startDate
                                                                                    || schedules.ScheduleDate == startDate.AddDays(1)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(2)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(3)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(4)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(5)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(6))
                                                                .Select(schedule => schedule.ScheduleEntitytoTeacherDTO())
                                                                .ToListAsync();
                        return new OkObjectResult(schedules);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId, int year, string week)
        {
            if (_context.Schedules != null)
            {
                try
                {
                    var foundStudent = _context.Students.Find(studentId);
                    if (foundStudent != null)
                    {
                        string[] date = week.Split(" - ");
                        string[] start = date[0].Split('/');
                        string startDay = start[0];
                        string startMoth = start[1];
                        string startYear = year.ToString();
                        string newDate = startDay + "/" + startMoth + "/" + startYear;
                        DateTime startDate = DateTime.ParseExact(newDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var schedules = await _context.Schedules.Where(schedules => schedules.ClassroomId == foundStudent.ClassroomId
                                                                                    && schedules.ScheduleDate == startDate
                                                                                    || schedules.ScheduleDate == startDate.AddDays(1)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(2)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(3)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(4)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(5)
                                                                                    || schedules.ScheduleDate == startDate.AddDays(6))
                                                                .Select(schedule => schedule.ScheduleEntitytoStudentDTO())
                                                                .ToListAsync();
                        return new OkObjectResult(schedules);
                    }
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