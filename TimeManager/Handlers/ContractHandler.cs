using System;
using System.Collections.Generic;
using TimeManager.DataTypes;
using TimeManager.Exceptions;
using TimeManager.Interfaces;
using TimeManager.Stores;

namespace TimeManager.Handlers
{
    class ContractHandler : IContractHandler
    {
        private IContractStore ContractStore { get; set; }


        public ContractHandler(IContractStore contractStore)
        {
            ContractStore = contractStore;

        }

        public ContractHandler()
        {
            ContractStore = StoreFactoryProducer.GetStoreFactory().CreateContractStore();
        }

        public Contract CreateNewContract()
        {
            var currentContract = ContractStore.GetCurrentContract();

            if (currentContract != null)
            {
                var contract = new Contract(currentContract);

                return contract;
            }

            return new Contract();
        }

        public void SetNewCurrentContract(Contract contract)
        {
            var oldContract = ContractStore.GetCurrentContract();
            if (oldContract != null)
            {
                oldContract.EndDate = contract.StartDate.Date.AddDays(-1);
                ContractStore.UpdateContract(oldContract);
            }
            
            ContractStore.StoreContract(contract);
        }

        public Contract GetContractForDate(DateTime date)
        {
            var contract = ContractStore.GetContract(date);

            if (contract == null) throw new NoValidContractException();

            return contract;
        }

        public IEnumerable<Contract> ListAllContracts()
        {
            return ContractStore.GetAllContracts();
        }

        public Contract GetCurrentContract()
        {
            var contract = ContractStore.GetCurrentContract();

            if (contract == null) throw new NoValidContractException();
            return contract;
        }
    }
}
