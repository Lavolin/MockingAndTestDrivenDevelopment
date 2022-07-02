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

        public Bank(IBankDb database)   // dependancy inversion
        {
            this.database = database;
            Users = database.ReadUsers();

        }

        public List<User> Users { get; set; }
        public void TransferMoney(User from, User to, decimal amount)
        {
            from.Account.WithdrawMoney(amount);
            to.Account.DepositMoney(amount);

            database.Update(this);
        }

        public void TransferMoney(string fromName, string toName, decimal amount)
        {
            User from = Users.First(x => x.Name == fromName);
            User to = Users.First(x => x.Name == toName);
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
