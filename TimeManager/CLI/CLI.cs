﻿using System;
using System.Reflection;
using TimeManager.CLI.Commands;

namespace TimeManager.CLI
{
    class CLI
    {
        public void InterpretArguments(string[] args)
        {
            ICommand command = null;
            if (args.Length == 0)
            {
                new Help().Run(null);
                return;
            }

            var commandList = CommandHandler.Instance.Commands;

            foreach (var current in commandList)
            {
                if (current.Command.Equals(args[0]))
                {
                    command = current;
                    break;
                }
            }
            if (command != null)
            {
                command.Run(args[1..]);
            }
            else
            {
                Console.WriteLine($"Unknown command: '{args[0]}' use 'help' to list commands.");
            }
        }
        public static void Run(string[] args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine($"TimeManager {version.Major}.{version.Minor}.{version.Build} CLI...");
            var cli = new CLI();
            cli.InterpretArguments(args);
        }
    }
}
