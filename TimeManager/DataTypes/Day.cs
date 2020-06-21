using System;
using System.Collections.Generic;

namespace TimeManager.DataTypes
{
    public enum DayType
    {
        WorkDay,
        VacationDay,
        DayOff
    }
    class Day
    {
        public DateTime Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public IEnumerable<TimeSpan> Breaks { get; set; }
        public IEnumerable<TimeSpan> ExtraWork { get; set; }
        public DayType DayType { get; set; }
        public string Comment { get; set; }
    }
}
