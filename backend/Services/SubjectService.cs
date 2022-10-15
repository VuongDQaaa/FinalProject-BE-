using backend.Entities;
using backend.Interfaces;
using backend.Models.Subject;
using backend.Repositories;

namespace backend.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _repository;
        public SubjectService(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSubject(CreateSubjectModel subjectModel)
        {
            await _repository.AddSubject(subjectModel);
        }

        public async Task DeleteSubject(int subjectId)
        {
            await _repository.DeleteSubject(subjectId);
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _repository.GetAllSubjects();
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            return await _repository.GetSubjectById(subjectId);
        }

        public async Task UpdateSubject(CreateSubjectModel subjectModel, int subjectId)
        {
            await _repository.UpdateSubject(subjectModel, subjectId);
        }
    }
}