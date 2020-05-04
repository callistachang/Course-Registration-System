using Microsoft.EntityFrameworkCore;
using CourseRegistrationSystem.Model;
using CourseRegistrationSystem.Controller;

namespace CourseRegistrationSystem.Controller
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Username);
            });

            // Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.MatricNumber);
                entity.Property(s => s.Sex).HasConversion<string>();
                entity.Property(s => s.Nationality).HasConversion<string>();
                entity.HasMany(s => s.Classes);
                entity.HasOne(s => s.Account);
            });

            // Staff
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.HasMany(s => s.CoordinatorCourses);
                entity.HasOne(s => s.Account);
            });

            // Class
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(cl => cl.IndexNumber);
                entity.HasMany(cl => cl.Students);
                entity.HasOne(cl => cl.Course).WithMany(c => c.Classes).HasForeignKey(cl => cl.CourseCode);
            });

            // Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseCode);
                entity.Property(c => c.School).HasConversion<string>();
                entity.HasMany(c => c.Classes).WithOne(cl => cl.Course).HasForeignKey(cl => cl.CourseCode);
                entity.HasOne(c => c.Coordinator).WithMany(s => s.CoordinatorCourses).HasForeignKey(c => c.CoordinatorId);
            });

            // Slot
            modelBuilder.Entity<Slot>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.DayOfWeek).HasConversion<string>();
                entity.Property(s => s.StartTime).HasConversion(Utils.TimeSpanConverter);
                entity.Property(s => s.EndTime).HasConversion(Utils.TimeSpanConverter);
            });

            #region Associative Entities

            // Class-Student
            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasKey(cls => new { cls.ClassIndex, cls.MatricNumber });
                entity.HasOne(cls => cls.Class).WithMany(c => c.Students).HasForeignKey(cs => cs.ClassIndex);
                entity.HasOne(cls => cls.Student).WithMany(c => c.Classes).HasForeignKey(cs => cs.MatricNumber);
            });

            // Course-Slot
            modelBuilder.Entity<CourseSlot>(entity =>
            {
                entity.HasKey(cs => new { cs.CourseCode, cs.SlotId });
                entity.HasOne(cs => cs.Slot);
                entity.HasOne(cs => cs.Course).WithMany(c => c.CourseSchedule).HasForeignKey(cs => cs.CourseCode);
            });

            // Class-Slot
            modelBuilder.Entity<ClassSlot>(entity =>
            {
                entity.HasKey(cs => new { cs.ClassIndex , cs.SlotId });
                entity.HasOne(cs => cs.Slot);
                entity.HasOne(cs => cs.Class).WithMany(c => c.ClassSchedule).HasForeignKey(cs => cs.ClassIndex);
            });

            #endregion
        }
    }
}