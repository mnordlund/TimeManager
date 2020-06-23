using System;
using System.Reflection;

namespace TimeManager.CLI.Commands
{
    class Help : ICommand
    {
        public string Command => "help";

        public string ShortDescription => "Lists all commands or displays help about a command.";

        public string Arguments => "[command]";

        public string LongDescription => @"
If no command is given a list of all commands with a short description of each is shown.
If a command is given a more comprehensive help text about that command is displayed.
";

        public void Run(string[] args)
        {
            var commandList = CommandHandler.Instance.Commands;

            var executable = Assembly.GetExecutingAssembly().GetName().Name;

            if (args == null || args.Length == 0)
            {
                Console.WriteLine($"Usage: {executable} <command> [command arguments]");
                Console.WriteLine("Commands:");
                foreach(var command in commandList)
                {

                    Console.WriteLine($"{command.Command} {command.Arguments} - {command.ShortDescription}");
                }
            }
            else
            {
                ICommand command = null;
                foreach(var currentCommand in commandList)
                {
                    if(currentCommand.Command.Equals(args[0]))
                    {
                        command = currentCommand;
                        break;
                    }
                }

                if(command == null)
                {
                    Console.WriteLine($"Unknown command {args[0]} use {executable} help to list all commands.");
                    return;
                }

                Console.WriteLine($"Usage: {executable} {command.Command} {command.Arguments}");
                Console.WriteLine(command.LongDescription);

            }
        }
    }
}
