using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware
{
    public class TimeHelper : ITimeHelper
    {
        public virtual bool ShouldGetCommision()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                return true;
            }

            return false;
        }
    }
}
