using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Controller;
using CourseRegistrationSystem.Database;
using CourseRegistrationSystem.View;

namespace CourseRegistrationSystem
{
    public class System
    {
        public static readonly System Instance = new System();
        public readonly SlotManager Schedule = new SlotManager();
        public readonly DatabaseManager Database = new DatabaseManager();

        public void Run()
        {
            ConsoleUtils.WriteHeader(ConsoleColor.Green);
            LoginScreen screen = new LoginScreen();
            screen.Render();
        }
    }
}
