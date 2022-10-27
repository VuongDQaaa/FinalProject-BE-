using backend.Models.Classrooms;
using backend.Entities;
using backend.Data;
using backend.Helpers;

namespace backend.Repositories
{

    public interface IClassroomRepository
    {
        public Task AddClassroom(UpdateClassroomModel classroomModel);
        public Task UpdateClassroom(UpdateClassroomModel classroomModel, int classroomId);
        public Task DeleteClassroom(int classroomId);
        public Task<List<Classroom>> GetAllClassroom();
        public Task<Classroom> GetClassroomById(int classroomId);
    }
    public class ClassroomRepository : IClassroomRepository
    {
        private MyDbContext _context;
        public ClassroomRepository(MyDbContext context)
        {
            _context = context;
        }

        public string GenarateClassroomName(string grade, string name)
        {
            return grade + " " + name;
        }

        public bool CheckValidClassroom(string classroomName, int startYear)
        {
            var foundClassroom = _context.Classrooms.FirstOrDefault(a => a.ClassroomName == classroomName && a.StartYear == startYear);
            if(foundClassroom != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task AddClassroom(UpdateClassroomModel classroomModel)
        {
            try
            {
                var newClassroomName = GenarateClassroomName(classroomModel.Grade, classroomModel.ClassroomName);
                if(!CheckValidClassroom(newClassroomName, classroomModel.StartYear)) throw new AppException("This classroom have been added. Please enter a different classroom");
                else
                {
                    var newClassroom = new Classroom
                    {
                        ClassroomName = newClassroomName,
                        Grade = classroomModel.Grade,
                        StartYear = classroomModel.StartYear,
                        EndYear = classroomModel.StartYear + 3,
                    };
                    await _context.Classrooms.AddAsync(newClassroom);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateClassroom(UpdateClassroomModel classroomModel, int classroomId)
        {
            try
            {
                var newClassroomName = GenarateClassroomName(classroomModel.Grade, classroomModel.ClassroomName);
                if(!CheckValidClassroom(newClassroomName, classroomModel.StartYear)) throw new AppException("This classroom have been added. Please enter a different classroom");
                var foundClassroom = await _context.Classrooms.FindAsync(classroomId);
                if (foundClassroom != null)
                {
                    foundClassroom.ClassroomName = newClassroomName;
                    foundClassroom.Grade = classroomModel.Grade;
                    foundClassroom.StartYear = classroomModel.StartYear;
                    foundClassroom.EndYear = classroomModel.StartYear + 3;

                    _context.Classrooms.Update(foundClassroom);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteClassroom(int classroomId)
        {
            try
            {
                var foundActiveStudents = _context.Students.FirstOrDefault(x => x.ClassroomId == classroomId && x.IsDiabled == false);
                if(foundActiveStudents != null) throw new AppException("Please disable all of the student in this classroom");
                var foundClassroom = await _context.Classrooms.FindAsync(classroomId);
                if (foundClassroom != null)
                {
                    _context.Classrooms.Remove(foundClassroom);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Classroom>> GetAllClassroom()
        {
            return _context.Classrooms.ToList();
        }

        public async Task<Classroom> GetClassroomById(int classroomId)
        {
            var foundClassroom = await _context.Classrooms.FindAsync(classroomId);
            if (foundClassroom != null)
            {
                return foundClassroom;
            }
            else
            {
                throw new AppException("This class is not exist");
            }
        }
    }
}