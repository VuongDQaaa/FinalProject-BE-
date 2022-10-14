using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        // public DbSet<Subject> Subjects { get; set; }
        // public DbSet<AssignedTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => e.ToTable("User"));
            modelBuilder.Entity<Student>(e => e.ToTable("Student"));
            modelBuilder.Entity<Classroom>(e => e.ToTable("Classroom"));
            // modelBuilder.Entity<Subject>(e => e.ToTable("Subject"));
            // modelBuilder.Entity<Subject>(e => e.ToTable("AssignedTask"));

            //Student-Classroom
            modelBuilder.Entity<Student>()
            .HasOne(a => a.Classroom)
            .WithMany(b => b.Students)
            .HasForeignKey(c => c.ClassroomId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

            // //AssignedTask-User
            // modelBuilder.Entity<AssignedTask>()
            // .HasOne(a => a.Teacher)
            // .WithMany(b => b.AssignedTasks)
            // .HasForeignKey(c => c.UserId)
            // .OnDelete(DeleteBehavior.Restrict)
            // .IsRequired();

            // //AssignedTask-Subject
            // modelBuilder.Entity<AssignedTask>()
            // .HasOne(a => a.Subject)
            // .WithMany(b => b.AssignedTasks)
            // .HasForeignKey(c => c.SubjectId)
            // .OnDelete(DeleteBehavior.Restrict)
            // .IsRequired();

            //Seeding data
            modelBuilder.Entity<User>().HasData(SeedingData.SeedingUsers);
            modelBuilder.Entity<Student>().HasData(SeedingData.SeedingStudents);
            modelBuilder.Entity<Classroom>().HasData(SeedingData.SeedingClassrooms);
            // modelBuilder.Entity<Subject>().HasData(SeedingData.SeedingSubjects);
            // modelBuilder.Entity<AssignedTask>().HasData(SeedingData.SeedingTasks);
        }
    }
}