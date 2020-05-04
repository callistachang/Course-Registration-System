using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controller
{
    public class CourseManager : IDatabaseManager<Course>
    {
        public readonly DbSet<Course> Courses;

        public CourseManager(DbSet<Course> courses)
        {
            Courses = courses;
        }

        public bool Get(string identifier, out Course obj)
        {
            obj = Courses.SingleOrDefault(c => c.CourseCode == identifier);
            return obj != null;
        }
    }
}
