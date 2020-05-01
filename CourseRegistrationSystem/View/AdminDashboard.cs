using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;
using CourseRegistrationSystem.Util;

namespace CourseRegistrationSystem.View
{
    public class AdminDashboard : ConsoleView, IDashboard
    {
        private Staff Admin;

        public void Render()
        {
            Start();
        }

        public bool EditStudentAccessPeriod()
        {
            throw new NotImplementedException();
        }

        public Student CreateStudent()
        {
            throw new NotImplementedException();
        }

        public Course CreateCourse()
        {
            throw new NotImplementedException();
        }

        public Course UpdateCourse()
        {
            throw new NotImplementedException();
        }

        public int CheckClassVacancies()
        {
            throw new NotImplementedException();
        }

        // print students by index number
        // print students by course
    }
}
