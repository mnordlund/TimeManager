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

        public Contract CurrentContract { get => ContractStore.GetCurrentContract(); }

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
                var contract = new Contract()
                {
                    StartDate = DateTimeOffset.Now,
                    EndDate = null,
                    Employer = currentContract.Employer,
                    HoursPerWeek = currentContract.HoursPerWeek,
                    Salary = currentContract.Salary,
                    ReportInterval = currentContract.ReportInterval,
                    VacationDays = currentContract.VacationDays,
                    WorkdayLength = currentContract.WorkdayLength,
                    VacationYearStart = currentContract.VacationYearStart,
                };

                return contract;
            }

            return new Contract();
        }

        public void AddContract(Contract contract)
        {
            ContractStore.GetCurrentContract().EndDate = contract.StartDate.AddDays(-1);
        }

        public void CheckCurrentContract()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            if (ContractState.CurrentContract.StartDate >= now && (ContractState.CurrentContract.EndDate <= now || ContractState.CurrentContract.EndDate == null)) return;

            ContractState.CurrentContract = GetContractForDate(now);
        }

        public Contract GetContractForDate(DateTimeOffset date)
        {
            foreach (var contract in Contracts)
            {
                if (contract.StartDate >= date && contract.EndDate <= date)
                {
                    return contract;
                }
            }

            throw new NoValidContractException();
        }
    }
}
