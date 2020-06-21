using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TimeManager.CLI
{
    class CommandHandler
    {
        public IEnumerable<ICommand> Commands { get; set; }

        // Singleton
        public static CommandHandler Instance { get; } = new CommandHandler();

        private CommandHandler()
        {
            CreateCommandList();
        }

        private void CreateCommandList()
        {
            var commandList = new List<ICommand>();

            foreach (var commandType in GetCommandTypes())
            {
                commandList.Add((ICommand)Activator.CreateInstance(commandType));
            }

            Commands = commandList;
        }

        private IEnumerable<Type> GetCommandTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var commandNameSpace = "TimeManager.CLI.Commands";

            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, commandNameSpace, StringComparison.Ordinal));
        }

    }
}
