using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.View
{
    public class AdminScreen : ConsoleManager, IScreen
    {
        private Staff Admin;

        public void Render()
        {
            AddOption("acc", "acc [schoolcode] [year]", "Edit student access period by school and year", EditStudentAccessPeriod);
            AddOption("reg", "Register new student", CreateStudent);
            AddOption("create", "Create new course", CreateCourse);
            AddOption("update", "update [coursecode]", "Edit course", EditCourse);
            AddOption("vac", "vac class|course [identifier]", "Check class or course vacancies", CheckVacancies);
            AddOption("print", "print class|course [identifier]", "Print student list by class or course", PrintStudentList);

            InitializeOptions();
        }

        private OptionResult EditStudentAccessPeriod(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        private OptionResult CreateStudent(string command, IList<string> args)
        {




            Regex matricNumberRegex = new Regex("/^U[0-9]{7}[A-Z]");
            Console.Write("Enter matric number (valid format): ");
            string matricNumber = Console.ReadLine();
            if (!matricNumberRegex.IsMatch(matricNumber))
            {
                Log.Error(3);
                return OptionResult.Break;
            }

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter study year (1-7): ");
            int studyYear;
            if (!int.TryParse(Console.ReadLine(), out studyYear))
            {
                Log.Error(2);
                return OptionResult.Break;
            }
            if (studyYear < 1 || studyYear > 7)
            {
                Log.Error(4);
                return OptionResult.Break;
            }

            Console.Write("Sex types: ");
            Sex sex;
            if (!Utils.ReadEnumChoice<Sex>(out sex))
            {
                Log.Error(1);
                return OptionResult.Break;
            }

            Console.Write("Nationality types: ");
            Nationality nationality;
            if (!Utils.ReadEnumChoice<Nationality>(out nationality))
            {
                Log.Error(1);
                return OptionResult.Break;
            }

            //System.Instance.Database.StudentManager.Create(matricNumber, fullName, studyYear, sex, nationality);
            return OptionResult.Break;
        }

        private OptionResult CreateCourse(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        private OptionResult EditCourse(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        private OptionResult CheckVacancies(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        private OptionResult PrintStudentList(string command, IList<string> args)
        {
            if (args.Count != 3)
                return OptionResult.InvalidArgument;

            return OptionResult.Break;
        }
    }
}
