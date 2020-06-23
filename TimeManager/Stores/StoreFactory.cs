using System;
using System.Collections.Generic;
using System.Text;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class StoreFactory
    {
        public static IDayStore CreateDayStore()
        {
            throw new NotImplementedException();
        }

        public static IContractStore CreateContractStore()
        {
            throw new NotImplementedException();
        }

        internal static IVacationStore CreateVacationStore()
        {
            throw new NotImplementedException();
        }
    }
}
