using System;
using System.Collections;
using System.Collections.Generic;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IContractHandler
    {
        public Contract CreateNewContract();
        public void SetNewCurrentContract(Contract contract);
        public IEnumerable<Contract> ListAllContracts();
        public Contract GetContractForDate(DateTime date);
        public Contract GetCurrentContract();

    }
}
