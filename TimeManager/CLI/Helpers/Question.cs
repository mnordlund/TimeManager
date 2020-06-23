using System;
using System.Text.RegularExpressions;

namespace TimeManager.CLI.Helpers
{
    class Question
    {
        public static string AskString(string prompt, string defaultValue = null)
        {
            if (defaultValue == null)
            {
                Console.Write($"{prompt}: ");
            }
            else
            {
                Console.Write($"{prompt} [{defaultValue}]: ");
            }

            var input = Console.ReadLine();

            if (String.IsNullOrEmpty(input)) return defaultValue;

            return input;
        }

        public static string AskStringWithValidation(string prompt, Regex validation, string defaultValue = null)
        {
            while (true)
            {
                var input = AskString(prompt, defaultValue);
                if (validation.IsMatch(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Not a valid input.");
                }
            }
        }

        public static DateTime AskDate(string prompt, string defaultValue = null)
        {
            DateTime? date = null;
            while (date == null)
            {
                var input = AskString(prompt, defaultValue);
                try
                {
                    date = DateTime.SpecifyKind(DateTime.Parse(input), DateTimeKind.Local);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid format, please use a correct date format.");
                }
            }
            return (DateTime)date;
        }

        public static DateTime? AskNullableDate(string prompt, string defaultValue = null)
        {
            DateTime? date = null;
            var input = AskString(prompt, defaultValue);
            try
            {
                date = DateTime.SpecifyKind(DateTime.Parse(input), DateTimeKind.Local);
            }
            catch (FormatException)
            {

            }
            return date;
        }

        public static TimeSpan AskTimeSpan(string prompt, string defaultValue = null)
        {
            // TODO rewrite to accept "hh:mm" as format.
            TimeSpan? time = null;

            while(time == null)
            {
                var input = AskString(prompt, defaultValue);
                try
                {
                    time = TimeSpan.ParseExact(input, @"hh\:mm", null);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid format, please use a correct time format hh:mm");
                }
            }
            return (TimeSpan)time;
        }

        public static int AskInt(string prompt, int defaultValue = 0)
        {
            while (true)
            {
                var input = AskString(prompt, defaultValue.ToString());

                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Only integers are allowed.");
                }
            }
        }

        public static bool AskBool(string prompt, bool defaultValue)
        {
            var input = AskStringWithValidation(prompt, new Regex(@"^[yY]|[nN]$"),defaultValue ? "Y":"N");
            return input.ToLower().Equals("y");
        }
    }
}
