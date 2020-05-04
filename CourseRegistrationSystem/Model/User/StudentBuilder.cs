using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model.User
{
    public class StudentBuilder
    {
        private Student student;

        public StudentBuilder() => Reset();

        public void Reset() => student = new Student();

        public Student GetStudent()
        {
            Student result = student;
            Reset();
            return result;
        }

        public bool AddMatricNumber(string number)
        {
            Regex matricNumberRegex = new Regex("/^U[0-9]{7}[A-Z]");
            if (!matricNumberRegex.IsMatch(number))
            {
                return false;
            }
            else
            {
                student.MatricNumber = number;
                return true;
            }
        }

        public bool AddFullName(string name)
        {
            student.FullName = name;
            return true;
        }

        public bool AddStudyYear(int year)
        {
            if (!Constants.IsValidStudyYear(year))
            {
                return false;
            }
            else
            {
                student.StudyYear = year;
                return true;
            }
        }
    }
}
