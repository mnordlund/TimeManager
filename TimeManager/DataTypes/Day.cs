using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public DateTime Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public IEnumerable<DayTimeSpan> Breaks { get; set; }
        public IEnumerable<DayTimeSpan> ExtraWork { get; set; }
        public DayType DayType { get; set; }
        public string Comment { get; set; }
    }
}
