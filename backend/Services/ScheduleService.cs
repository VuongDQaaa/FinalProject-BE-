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

        public async Task<ActionResult<List<ClassroomScheduleDTO>>> GetSchedulesByClassroomId(int classroomId)
        {
            return await _repository.GetSchedulesByClassroomId(classroomId);
        }

        public async Task<ActionResult<List<StudentScheduleDTO>>> GetSchedulesByStudentId(int studentId)
        {
            return await _repository.GetSchedulesByStudentId(studentId);
        }

        public async Task<ActionResult<List<TeacherScheduleDTO>>> GetSchedulesByTeacherId(int teacherId)
        {
            return await _repository.GetSchedulesByTeacherId(teacherId);
        }

        public async Task UpdateSchedule(UpdateScheduleModel scheduleModel, int scheduleId)
        {
            await _repository.UpdateSchedule(scheduleModel, scheduleId);
        }
    }
}