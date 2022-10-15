using backend.Entities;
using backend.Models.Subject;

namespace backend.Interfaces
{
    public interface ISubjectService
    {
        public Task AddSubject(CreateSubjectModel subjectModel);
        public Task<List<Subject>> GetAllSubjects();
        public Task<Subject> GetSubjectById(int subjectId);
        public Task UpdateSubject(CreateSubjectModel subjectModel, int subjectId);
        public Task DeleteSubject(int subjectId);
    }
}