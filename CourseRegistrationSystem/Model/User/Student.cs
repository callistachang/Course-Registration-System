using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class Student : IModel
    {
        private string _matricNumber;

        public readonly UserType userType = UserType.Student;
        public string MatricNumber
        {
            get => GetId();
            private set => _matricNumber = value;
        }
        public string FullName { get; set; }
        public int StudyYear { get; set; }
        public Sex Sex { get; set; }
        public Nationality Nationality { get; set; }
        public List<ClassStudent> Classes { get; set; }
        public Account Account { get; set; }

        public Student(string matricNumber, string fullName, int studyYear, Sex sex, Nationality nationality)
        {
            MatricNumber = matricNumber;
            FullName = fullName;
            StudyYear = studyYear;
            Sex = sex;
            Nationality = nationality;
            Classes = new List<ClassStudent>();
        }

        public string GetId()
        {
            return _matricNumber;
        }
    }
}
