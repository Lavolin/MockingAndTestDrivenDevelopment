using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Test.Fakes
{
    public class FakeCommisionTime : ITimeHelper
    {
        public bool ShouldGetCommision()
        {
            return true;
        }
    }

    public class FakeTime : ITimeHelper
    {
        public bool ShouldGetCommision()
        {
            return false;
        }
    }
}
