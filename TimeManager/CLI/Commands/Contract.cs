using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeManager.CLI.Helpers;
using TimeManager.CLI.Views;

namespace TimeManager.CLI.Commands
{
    class Contract : ICommand
    {
        public string Command => "contract";

        public string ShortDescription => "Manage contracts";

        public string LongDescription => @"
Commands are:
list - Lists all contracts
current - Shows current contract
new - Create a new contract";

        public string Arguments => "[command]";

        public void Run(string[] args)
        {
            var contractHandler = HandlerFactory.GetContractHandler();
            switch(args[0])
            {
                case "list":
                    ListContracts();
                    break;
                case "current":
                    new ContractView(contractHandler.GetCurrentContract()).Show();
                    break;
                case "new":
                    var contract = contractHandler.CreateNewContract();
                    do
                    {
                        var updateContractView = new UpdateContractView(contract);
                        updateContractView.Show();

                        var contractView = new ContractView(contract);
                        contractView.Show();
                    } while (!Question.AskBool("Is this correct?", true));

                    contractHandler.SetNewCurrentContract(contract);
                    break;

            }
        }

        private void ListContracts()
        {
            var contractHandler = HandlerFactory.GetContractHandler();

            var contracts = contractHandler.ListAllContracts();

            foreach(var contract in contracts)
            {
                Console.WriteLine($"{contract.Employer}, {contract.StartDate:yyyy-MM-dd} - {contract.EndDate:yyyy-MM-dd}");
            }
        }
    }
}
