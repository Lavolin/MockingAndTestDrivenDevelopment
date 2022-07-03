using BankSoftware.Contracts;

namespace BankSoftware
{
    public class User
    {
        private ILogger logger;

        public User()
        {

        }

        public User(ILogger logger)
        {
            this.logger = logger;
        }
        public string Name { get; set; }
        public IAccount Account { get; set; }

        public override string ToString()
        {
            if (logger != null)
            {
                logger.Log($"{Name}: {Account.Amount}lv");
            }
            return $"{Name}: {Account.Amount}lv";
        }
    }
}