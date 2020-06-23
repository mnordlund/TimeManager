using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TimeManager.DataTypes
{
    class VacationState
    {
        [Key]
        public int year { get; set; }
        public int RemainingVactionDays { get; set; }
        public int StoredVacationDays { get; set; }
        public int TotalVacationDays { get; }
    }
}
