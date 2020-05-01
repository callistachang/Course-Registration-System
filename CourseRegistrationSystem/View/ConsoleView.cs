using System;
using System.Collections.Generic;

namespace CourseRegistrationSystem
{
    public class ConsoleView
    {
        public Dictionary<string, Option> Options;

        public ConsoleView()
        {
            Options = new Dictionary<string, Option>();
        }

        public void Start()
        {
            Log.Info("Type 'help' for a list of options.");

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

        public OptionResult HandleHelp(string command, IList<string> args)
        {
            Log.Unimplemented("HandleHelp");
            return OptionResult.Okay;
        }

        #region Helper Functions
        public void Add(string name, string description, OptionHandler handler)
        {
            Options[name] = new Option(name, "", description, handler);
        }

        public void Add(string name, string usage, string description, OptionHandler handler)
        {
            Options[name] = new Option(name, usage, description, handler);
        }

        public Option GetOption(string name)
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
