using System;
using System.Collections.Generic;
using System.Text;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class StoreFactory
    {
        private static IContractStore ContractStore { get; set; }
        public static IDayStore CreateDayStore()
        {
            throw new NotImplementedException();
        }

        public static IContractStore CreateContractStore()
        {
            if (ContractStore == null)
            {
                ContractStore = new ContractStore();
            }
                
            return ContractStore;
        }

        internal static IVacationStore CreateVacationStore()
        {
            throw new NotImplementedException();
        }
    }
}
