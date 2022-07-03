using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Test.Fakes
{
    internal class FakeAccount : IAccount
    {
        private decimal amount = 100;

        public decimal Amount { get => amount; set => amount = value; }

        public void DepositMoney(decimal amount)
        {
            Amount += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            Amount -= amount;

        }
    }
}
