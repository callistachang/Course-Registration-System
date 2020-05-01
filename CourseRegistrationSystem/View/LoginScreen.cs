using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem.View
{
    public class LoginScreen : IScreen
    {
        public void Render()
        {
            WriteOptionForm();
        }

        private void WriteOptionForm()
        {
            Log.Info("Choose one of the following options:");
            Log.Info("(1) Log in as student");
            Log.Info("(2) Log in as staff");
            Log.Info("(3) Register student account");
            Log.Info("(4) Exit");

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
                            WriteRegisterStudentForm();
                            break;
                        case 4:
                            ConsoleUtils.Exit(0);
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

        private void WriteLoginForm(UserType userType)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Utils.ReadPassword();

            Log.Unimplemented("Account exists");

            IScreen screen;
            if (userType == UserType.Staff)
                screen = new AdminScreen();
            else
                screen = new StudentScreen();

            screen.Render();
        }

        private void WriteRegisterStudentForm()
        {
            Console.Write("Matric number: ");
            Log.Unimplemented("Student exists");
            // check that it doesn't already have an associated account
            // and that it has been registered by the staff

            Console.Write("New username: ");
            string username = Console.ReadLine();
            Console.Write("New password: ");
            string password = Utils.ReadPassword();
            Console.Write("Confirm password: ");
            string confirmPassword = Utils.ReadPassword();

            Log.Unimplemented("Account created");

            Render();
        }
    }
}
