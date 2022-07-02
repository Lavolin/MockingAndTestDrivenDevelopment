using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Test.Fakes
{
    internal class FakeAccount : IAccount
    {
        public decimal Amount => 100;

        public void DepositMoney(decimal amount)
        {
            
        }

        public void WithdrawMoney(decimal amount)
        {
            
        }
    }
}
