using BankSoftware.Test.Fakes;
using NUnit.Framework;

namespace BankSoftware.Test
{
    public class Tests
    {                               //    1:11
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Transfer_Money_Should_Work()
        {
            User user = new User()
            {
                Name = "Toshko",
                Account = new Account()
                {
                    Amount = 50,
                }
            };

            User user1 = new User()
            {
                Name = "Henito",
                Account = new Account()
                {
                    Amount = 50,
                }
            };

            Bank bank = new Bank(new FakeDb());
            
            bank.TransferMoney("Toshko", "Henito", 30);

            Assert.That(bank.Users[0].Account.Amount, Is.EqualTo(20));
            Assert.AreEqual(80, bank.Users[1].Account.Amount);
        }
    }
}