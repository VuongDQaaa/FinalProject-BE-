using backend.Data;
using backend.Entities;
using backend.Models.Subject;
using backend.Helpers;

namespace backend.Repositories
{
    public interface ISubjectRepository
    {
        public Task AddSubject(CreateSubjectModel subjectModel);
        public Task<List<Subject>> GetAllSubjects();
        public Task<Subject> GetSubjectById(int subjectId);
        public Task UpdateSubject(CreateSubjectModel subjectModel, int subjectId);
        public Task DeleteSubject(int subjectId);
    }
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MyDbContext _context;
        public SubjectRepository(MyDbContext context)
        {
            _context = context;
        }
        private bool CheckExitedSubjectName(string subjectName)
        {
            var foundSubject = _context.Subjects.FirstOrDefault(a => a.SubjectName == subjectName);
            if (foundSubject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task AddSubject(CreateSubjectModel subjectModel)
        {
            try
            {
                if (CheckExitedSubjectName(subjectModel.SubjectName))
                {
                    throw new AppException("This subject have been added. Please enter a different subject");
                }
                else
                {
                    var newSubject = new Subject
                    {
                        SubjectName = subjectModel.SubjectName
                    };
                    await _context.Subjects.AddAsync(newSubject);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteSubject(int subjectId)
        {
            try
            {
                var foundSubject = await _context.Subjects.FindAsync(subjectId);
                if (foundSubject != null)
                {
                    _context.Subjects.Remove(foundSubject);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            var foundSubject = await _context.Subjects.FindAsync(subjectId);
            if (foundSubject != null)
            {
                return foundSubject;
            }
            else
            {
                throw new AppException("This class is not exist");
            }
        }

        public async Task UpdateSubject(CreateSubjectModel subjectModel, int subjectId)
        {
            if (CheckExitedSubjectName(subjectModel.SubjectName)) throw new AppException("This subject have been added. Please enter a different subject");
            try
            {
                var foundSubject = _context.Subjects.Find(subjectId);
                if (foundSubject != null)
                {
                    foundSubject.SubjectName = subjectModel.SubjectName;
                    _context.Subjects.Update(foundSubject);
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