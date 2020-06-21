using System;
using System.Collections.Generic;
using System.Dynamic;
using TimeManager.DataTypes;
using TimeManager.Exceptions;
using TimeManager.Interfaces;

namespace TimeManager.Handlers
{
    class ContractHandler : IContractHandler
    {
        private Stack<Contract> Contracts { get; set; }
        private IContractState ContractState { get; set; }

        public ContractHandler(IContractState contractState)
        {
            ContractState = contractState;

            // TODO read contract list from database
            Contracts = new Stack<Contract>();
        }

        public ContractHandler()
        {
            // TODO Get state from database
            ContractState = new CurrentState();
        }

        public Contract CreateNewContract()
        {
            var currentContract = ContractState.CurrentContract;

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
            ContractState.CurrentContract.EndDate = contract.StartDate.AddDays(-1);
            Contracts.Push(contract);


        }

        public void CheckCurrentContract()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            if (ContractState.CurrentContract.StartDate >= now && ContractState.CurrentContract.EndDate <= now) return;

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
