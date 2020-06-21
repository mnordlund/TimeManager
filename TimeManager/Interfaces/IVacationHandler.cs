using System;
using System.Collections.Generic;
using System.Text;
using TimeManager.DataTypes;

namespace TimeManager.Interfaces
{
    interface IVacationHandler
    {
        public void UseVacationDay();
        public void CheckForNewVacationYear(Contract contract);
    }
}
