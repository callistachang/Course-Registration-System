using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controller
{
    public class ClassManager : IDatabaseManager<Class>
    {
        private readonly DbSet<Class> Classes;

        public ClassManager(DbSet<Class> classes)
        {
            Classes = classes;
        }

        public bool Get(string identifier, out Class obj)
        {
            obj = Classes.SingleOrDefault(s => s.IndexNumber == identifier);
            return obj != null;
        }

        public Class Create(string indexNumber, int maxStudentCount, Course course)
        {
            Class @class = new Class(indexNumber, maxStudentCount, course);
            Classes.Add(@class);
            System.Instance.Database.Save();
            return @class;
        }
    }
}
