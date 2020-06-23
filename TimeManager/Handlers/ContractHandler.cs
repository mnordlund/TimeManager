using System;
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
            ContractStore = StoreFactory.CreateContractStore();
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
                oldContract.EndDate = contract.StartDate.Date;
                ContractStore.UpdateContract(oldContract);
            }

            ContractStore.StoreContract(contract);
        }

        public Contract GetContractForDate(DateTimeOffset date)
        {
            var contract = ContractStore.GetContract(date);

            if (contract == null) throw new NoValidContractException();

            return contract;
        }
    }
}
