using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManager.CLI
{
    interface ICommand
    {
        /// <summary>
        /// Run the command
        /// </summary>
        public void Run(string[] args);
        /// <summary>
        /// Name of the command
        /// </summary>
        public string Command { get; }

        public string ShortDescription { get; }

        public string LongDescription { get; }

        public string Arguments { get; }

    }
}
