using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace CourseRegistrationSystem
{
    public class ConsoleHelper
    {
        private static readonly string[] Logo =
        {
            @" ________________________ ",
            @"|.______________________.|",
            @"||                      ||",
            @"||                      ||",
            @"||     .-'````'-.       ||",
            @"||    /  _.._    `\     ||",
            @"||   / /`    `-.   ; . .||",
            @"||   | |__ __   \   |   ||",
            @"||.-.| | e`/e`  |   |   ||",
            @"||   | |  |     |   |'--||",
            @"||   | |  '-    |   |   ||",
            @"||   |  \ --'  /|   |   ||",
            @"||   |   `;---'\|   |   ||",
            @"||   |    |     |   |   ||",
            @"||   |  .-'     |   |   ||",
            @"||'--|/`        |   |--.||",
            @"||   ;    .     ;  _.\  ||",
            @"||    `-.;_    /.-'     ||",
            @"||         ````         ||",
            @"||jgs___________________||",
            @"|________________________|"
        };

        private static readonly string[] Credits =
        {
            @"CourseRegistrationSystem by Callista Chang",
            @"For problems and support: https://github.com/callistachang/course-registration-system"
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

        public static void Exit(int exitCode, bool wait = true)
        {
            if (wait && Environment.UserInteractive)
            {
                Log.Info("Press 'Enter' to exit.");
                Console.ReadLine();
            }
            Log.Info("Exiting...");
            Environment.Exit(exitCode);
        }

        public static string[] ParseLine(string line)
        {
            List<string> args = new List<string>();
            bool quote = false;

            
        }

        public static IList<string> ParseLine(string line)
        {
            var args = new List<string>();
            var quote = false;
            for (int i = 0, n = 0; i <= line.Length; ++i)
            {
                if ((i == line.Length || line[i] == ' ') && !quote)
                {
                    if (i - n > 0)
                        args.Add(line.Substring(n, i - n).Trim(' ', '"'));

                    n = i + 1;
                    continue;
                }

                if (line[i] == '"')
                    quote = !quote;
            }

            return args;
        }
    }
}
