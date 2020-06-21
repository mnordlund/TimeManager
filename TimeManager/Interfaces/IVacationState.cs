using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManager.Interfaces
{
    interface IVacationState
    {
        public int RemainingVactionDaysCurrentYear { get; set; }
        public int StoredVacationDays { get; set; }
        public int TotalVacationDays { get;  }
        public DateTimeOffset NextVacationYearStart { get; set; }
    }
}
