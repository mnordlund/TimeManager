using System;
using System.Collections.Generic;
using TimeManager.DataTypes;
using TimeManager.Interfaces;

namespace TimeManager.Handlers
{
    class DayHandler
    {


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

        public Day CreateNewVacationDay(DateTime date, IVacationHandler currentState)
        {
            var vacationDay = new Day()
            {
                Date = date,
                DayType = DayType.VacationDay
            };

            currentState.UseVacationDay();
            return vacationDay;
        }

        public static Day CreateNewDayOff(DateTime date, string Comment)
        {
            var dayOff = new Day()
            {
                Date = date,
                Comment = Comment,
                DayType = DayType.DayOff,
            };

            return dayOff;
        }
    }
}
