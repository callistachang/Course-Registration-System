using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class UserFactory
    {
        public bool CreateStudent(string matricNumber, string fullName, int studyYear, Sex sex, Nationality nationality, out Student student)
        {
            student = null;
            if (matricNumber.Length != 9 || matricNumber.First() != 'U')
            {
                Log.Error("Invalid matric number. It must be 9 characters long and begin with the letter 'U'.");
            }
            else if (studyYear < 1 || studyYear > 7)
            {
                Log.Error("Invalid study year. The value must be between 1 to 7.");
            }
            else
            {
                student = new Student(matricNumber, fullName, studyYear, sex, nationality);
            }
            return student != null;
        }
    }
}
