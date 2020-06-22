using System;
using System.Collections.Generic;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IDayStore
    {
        /// <summary>
        /// Get all days in store
        /// </summary>
        public IEnumerable<Day> GetAllDays();
        /// <summary>
        /// Get all days in year
        /// </summary>
        public IEnumerable<Day> GetDaysInYear(int year);
        /// <summary>
        /// Get all days in month. Month is 0 based [0 .. 11]
        /// </summary>
        public IEnumerable<Day> GetDaysInMonth(int year, int month);
        /// <summary>
        /// Get all days in week
        /// </summary>
        public IEnumerable<Day> GetDaysInWeek(int year, int week);
        /// <summary>
        /// Get day for a date, null if no day stored for the date.
        /// </summary>
        public Day GetDay(DateTime date);

        /// <summary>
        /// Add a day to the store.
        /// </summary>
        public void AddDay(Day day);
        /// <summary>
        /// Update day in store.
        /// </summary>
        public void UpdateDay(Day day);
        /// <summary>
        /// Delete day from store.
        /// </summary>
        public void DeleteDay(DateTime date);
    }
}
