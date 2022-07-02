using System;


namespace BankSoftware
{
    public class Account
    {
        public decimal Amount { get; set; }

        public User User { get; set; }

        public string History { get; set; }

        public void DepositMoney(decimal amount)
        {
            Amount += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (Amount < amount)
            {
                throw new ArgumentException("Nema pari!");
            }

            Amount -= amount;
        }
    }
}
