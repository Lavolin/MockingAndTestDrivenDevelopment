namespace BankSoftware
{
    public class User
    {
        public string Name { get; set; }
        public Account Account { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Account.Amount}lv";
        }
    }
}