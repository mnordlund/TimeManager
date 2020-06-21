using System;
using System.Collections.Generic;
using System.Text;

namespace TimeManager.CLI.Commands
{
    class Vacation : ICommand
    {
        public string Command => "vacation";

        public string ShortDescription => "Set a vacation [Not implemented]";

        public string LongDescription => @"
Set a vacation. If no start date or end date is given todays date will be used it's stead.
Dates are given in the format yyyy-mm-dd.
";

        public string Arguments => "[startdate - [end date]]";

        public void Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
