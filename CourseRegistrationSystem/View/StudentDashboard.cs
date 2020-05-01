using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.View
{
    public class StudentDashboard : ConsoleView, IDashboard
    {
        private Student Student;

        public void Render() { }

        public Course AddCourse()
        {
            throw new NotImplementedException();
        }

        public Course DropCourse()
        {
            throw new NotImplementedException();
        }

        public int CheckClassVacancies()
        {
            throw new NotImplementedException();
        }

        public int ChangeClass()
        {
            throw new NotImplementedException();
        }

        public int SwopClass()
        {
            throw new NotImplementedException();
        }
    }
}
