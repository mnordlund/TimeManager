using Microsoft.EntityFrameworkCore;
using System;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class StoreFactoryEF: IStoreFactory
    {
        // TODO Create and interface for the DbContexts
        private static DBContextSqlite DbContext;
        private static IContractStore ContractStore { get; set; }

        public StoreFactoryEF(Settings settings)
        {
            switch(settings.DatabaseType)
            {
                case DatabaseTypes.Sqlite:
                    DbContext = new DBContextSqlite(settings.DatabaseFile);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public IDayStore CreateDayStore()
        {
            throw new NotImplementedException();
        }

        public IContractStore CreateContractStore()
        {
            if (ContractStore == null)
            {
                ContractStore = new ContractStoreEF(DbContext);
            }
            return ContractStore;
        }

        public IVacationStore CreateVacationStore()
        {
            throw new NotImplementedException();
        }


    }
}
