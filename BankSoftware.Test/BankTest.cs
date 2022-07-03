using BankSoftware.Contracts;
using BankSoftware.Test.Fakes;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BankSoftware.Test
{
    public class Tests
    {
        private List<User> fakeUsers;
        private int cals = 0;

        [SetUp]
        public void Setup()
        {
            Mock<IAccount> accountMock = new Mock<IAccount>();

            accountMock
                .Setup(a => a.Amount)
                .Returns(100)
                .Callback
                (() =>
                    {
                        cals++;
                    }
                );

            fakeUsers = new List<User>() {
                    new User()
                    {
                        Name = "Toshko",
                        Account = new FakeAccount() // не използваме accountMock , защото не са настроени
                    },
                    new User()
                    {
                        Name = "Henito",
                        Account = new FakeAccount() // не използваме accountMock , защото не са настроени

                    }
                };
        }

        [Test]
        public void Test_Transfer_Money_During_Normal_Hours_Should_Work()
        {
            Mock<ITimeHelper> timeMock = new Mock<ITimeHelper>();
            timeMock.Setup(t => t.ShouldGetCommision()).Returns(false);


            Mock<IBankDb> dbMock = new Mock<IBankDb>();

            dbMock
                .Setup(db => db.ReadUsers())
                .Returns(fakeUsers);

            Bank bank = new Bank(dbMock.Object, timeMock.Object);

            bank.TransferMoney("Toshko", "Henito", 30);

            

            Assert.That(bank.Users[0].Account.Amount, Is.EqualTo(70));
            Assert.That(bank.Users[1].Account.Amount, Is.EqualTo(130));
        }

        [Test]
        public void Test_Transfer_Money_During_Commision_Hours_Should_Work()
        {
            Mock<ITimeHelper> timeMock = new Mock<ITimeHelper>();

            timeMock.Setup(t => t.ShouldGetCommision()).Returns(true);

            Mock<IBankDb> dbMock = new Mock<IBankDb>();

            dbMock
                .Setup(db => db.ReadUsers())
                .Returns(fakeUsers);

            Bank bank = new Bank(dbMock.Object, timeMock.Object);

            bank.TransferMoney("Toshko", "Henito", 30);

            dbMock.Verify(db => db.Update(It.IsAny<Bank>()), Times.AtLeastOnce); // потвърждава, че сме извикали Update метода на базата

            Assert.That(bank.Users[0].Account.Amount, Is.EqualTo(69));
            Assert.That(bank.Users[1].Account.Amount, Is.EqualTo(129));
        }

        [Test]
        public void Test_User_OverrideToString()
        {
            Mock<ILogger> loggerMock = new Mock<ILogger>();

            loggerMock
                .Setup(l => l.Log(It.IsAny<string>()))
                .Callback<string>((s) =>
                    {
                        System.Console.Write("Bre");
                    }
                );

            loggerMock
                .Setup(l => l.Log(": 0lv"))
                .Callback<string>((s) =>
                    {
                        System.Console.Write("Bre 2");
                    }
                );

            Mock<IAccount> accountMock = new Mock<IAccount>();
            accountMock.Setup(a => a.Amount).Returns(50);

            User user = new User(loggerMock.Object);

            user.Account = accountMock.Object;

            string result = user.ToString();

            Assert.AreEqual(": 50lv", result);
        }
    }
}