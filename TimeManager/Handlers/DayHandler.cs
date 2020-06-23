using System;
using System.Collections.Generic;
using TimeManager.DataTypes;
using TimeManager.Exceptions;
using TimeManager.Interfaces;
using TimeManager.Stores;

namespace TimeManager.Handlers
{
    class DayHandler : IDayHandler
    {
        private IDayStore DayStore { get; set; }
        private IVacationStore VacationStore { get; set; }
        private IContractStore ContractStore { get; set; }

        public DayHandler(IDayStore dayStore, IVacationStore vacationStore, IContractStore contractStore)
        {
            DayStore = dayStore;
            VacationStore = vacationStore;
            ContractStore = contractStore;
        }

        public DayHandler()
        {
            DayStore = StoreFactory.CreateDayStore();
            VacationStore = StoreFactory.CreateVacationStore();
            ContractStore = StoreFactory.CreateContractStore();
        }
        public Day CreateNewWorkday(DateTime date)
        {
            var workDay = new Day()
            {
                Date = date,
                Breaks = new List<TimeSpan>(),
                ExtraWork = new List<TimeSpan>(),
                DayType = DayType.WorkDay
            };
            return workDay;
        }

        public Day CreateNewVacationDay(DateTime date)
        {
            var vacationDay = new Day()
            {
                Date = date,
                DayType = DayType.VacationDay
            };

            return vacationDay;
        }

        public Day CreateNewDayOff(DateTime date, string Comment)
        {
            var dayOff = new Day()
            {
                Date = date,
                Comment = Comment,
                DayType = DayType.DayOff,
            };

            return dayOff;
        }

        public Day GetDay(DateTime date)
        {
            return DayStore.GetDay(date.Date);
        }

        public Day GetToday()
        {
            return DayStore.GetDay(DateTime.Today);
        }

        public void SaveDay(Day day)
        {
            var oldDay = DayStore.GetDay(day.Date);
            if (oldDay == null)
            {
                if(day.DayType == DayType.VacationDay)
                {
                    UseVacationDay();
                }

                DayStore.AddDay(day);
                return;
            }
            else
            {
                if(oldDay.DayType == DayType.VacationDay && day.DayType != DayType.VacationDay)
                {
                    UnuseVacationDay();
                }
                else if(oldDay.DayType != DayType.VacationDay && day.DayType == DayType.VacationDay)
                {
                    UseVacationDay();
                }
                DayStore.UpdateDay(day);
            }
            
        }

        private void UseVacationDay()
        {
            var vacationState = VacationStore.GetCurrentVacationState();
            if (vacationState.TotalVacationDays <= 0)
            {
                throw new VacationDaysExceededException();
            }

            if (vacationState.RemainingVactionDays >= 1)
            {
                vacationState.RemainingVactionDays--;
            }
            else
            {
                vacationState.StoredVacationDays--;
            }

            VacationStore.UpdateVacationState(vacationState);
        }
        private void UnuseVacationDay()
        {
            var vacationState = VacationStore.GetCurrentVacationState();
            var contract = ContractStore.GetCurrentContract();
            if (vacationState.RemainingVactionDays >= contract.VacationDays)
            {
                vacationState.StoredVacationDays++;
            }
            else
            {
                vacationState.RemainingVactionDays++;
            }

            VacationStore.UpdateVacationState(vacationState);
        }

        public void CheckForNewVacationYear()
        {
            var contract = ContractStore.GetCurrentContract();
            var vacationState = VacationStore.GetCurrentVacationState();
            if (DateTimeOffset.Now < VacationStore.GetNextVacationYearStart()) return;

            VacationStore.SetNextVacationYearStart(contract.VacationYearStart.AddYears((DateTimeOffset.Now.Year - contract.VacationYearStart.Year) + 1));

            vacationState.StoredVacationDays = Math.Max(vacationState.StoredVacationDays + vacationState.RemainingVactionDays, contract.MaxStoredVacationDays);

            vacationState.RemainingVactionDays = contract.VacationDays;

            VacationStore.UpdateVacationState(vacationState);
        }
    }
}
