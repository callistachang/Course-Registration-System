using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using CourseRegistrationSystem.Model;
using CourseRegistrationSystem.Controller;
using System.Configuration;

namespace CourseRegistrationSystem.Controller
{
    public class SystemDatabase
    {
        private SystemContext Context;
        //public StudentManager StudentManager { get; private set; }
        //public ClassManager ClassManager { get; private set; }
        //public CourseManager CourseManager { get; private set; }

        public void Initialize()
        {
            if (Context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SystemContext>();
                string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
                optionsBuilder.UseMySql(connectionString);
                optionsBuilder.EnableSensitiveDataLogging(true);
                Initialize(optionsBuilder);
            }
        }

        public void Initialize(DbContextOptionsBuilder optionsBuilder)
        {
            if (Context == null)
            {
                Context = new SystemContext(optionsBuilder.Options);
                Context.Database.EnsureCreated();
                InitializeManagers(Context);
            }
        }

        private void InitializeManagers(SystemContext context)
        {
            //StudentManager = new StudentManager(context.Students);
            //ClassManager = new ClassManager(context.Classes);
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}