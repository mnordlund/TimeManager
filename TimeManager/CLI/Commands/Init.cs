using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TimeManager.CLI.Helpers;
using TimeManager.CLI.Views;

namespace TimeManager.CLI.Commands
{
    class Init : ICommand
    {
        public string Command => "init";

        public string ShortDescription => "Initialises a new save file";

        public string Arguments => "[filename]";

        public string LongDescription => @"
Initialises a new save file if no filename is given it will be asked for.
A complete path can be used to choose where to save the file.
The file will be saved in the settings to be used as default from now on.
You will be prompted with a set of quetions to initialise the new file and set up a first employment contract.
";

        public void Run(string[] args)
        {
            string filename;
            if (args.Length == 0)
            {
                Console.WriteLine("First we need to know the file name for the save");
                filename = Question.AskString("Filename", "MyNewFile");
            }
            else
            {
                filename = args[0];
            }

            Console.WriteLine("Now let's start by creating our first employment contract..");

            var contractHandler = HandlerFactory.GetContractHandler();

            var contract = contractHandler.CreateNewContract();

            do
            {
                var updateContractView = new UpdateContractView(contract);
                updateContractView.Show();

                var contractView = new ContractView(contract);
                contractView.Show();
            } while (!Question.AskBool("Is this correct?", true));
        }
    }
}
