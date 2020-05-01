using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.View
{
    public class StudentScreen : ConsoleManager, IScreen
    {
        private Student Student;

        public void Render()
        {
            AddOption("add", "add [coursecode] [classindex]", "Add course", AddCourse);
            AddOption("drop", "drop [coursecode]", "Drop course", DropCourse);
            AddOption("change", "change [originalindex] [desiredindex]", "Change class index", ChangeIndex);
            AddOption("swap", "swap [coursecode] [peermatricnum]", "Swap class index with a peer", SwapIndexWithPeer);
            AddOption("vac", "vac class|course [identifier]", "Check class or course vacancies", CheckVacancies);

            InitializeOptions();
        }

        public OptionResult AddCourse(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        public OptionResult DropCourse(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        public OptionResult CheckVacancies(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        public OptionResult ChangeIndex(string command, IList<string> args)
        {
            return OptionResult.Break;
        }

        public OptionResult SwapIndexWithPeer(string command, IList<string> args)
        {
            return OptionResult.Break;
        }
    }
}
