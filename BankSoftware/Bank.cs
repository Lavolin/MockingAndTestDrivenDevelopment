using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSoftware
{
    public class Bank
    {
        private IBankDb database;
        private readonly ITimeHelper time;

        public Bank(IBankDb database, ITimeHelper time)   // dependancy inversion
        {
            this.database = database;
            this.time = time;
            Users = database.ReadUsers();

        }

        public List<User> Users { get; set; }
        public void TransferMoney(User from, User to, decimal amount)
        {
            if (time.ShouldGetCommision())
            {
                from.Account.WithdrawMoney(1);
                to.Account.WithdrawMoney(1);
            }

            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);

            database.Update(this);
        }

        public void TransferMoney(string fromName, string toName, decimal amount)
        {
            User from = Users.First(x => x.Name == fromName);
            User to = Users.First(x => x.Name == toName);

            if (time.ShouldGetCommision())
            {
                from.Account.WithdrawMoney(1);
                to.Account.WithdrawMoney(1);
            }

            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);

            database.Update(this);

        }

        public void AddUser(User user)
        {
            Users.Add(user);
            database.Update(this);

        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
            database.Update(this);

        }
    }
}
