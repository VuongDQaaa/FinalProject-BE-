using backend.DTO;
using backend.Interfaces;
using backend.Models.Schedule;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _repository;
        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }
        public async Task AddSchedule(CreateScheduleModel scheduleModel, int classroomId)
        {
            await _repository.AddSchedule(scheduleModel, classroomId);
        }

        public async Task DeleteSchedule(int scheduleId)
        {
            await _repository.DeleteSchedule(scheduleId);
        }

        public async Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId , int year, string week)
        {
            return await _repository.GetSchedulesByClassroomId(classroomId, year, week);
        }

        public async Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId, int year, string week)
        {
            return await _repository.GetSchedulesByStudentId(studentId, year, week);
        }

        public async Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId, int year, string week)
        {
            return await _repository.GetSchedulesByTeacherId(teacherId, year, week);
        }
    }
}