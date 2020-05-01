using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Controller;
using CourseRegistrationSystem.Database;
using CourseRegistrationSystem.Model;

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
            WriteOptionForm();
        }

        public void WriteLoginForm(UserType userType)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Utils.ReadPassword();
            Log.Debug(username);
            Log.Debug(password);
        }

        public void WriteRegisterForm()
        {
            Console.Write("Assigned matric number: ");
        }

        public void WriteOptionForm()
        {
            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("(1) Log in as student");
            Console.WriteLine("(2) Log in as staff");
            Console.WriteLine("(3) Register student account");
            Console.WriteLine("(4) Exit");

            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                        case 1:
                            WriteLoginForm(UserType.Student);
                            break;
                        case 2:
                            WriteLoginForm(UserType.Staff);
                            break;
                        case 3:
                            WriteRegisterForm();
                            break;
                        case 4:
                            Log.Info("Exiting...");
                            Environment.Exit(0);
                            break;
                        default:
                            Log.Error("Invalid option.");
                            break;
                    }
                }
                else
                {
                    Log.Error("Invalid option.");
                }
            }
        }
    }
}
