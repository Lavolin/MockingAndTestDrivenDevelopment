using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        [Test]
        public void AddMethod_ShouldAdd_Transaction_If_DataIsValid()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            IChainblock chainblock = new Chainblock();
            chainblock.Add(transaction);
            chainblock.Add(transaction); // тестваме дали се добавят уникални транзакции

            Assert.True(chainblock.Contains(transaction));

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void ContainsMethod_Should_ReturnTrue_IfData_Exist()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            ITransaction transaction2 = new Transaction
            {
                Id = 2,
                Status = TransactionStatus.Successfull,
                From = "Eli",
                To = "Adi",
                Amount = 150
            };

            IChainblock chainblock = new Chainblock();

            chainblock.Add(transaction);
            

            Assert.True(chainblock.Contains(transaction));
            Assert.True(chainblock.Contains(transaction.Id));

            Assert.False(chainblock.Contains(transaction2));
            Assert.False(chainblock.Contains(transaction2.Id));

           
        }

        [Test]
        public void ChangeTransactionStatus_ShouldChangeStatus_IfDataExist()
        {
            // Arrange
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            IChainblock chainblock = new Chainblock();
            chainblock.Add(transaction);

            // Act

            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            //Assert
            ITransaction chainblockTransaction = chainblock.GetById(1);

            Assert.AreEqual(TransactionStatus.Failed, chainblockTransaction.Status);

        }


        [Test]
        public void ChangeTransactionStatus_ShouldThrowException_IfDataDoesnExist()
        {
            // Arrange
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Successfull,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            IChainblock chainblock = new Chainblock();
            chainblock.Add(transaction);

            // Act

            chainblock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            //Assert
            ITransaction chainblockTransaction = chainblock.GetById(1);

            Assert.AreEqual(TransactionStatus.Failed, chainblockTransaction.Status);

        }
    }
}
