using System;
using System.Linq;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Database
{
    public class DatabaseManager
    {
        private DatabaseContext Database;

        public void Initialize()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(connectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            Database = new DatabaseContext(optionsBuilder.Options);
        }
    }
}