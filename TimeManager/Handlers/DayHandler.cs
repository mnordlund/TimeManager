using System;
using System.Collections.Generic;
using TimeManager.DataTypes;
using TimeManager.Interfaces;
using TimeManager.Stores;

namespace TimeManager.Handlers
{
    class DayHandler : IDayHandler
    {
        private IDayStore DayStore { get; set; }

        public DayHandler(IDayStore dayStore)
        {
            DayStore = dayStore;
        }

        public DayHandler()
        {
            DayStore = StoreFactory.CreateDayStore();
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
        private void UnuseVacationDay()
        {
            IVacationState VacationState;
            Contract contract;
            if (VacationState.RemainingVactionDaysCurrentYear >= contract.VacationDays)
            {
                VacationState.StoredVacationDays++;
            }
            else
            {
                VacationState.RemainingVactionDaysCurrentYear++;
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
