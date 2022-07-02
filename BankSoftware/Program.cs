using BankSoftware.Contracts;
using System;

namespace BankSoftware
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            IBankDb database = new BankTextDb(); // ако решим да променим базата, се променя само този ред!!! (dependancy Inversion)

            Bank bank = new Bank(database);

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "new")
                {
                    Console.WriteLine("Name?");
                    string name = Console.ReadLine();

                    Console.WriteLine("Amount?");
                    int amount = int.Parse(Console.ReadLine());

                    User newUser = new User()
                    {
                        Name = name,
                        Account = new Account()
                        {
                            Amount = amount,
                        }
                    };

                    bank.AddUser(newUser);
                }

                if (command == "transfer")
                {
                    string from = Console.ReadLine();
                    string to = Console.ReadLine();
                    int amount = int.Parse(Console.ReadLine());

                    bank.TransferMoney(from, to, amount);
                }

                if (command == "list")
                {
                    foreach (var user in bank.Users)
                    {
                        Console.WriteLine(user);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
