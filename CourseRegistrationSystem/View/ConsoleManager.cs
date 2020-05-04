using System;
using System.Linq;
using System.Collections.Generic;

namespace CourseRegistrationSystem
{
    public class ConsoleManager
    {
        public Dictionary<string, Option> Options;

        public ConsoleManager()
        {
            Options = new Dictionary<string, Option>();
        }

        public void InitializeOptions()
        {
            AddOption("help", "Displays this list of options", HandleHelp);
            AddOption("exit", "Exits the system", HandleExit);

            DisplayHelp();

            while (true)
            {
                string line = Console.ReadLine();

                IList<string> args = ConsoleUtils.ParseArgs(line);
                if (args.Count == 0)
                    continue;

                Option option = GetOption(args[0]);
                if (option == null)
                {
                    Log.Info("'{0}' is an invalid option", args[0]);
                    continue;
                }

                OptionResult result = option.Handler(line, args);

                if (result == OptionResult.Break)
                    break;
                else if (result == OptionResult.Fail)
                    Log.Error("Option '{0}' has failed to execute", option.Name);
                else if (result == OptionResult.InvalidArgument)
                    Log.Info("Usage of option '{0}': {1}", option.Name, option.Usage);
            }
        }

        protected OptionResult HandleHelp(string command, IList<string> args)
        {
            DisplayHelp();
            return OptionResult.Okay;
        }

        protected OptionResult HandleExit(string command, IList<string> args)
        {
            ConsoleUtils.Exit(0);
            return OptionResult.Okay;
        }

        private void DisplayHelp()
        {
            int maxLength = Options.Values.Max(opt => opt.Name.Length);
            Log.Info("Available options");

            foreach (Option option in Options.Values.OrderBy(opt => opt.Name))
            {
                Log.Info("  {0}  -  {1}", option.Name.PadRight(maxLength), option.Description);
            }
        }

        #region Helper Functions
        protected void AddOption(string name, string description, OptionHandler handler)
        {
            Options[name] = new Option(name, "", description, handler);
        }

        protected void AddOption(string name, string usage, string description, OptionHandler handler)
        {
            Options[name] = new Option(name, usage, description, handler);
        }

        protected Option GetOption(string name)
        {
            Options.TryGetValue(name, out Option option);
            return option;
        }
        #endregion
    }

    public class Option
    {
        public string Name;
        public string Usage;
        public string Description;
        public OptionHandler Handler;

        public Option(string name, string usage, string description, OptionHandler handler)
        {
            Name = name;
            Usage = usage;
            Description = description;
            Handler = handler;
        }
    }

    public delegate OptionResult OptionHandler(string command, IList<string> args);

    public enum OptionResult
    {
        Okay,
        Fail,
        InvalidArgument,
        Break
    }
}
