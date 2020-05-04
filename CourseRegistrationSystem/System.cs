using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Controller;
using CourseRegistrationSystem.View;

namespace CourseRegistrationSystem
{
    public class System
    {
        public static readonly System Instance = new System();
        public readonly SystemDatabase Database = new SystemDatabase();

        public void Run()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            ConsoleUtils.PrintHeader(ConsoleColor.Magenta);

            Log.Info("Initializing database");
            Database.Initialize();

            Log.Info("Loading error messages");
            LoadErrorMessages();

            Log.Info("CourseRegistrationSystem is up and running in {0}ms", stopwatch.ElapsedMilliseconds);

            ConsoleUtils.PrintSeparator();

            LoginScreen screen = new LoginScreen();
            screen.Render();
        }

        private void LoadErrorMessages()
        {
            foreach (string line in FileUtils.FileReader("errors.txt"))
            {
                int pos = -1;

                if ((pos = line.IndexOf(":")) < 0)
                    continue;

                int errorCode;
                if (!int.TryParse(line.Substring(0, pos).Trim(), out errorCode))
                    continue;

                string errorMessage = line.Substring(pos + 1).Trim();

                Constants.ErrorMessages.Add(errorCode, errorMessage);
            }
        }
    }
}
