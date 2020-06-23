using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Stores
{
    class ContractStoreEF : IContractStore
    {
        // TODO store contracts permanently
        private Contract CurrentContract { get; set; }

        private DBContextSqlite DbContext { get; set; }

        public ContractStoreEF(DBContextSqlite dbContext)
        {
            DbContext = dbContext;
        }

        public void DeleteContract(Contract contract)
        {
            DbContext.Contracts.Remove(contract);
            DbContext.SaveChanges();
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            return DbContext.Contracts;
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

            DbContext.Contracts.Add(contract);
            DbContext.SaveChanges();
        }

        public void UpdateContract(Contract contract)
        {
            throw new NotImplementedException();
        }
    }
}
