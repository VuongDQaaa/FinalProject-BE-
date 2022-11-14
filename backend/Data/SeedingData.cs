using backend.Entities;
using backend.Enums;

namespace backend.Data
{
    public static class SeedingData
    {
        //Add data for table "AbsentHistory"
        public static IEnumerable<AbsentHistory> SeedingHistory
        {
            get
            {
                IEnumerable<AbsentHistory> result = new List<AbsentHistory>(){
                    new AbsentHistory() {
                        HistoryId = 1,
                        StudentId = 1,
                        TeacherId = 2,
                        SubjectName = "Sinh",
                        StudentFullName = "Dao Quy Vuong",
                        StudentCode = "ST1",
                        TeacherFullName = "Do Duy Nam",
                        ClassroomName = "10 Sinh",
                        CreatedDate = new DateTime(2022,11,07),
                        AbsentDate = new DateTime(2022,11,07),
                        Reason = "No",
                        Slot = 1,
                        Session = Session.Morning
                    },
                    new AbsentHistory() {
                        HistoryId = 2,
                        StudentId = 1,
                        TeacherId = 3,
                        SubjectName = "Toan",
                        StudentFullName = "Dao Quy Vuong",
                        StudentCode = "ST1",
                        TeacherFullName = "Do Thu Huong",
                        ClassroomName = "10 Sinh",
                        CreatedDate = new DateTime(2022,11,07),
                        AbsentDate = new DateTime(2022,11,07),
                        Reason = "No",
                        Slot = 1,
                        Session = Session.Morning
                    }
                };
                return result;
            }
        }
        //Add data for table "Schedule"
        public static IEnumerable<Schedule> SeedingSchedules
        {
            get
            {
                IEnumerable<Schedule> result = new List<Schedule>(){
                    new Schedule() {
                        ScheduleId = 1,
                        Session = Session.Morning,
                        Period = 1,
                        Day = Day.Monday,
                        UserId = 2,
                        TaskId = 1,
                        ScheduleDate = new DateTime(2022,11,07),
                        AutoFillClassroom = "Sinh - Teacher",
                        AutoFillTeacher = "Sinh - 10 Sinh",
                        ClassroomId = 1
                    },
                    new Schedule() {
                        ScheduleId = 2,
                        Session = Session.Morning,
                        Period = 2,
                        Day = Day.Monday,
                        UserId = 2,
                        TaskId = 2,
                        ScheduleDate = new DateTime(2022,11,07),
                        AutoFillClassroom = "Toan - Teacher",
                        AutoFillTeacher = "Toan - 10 Sinh",
                        ClassroomId = 1
                    },
                        new Schedule() {
                        ScheduleId = 3,
                        Session = Session.Morning,
                        Period = 2,
                        Day = Day.Monday,
                        UserId = 2,
                        TaskId = 2,
                        ScheduleDate = new DateTime(2022,10,31),
                        AutoFillClassroom = "Toan - Teacher",
                        AutoFillTeacher = "Toan - 10 Sinh",
                        ClassroomId = 1
                    },
                };
                return result;
            }
        }
        //Add data for table "Subject"
        public static IEnumerable<Subject> SeedingSubjects
        {
            get
            {
                IEnumerable<Subject> result = new List<Subject>(){
                    new Subject() {
                        SubjectId = 1,
                        SubjectName = "Sinh"
                    },
                    new Subject() {
                        SubjectId = 2,
                        SubjectName = "Toan"
                    }
                };
                return result;
            }
        }
        //Add data for table "Task"
        public static IEnumerable<AssignedTask> SeedingTasks
        {
            get
            {
                IEnumerable<AssignedTask> result = new List<AssignedTask>(){
                    new AssignedTask() {
                        TaskId = 1,
                        UserId = 2,
                        UserName = "Teacher",
                        SubjectId = 1,
                        SubjectName = "Sinh",
                        AutoFill = "Teacher - Sinh"
                    },
                    new AssignedTask() {
                        TaskId = 2,
                        UserId = 2,
                        UserName = "Teacher",
                        SubjectId = 2,
                        SubjectName = "Toan",
                        AutoFill = "Teacher - Toan"
                    },
                    new AssignedTask() {
                        TaskId = 3,
                        UserId = 3,
                        UserName = "Teacher1",
                        SubjectId = 2,
                        SubjectName = "Toan",
                        AutoFill = "Teacher1 - Toan"
                    },
                };
                return result;
            }
        }
        //Add data for table "Classroom"
        public static IEnumerable<Classroom> SeedingClassrooms
        {
            get
            {
                IEnumerable<Classroom> result = new List<Classroom>() {
                    new Classroom() {
                        ClassroomId = 1,
                        Grade = "10",
                        ClassroomName = "10 Sinh",
                        StartYear = 2015,
                        EndYear = 2018
                    },
                    new Classroom() {
                        ClassroomId = 2,
                        Grade = "10",
                        ClassroomName = "10 Toan",
                        StartYear = 2015,
                        EndYear = 2018,
                    }
                };
                return result;
            }
        }
        //Add data for table "User"
        public static IEnumerable<User> SeedingUsers
        {
            get
            {
                IEnumerable<User> result = new List<User>() {
                    new User() {
                        UserId = 1,
                        UserName = "Admin",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Admin"),
                        UserCode = "AD1",
                        FirstName="Dao",
                        LastName="Quy Vuong",
                        Gender = Gender.Male,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Admin,
                        DateOfBirth = new DateTime(2000,2,23),
                    },
                    new User() {
                        UserId = 2,
                        UserName = "Teacher",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Teacher"),
                        UserCode = "TC1",
                        FirstName="Do",
                        LastName="Duy Nam",
                        Gender = Gender.Male,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Teacher,
                        DateOfBirth = new DateTime(2000,2,23),
                    },
                    new User() {
                        UserId = 3,
                        UserName = "Teacher1",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Teacher"),
                        UserCode = "TC2",
                        FirstName="Do",
                        LastName="Thu Huong",
                        Gender = Gender.Female,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Teacher,
                        DateOfBirth = new DateTime(2000,2,23),
                    }
                };
                return result;
            }
        }
        //Add data for table "Student"
        public static IEnumerable<Student> SeedingStudents
        {
            get
            {
                IEnumerable<Student> result = new List<Student>(){
                    new Student() {
                        StudentId = 1,
                        UserName = "Student1",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Student"),
                        StudentCode = "ST1",
                        FirstName="Le",
                        LastName="Thi Van",
                        Gender = Gender.Female,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Student,
                        ClassroomName = "10 Sinh",
                        DateOfBirth = new DateTime(2000,2,23),
                        ClassroomId = 1
                    },
                        new Student() {
                        StudentId = 2,
                        UserName = "Student2",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Student"),
                        StudentCode = "ST2",
                        FirstName="Nguyen",
                        LastName="Van A",
                        Gender = Gender.Male,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Student,
                        ClassroomName = "10 Sinh",
                        DateOfBirth = new DateTime(2000,2,23),
                        ClassroomId = 1
                    },
                        new Student() {
                        StudentId = 3,
                        UserName = "Student3",
                        PasswordHash= BCrypt.Net.BCrypt.HashPassword("Student"),
                        StudentCode = "ST4",
                        FirstName="Nguyen",
                        LastName="Van B",
                        Gender = Gender.Male,
                        IsFirstLogin = false,
                        IsDiabled = false,
                        Role = Role.Student,
                        ClassroomName = "10 Toan",
                        DateOfBirth = new DateTime(2000,2,23),
                        ClassroomId = 2
                    },
                };
                return result;
            }
        }
    }
}