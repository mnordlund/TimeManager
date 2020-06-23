using System;
using System.Collections.Generic;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IContractStore
    {
        /// <summary>
        /// Will always give the current contract, if such a contract exists. Null otherwise.
        /// </summary>
        public Contract GetCurrentContract();
        /// <summary>
        /// Store a new contract in the store
        /// </summary>
        public void StoreContract(Contract contract);
        /// <summary>
        /// Update a contract in the store.
        /// </summary>
        public void UpdateContract(Contract contract);
        /// <summary>
        /// Delete a contract from the store
        /// </summary>
        public void DeleteContract(Contract contract);
        /// <summary>
        /// List all contracts in the store
        /// </summary>
        public IEnumerable<Contract> GetAllContracts();
        /// <summary>
        /// Get the contract valid at a specfic date. Return null if no contract was valid at the given date.
        /// </summary>
        public Contract GetContract(DateTimeOffset date);
    }
}
