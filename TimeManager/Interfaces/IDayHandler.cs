using System;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IDayHandler
    {
        public Day CreateNewWorkday(DateTime date);
        public Day CreateNewVacationDay(DateTime date);
        public Day CreateNewDayOff(DateTime date, string Comment);

    }
}
