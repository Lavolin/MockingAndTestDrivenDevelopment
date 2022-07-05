using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private Chainblock chainblock;

        [SetUp]
        public void SetUpMethod()
        {
            this.chainblock = new Chainblock();
        }

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

            Assert.Throws<ArgumentException>(
                () => chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull));

        }

        [Test]
        public void RemoveTransactionByID_Should_RemoveTransaction_IfDataExist()
        {
            //Arrange
            ITransaction transaction = new Transaction
            {
                Id = 12,
                Status = TransactionStatus.Failed,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            this.chainblock.Add(transaction);

            //Act

            this.chainblock.RemoveTransactionById(transaction.Id);

            //Assert
            Assert.False(this.chainblock.Contains(transaction));
            Assert.AreEqual(0, this.chainblock.Count);
        }


        [Test]
        public void RemoveTransactionByID_Should_RemoveTransaction_IfDataDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.RemoveTransactionById(5));
        }

        [Test]
        public void GetByID_ShouldReturnRecord_IfDataExist()
        {
            //Arrange
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Aborted,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            this.chainblock.Add(transaction);
            //Act
            ITransaction actualTransaction = this.chainblock.GetById(1);

            ITransaction transactionCopy = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Aborted,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            //Assert
            Assert.AreEqual(transactionCopy, actualTransaction);
        }

        [Test]
        public void GetByID_ShouldThrawnException_WhenDataDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetById(5));

        }

        [Test]
        public void GetTransactionBystatus_ShouldReturnTransactions_WithStatus()
        {
            ITransaction transaction = new Transaction
            {
                Id = 1,
                Status = TransactionStatus.Aborted,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            ITransaction transaction2 = new Transaction
            {
                Id = 3,
                Status = TransactionStatus.Successfull,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            ITransaction transaction3 = new Transaction
            {
                Id = 3,
                Status = TransactionStatus.Aborted,
                From = "Todor",
                To = "Heni",
                Amount = 250
            };

            this.chainblock.Add(transaction);
            this.chainblock.Add(transaction2);
            this.chainblock.Add(transaction3);
            //Act
            IEnumerable<ITransaction> transactions = 
                this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            //Assert
            CollectionAssert.AreEqual(new ITransaction[] { transaction2 }, transactions);
        }

    }
}
