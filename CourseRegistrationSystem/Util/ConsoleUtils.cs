using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Principal;

namespace CourseRegistrationSystem
{
    public class ConsoleUtils
    {
        private static readonly string[] Logo =
        {
            @"         __           ",
            @" _(\    |@@|          ",
            @"(__/\__ \--/ __       ",
            @"   \___|----|  |   __ ",
            @"       \ }{ /\ )_ / _\",
            @"       /\__/\ \__O(__ ",
            @"      (--/\--)    \__/",
            @"      _)(  ) (_       ",
            @"     `---''---`       ",
        };

        private static readonly string[] Credits =
        {
            @"CourseRegistrationSystem by Callista Rossary Chang",
        };

        public static void WriteHeader(ConsoleColor logoColor)
        {
            Console.ForegroundColor = logoColor;
            WriteLinesCentered(Logo);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            WriteLinesCentered(Credits);

            Console.ResetColor();
            WriteSeperator();
        }

        public static void WriteSeperator()
        {
            Console.WriteLine("".PadLeft(Console.WindowWidth, '_'));
        }

        private static void WriteLinesCentered(string[] lines)
        {
            int longestLine = lines.Max(line => line.Length);
            lines.ToList().ForEach(line => WriteLineCentered(line, longestLine));
        }

        private static void WriteLineCentered(string line, int referenceLength)
        {
            Console.WriteLine(line.PadLeft(line.Length + Console.WindowWidth / 2 - referenceLength / 2));
        }

        /// <example>
        /// arg0 arg1 arg2 -- 3 args: "arg0", "arg1", and "arg2"
        /// arg0 arg1 "arg2 arg3" -- 3 args: "arg0", "arg1", and "arg2 arg3"
        /// </example>
        public static IList<string> ParseArgs(string line)
        {
            List<string> args = new List<string>();
            bool quote = false;

            for (int to = 0, from = 0; to <= line.Length; to++)
            {
                // add to args if space or end of line and not in a quote
                if ((to == line.Length || line[to] == ' ') && !quote)
                {
                    if (to - from > 0)
                    {
                        // trim spaces and double quotes
                        string arg = line[from..to].Trim(' ', '"');
                        args.Add(arg);
                    }
                    // set new from for the next arg
                    from = to + 1;
                }
                else if (line[to] == '"')
                {
                    quote = !quote;
                }
            }
            return args;
        }
    }
}
