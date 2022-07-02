using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Contracts
{
    public interface IAccount
    {
        decimal Amount { get; }
        void DepositMoney(decimal amount);

        void WithdrawMoney(decimal amount);

    }
}
