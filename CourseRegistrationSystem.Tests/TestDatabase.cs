using CourseRegistrationSystem.Controller;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CourseRegistrationSystem.Tests
{
    public class TestDatabase
    {
        private readonly SystemDatabase Database;

        public TestDatabase()
        {
            Database = new SystemDatabase();
            var optionsBuilder = new DbContextOptionsBuilder<SystemContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
            Database.Initialize(optionsBuilder);
        }
    }
}
