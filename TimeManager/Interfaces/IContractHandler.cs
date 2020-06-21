﻿using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IContractHandler
    {
        public Contract CreateNewContract();
        public void AddContract(Contract contract);

    }
}
