
using System;
using TimeManager.Exceptions;
using TimeManager.Interfaces;

namespace TimeManager.DataTypes
{
    class CurrentState : IVacationState, IContractState
    {
        public Contract CurrentContract { get; set; }
        public TimeSpan Remeinder { get; set; }
        public int RemainingVactionDaysCurrentYear { get; set; }
        public int StoredVacationDays { get; set; }
        public int TotalVacationDays { get => RemainingVactionDaysCurrentYear + StoredVacationDays; }
        public DateTimeOffset NextVacationYearStart { get; set; }

        public Day CurrentDay { get; set; }




    }
}
