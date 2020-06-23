using System;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IVacationStore
    {
        public VacationState GetCurrentVacationState();
        public VacationState GetVacationStateForYear(int year);
        public void UpdateVacationState(VacationState newState);
        public DateTimeOffset GetNextVacationYearStart();
        public DateTimeOffset SetNextVacationYearStart(DateTimeOffset date);
    }
}
