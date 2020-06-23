using System;
using System.Collections.Generic;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class ContractStore : IContractStore
    {
        // TODO store contracts permanently
        private Contract CurrentContract { get; set; }
        private Stack<Contract> Contracts { get; set; }

        public ContractStore()
        {
            // TODO Setup database context.
            Contracts = new Stack<Contract>();
        }

        public void DeleteContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            throw new NotImplementedException();
        }

        public Contract GetContract(DateTimeOffset date)
        {
            throw new NotImplementedException();
        }

        public Contract GetCurrentContract()
        {
            return CurrentContract;
        }

        public void StoreContract(Contract contract)
        {
            // TODO: Check if contract time overlaps any given contract.
            contract.Guid = Guid.NewGuid();

            if (contract.StartDate <= DateTimeOffset.Now.Date && (contract.EndDate == null || contract.EndDate >= DateTimeOffset.Now.Date))
            {
                CurrentContract = contract;
            }

            Contracts.Push(contract);
        }

        public void UpdateContract(Contract contract)
        {
            throw new NotImplementedException();
        }
    }
}
