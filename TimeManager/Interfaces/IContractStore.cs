using System;
using System.Collections.Generic;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IContractStore
    {
        public Contract GetCurrentContract();
        public IEnumerable<Contract> GetAllContracts();
        public Contract GetContract(DateTime date);
    }
}
