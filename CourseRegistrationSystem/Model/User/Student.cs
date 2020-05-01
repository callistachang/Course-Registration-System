using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class Student : IUser
    {
        public string MatricNumber;
        public string FullName;
        public int StudyYear;
        public Gender Gender;
        public Nationality Nationality;

        public string GetUniqueId() => MatricNumber;

        public UserType GetUserType() => UserType.Student;
    }
}
