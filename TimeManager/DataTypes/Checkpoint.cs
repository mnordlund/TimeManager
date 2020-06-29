using System;
using System.ComponentModel.DataAnnotations;

namespace TimeManager.DataTypes
{
    class Checkpoint
    {
        [Key]
        public DateTime date {get; set;}
        public DayTimeSpan CurrentOvertime { get; set; }
        public DayTimeSpan CurrentRemainder { get; set; }

    }
}
