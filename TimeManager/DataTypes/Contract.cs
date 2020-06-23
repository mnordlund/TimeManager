
using System;
using System.ComponentModel.DataAnnotations;

namespace TimeManager.DataTypes
{
    /// <summary>
    /// Represents an Employment contract
    /// </summary>
    class Contract
    {
        [Key]
        public Guid Guid { get; set; }
        // Dates
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Employer { get; set; }
        // Hours and salary
        public int HoursPerWeek { get; set; }
        public TimeSpan WorkdayLength { get; set; }
        public int Salary { get; set; }
        public TimeSpan ReportInterval { get; set; }

        // Vacation
        public int VacationDays { get; set; }
        public DateTimeOffset VacationYearStart { get; set; }
        public int MaxStoredVacationDays { get; set; }

        /// <summary>
        /// Create a default contract
        /// </summary>
        public Contract()
        {
            StartDate = DateTime.Today;
            EndDate = null;
            Employer = "Employer";
            HoursPerWeek = 40;
            Salary = 0;
            ReportInterval = new TimeSpan(0, 30, 0);
            VacationDays = 25;
            WorkdayLength = new TimeSpan(8, 0, 0);
            VacationYearStart = new DateTime(DateTime.Now.Year, 4, 1);
        }

        /// <summary>
        /// Create a new contract based on an old contract with new start date.
        /// </summary>
        public Contract(Contract contract)
        {
            StartDate = DateTime.Today;
            EndDate = null;
            Employer = contract.Employer;
            HoursPerWeek = contract.HoursPerWeek;
            Salary = contract.Salary;
            ReportInterval = contract.ReportInterval;
            VacationDays = contract.VacationDays;
            WorkdayLength = contract.WorkdayLength;
            VacationYearStart = contract.VacationYearStart;
        }

    }
}
