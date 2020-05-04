using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controller
{
    public class StudentManager : IDatabaseManager<Student>
    {
        public readonly DbSet<Student> Students;

        public StudentManager(DbSet<Student> students)
        {
            Students = students;
        }

        /// <summary>
        /// Gets a Student object from the database.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Get(string identifier, out Student obj)
        {
            obj = Students.SingleOrDefault(s => s.MatricNumber == identifier);
            return obj != null;
        }

        /// <summary>
        /// Craetes a Student object and saves it to the database if the credentials entered are valid.
        /// </summary>
        /// <param name="matricNumber"></param>
        /// <param name="fullName"></param>
        /// <param name="studyYear">Must be between 1-7.</param>
        /// <param name="sex"></param>
        /// <param name="nationality"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool Create(string matricNumber, string fullName, int studyYear, Sex sex, Nationality nationality, out Student student)
        {
            Regex matricNumberRegex = new Regex("/^U[0-9]{7}[A-Z]");
            student = null;

            if (matricNumberRegex.IsMatch(matricNumber))
            {
                Log.Error("Invalid matric number format.");
            }
            else if (studyYear < 1 || studyYear > 7)
            {
                Log.Error("Invalid study year input. The value must be between 1 to 7.");
            }
            else
            {
                student = new Student(matricNumber, fullName, studyYear, sex, nationality);
                Students.Add(student);
                System.Instance.Database.Save();
            }

            return student != null;
        }
    }
}
