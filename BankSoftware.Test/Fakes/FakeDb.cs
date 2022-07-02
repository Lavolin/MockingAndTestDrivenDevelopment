using BankSoftware.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSoftware.Test.Fakes
{
    internal class FakeDb : IBankDb
    {
        public List<User> ReadUsers()
        {
            return new List<User>()
                {
                    new User()
                    {
                        Name = "Toshko",
                        Account = new FakeAccount()
                    },
                    new User()
                    {
                        Name = "Henito",
                        Account = new FakeAccount()
                        
                    }
                };
             
        }

        public void Update(Bank bank)
        {
            
        }
    }
}
