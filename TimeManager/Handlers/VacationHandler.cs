using System;
using TimeManager.DataTypes;
using TimeManager.Exceptions;
using TimeManager.Interfaces;

namespace TimeManager.Handlers
{
    class VacationHandler : IVacationHandler
    {
        private IVacationState VacationState { get; set; }

        public void UseVacationDay()
        {
            if (VacationState.TotalVacationDays <= 0)
            {
                throw new VacationDaysExceededException();
            }

            if (VacationState.RemainingVactionDaysCurrentYear >= 1)
            {
                VacationState.RemainingVactionDaysCurrentYear--;
            }
            else
            {
                VacationState.StoredVacationDays--;
            }
        }

        public void CheckForNewVacationYear(Contract contract)
        {
            if (DateTimeOffset.Now < VacationState.NextVacationYearStart) return;

            VacationState.NextVacationYearStart = contract.VacationYearStart.AddYears((DateTimeOffset.Now.Year - contract.VacationYearStart.Year) + 1);

            VacationState.StoredVacationDays = Math.Max(VacationState.StoredVacationDays + VacationState.RemainingVactionDaysCurrentYear, contract.MaxStoredVacationDays);

            VacationState.RemainingVactionDaysCurrentYear = contract.VacationDays;
        }
    }
}
