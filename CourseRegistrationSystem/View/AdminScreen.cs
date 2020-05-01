using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.View
{
    public class AdminScreen : ConsoleManager, IScreen
    {
        private Staff Admin;

        public void Render()
        {
            AddOption("acc", "access [schoolcode] [year]", "Edit student access period by school and year", EditStudentAccessPeriod);
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
