using Microsoft.EntityFrameworkCore;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students;

        public DbSet<Account> Accounts;

        public DbSet<IUser> Users;


    }
}