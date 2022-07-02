using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Contracts
{
    public interface IBankDb
    {
        void Update(Bank bank);

        List<User> ReadUsers();
    }
}
