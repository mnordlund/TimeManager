using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManager.DataTypes
{
    class VacationState
    {
        public int RemainingVactionDays { get; set; }
        public int StoredVacationDays { get; set; }
        public int TotalVacationDays { get; }
    }
}
