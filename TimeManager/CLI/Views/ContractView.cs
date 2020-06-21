using System;
using TimeManager.DataTypes;

namespace TimeManager.CLI.Views
{
    class ContractView : IView
    {
        public Contract Contract { get; set; }
        public ContractView(Contract contract)
        {
            Contract = contract;
        }

        public void Show()
        {
            var startDate = Contract.StartDate.ToString("yyyy-MM-dd");
            Console.WriteLine($"Start date: {startDate}");
            var endDate = "-";
            if (Contract.EndDate != null)
            {
                Contract.EndDate?.ToString("yyyy-MM-dd");
            }
            Console.WriteLine($"End date: {endDate}");

            Console.WriteLine($"Employer: {Contract.Employer}");

            Console.WriteLine($"Hours per week: {Contract.HoursPerWeek}");

            var workdayLength = Contract.WorkdayLength.ToString(@"hh\:mm");
            Console.WriteLine($"Workday length: {workdayLength}");

            Console.WriteLine($"Salary: {Contract.Salary}");

            var reportInterval = Contract.ReportInterval.ToString(@"hh\:mm");
            Console.WriteLine($"Smallest reported intervall: {reportInterval}");

            Console.WriteLine($"Vacation days: {Contract.VacationDays}");

            var vacationYearStart = Contract.VacationYearStart.ToString("yyyy-MM-dd");
            Console.WriteLine($"Vacation year start: {vacationYearStart}");

            Console.WriteLine($"Max stroed vacation days: {Contract.MaxStoredVacationDays}");
        }
    }
}
