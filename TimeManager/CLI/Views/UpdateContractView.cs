using System;
using System.Collections.Generic;
using System.Text;
using TimeManager.CLI.Helpers;
using TimeManager.DataTypes;

namespace TimeManager.CLI.Views
{
    class UpdateContractView : IView
    {
        public Contract Contract;
        public UpdateContractView(Contract contract)
        {
            Contract = contract;
        }
        public void Show()
        {
            var startDate = Contract.StartDate.ToString("yyyy-MM-dd");
            Contract.StartDate = Question.AskDate("Start date", startDate);
            var endDate = "-";
            if (Contract.EndDate != null)
            {
                Contract.EndDate?.ToString("yyyy-MM-dd");
            }
            Contract.EndDate = Question.AskNullableDate("End date", endDate);

            Contract.Employer =  Question.AskString("Employer", Contract.Employer);

            Contract.HoursPerWeek = Question.AskInt("Hours on a workweek", Contract.HoursPerWeek);

            var workdayLength = Contract.WorkdayLength.ToString(@"hh\:mm");
            Contract.WorkdayLength = Question.AskTimeSpan("Workday length", workdayLength);

            Contract.Salary = Question.AskInt("Salary per month", Contract.Salary);

            var reportInterval = Contract.ReportInterval.ToString(@"hh\:mm");
            Contract.ReportInterval = Question.AskTimeSpan("Smallest reported time unit", reportInterval);

            Contract.VacationDays = Question.AskInt("Vacation days in a year", Contract.VacationDays);

            var vacationYearStart = Contract.VacationYearStart.ToString("yyyy-MM-dd");
            Contract.VacationYearStart = Question.AskDate("Vacation year start", vacationYearStart);

            Contract.MaxStoredVacationDays = Question.AskInt("Maximum stored vacation days", Contract.MaxStoredVacationDays);
        }
    }
}
