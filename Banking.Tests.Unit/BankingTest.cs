using System;
using Xunit;

namespace Banking.Tests.Unit
{
    public class BankingTest
    {
        private Account _account;

        public BankingTest()
        {
            _account = new Account();
        }

        [Fact]
        public void Should_decrement_account_balance_when_withdrawing()
        {
            //Arrange
            const int amount = 500;

            //Act

            _account.Withdraw(amount, DateTime.Now);

            //Assert

            Assert.Equal(-amount, _account.Balance);
        }

        [Fact]
        public void Should_decrement_account_balance_when_withdrawing_twice()
        {
            //Arrange
            const int amountOne = 500;
            const int amountTwo = 800;

            //Act

            _account.Withdraw(amountOne, DateTime.Now);
            _account.Withdraw(amountTwo, DateTime.Now);

            //Assert

            Assert.Equal(-(amountOne + amountTwo), _account.Balance);
        }

        [Fact]
        public void Should_increment_account_balance_when_deposing()
        {
            //Arrange
            const int amount = 500;

            //Act

            _account.Deposit(amount, DateTime.Now);

            //Assert

            Assert.Equal(amount, _account.Balance);
        }

        [Fact]
        public void Should_increment_account_balance_when_deposing_twice()
        {
            //Arrange
            const int amountOne = 500;
            const int amountTwo = 800;

            //Act

            _account.Deposit(amountOne, DateTime.Now);
            _account.Deposit(amountTwo, DateTime.Now);

            //Assert

            Assert.Equal(amountOne + amountTwo, _account.Balance);
        }

        [Fact]
        public void Should_sum_transaction_when_withdrawingAndDeposing()
        {
            //Arrange
            const int amountToDeposit = 1000;
            const int amountToWithdraw = 500;

            //Act
            _account.Deposit(amountToDeposit, DateTime.Now);
            _account.Withdraw(amountToWithdraw, DateTime.Now);

            //Assert
            Assert.Equal(amountToDeposit - amountToWithdraw, _account.Balance);
        }

        [Fact]
        public void Should_throw_exception_when_deposingNegativeAmount()
        {
            //Arrange
            const int amountToDeposit = -500;

            //Act & Assert
            var amountException = Assert.Throws<InvalidAmountException>(() => _account.Deposit(amountToDeposit, DateTime.Now));
            Assert.NotNull(amountException);
            Assert.Equal("Cannot deposit a negative amount", amountException.Message);
        }

        [Fact]
        public void Should_throw_exception_when_withdrawing_negative_amount()
        {
            //Arrange
            const int amountToWithdraw = -500;

            //Act & Assert
            var amountException = Assert.Throws<InvalidAmountException>(() => _account.Withdraw(amountToWithdraw, DateTime.Now));
            Assert.NotNull(amountException);
            Assert.Equal("Cannot withdraw a negative amount", amountException.Message);
        }

        [Fact]
        public void Should_return_transaction_with_amount_and_date_when_deposing()
        {
            //Arrange
            const int amountToDeposit = 500;


            //Act 
            _account.Deposit(amountToDeposit, DateTime.Now);
            var statement = _account.GetStatement();

            //Assert
            Assert.NotNull(statement);
            Assert.Single(statement.Transactions);

            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Deposit));

        }

        [Fact]
        public void Should_return_transaction_with_amount_and_date_when_deposing_twice()
        {
            //Arrange
            const int amountToDepositOne = 500;
            const int amountToDepositTwo = 400;


            //Act 
            _account.Deposit(amountToDepositOne, DateTime.Now);
            _account.Deposit(amountToDepositTwo, DateTime.Now);
            var statement = _account.GetStatement();

            //Assert
            Assert.NotNull(statement);
            Assert.Equal(2, statement.Transactions.Count);

            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Deposit), tr => Assert.True(tr is Deposit));

        }


        [Fact]
        public void Should_return_transaction_with_amount_and_date_when_withdrawing()
        {
            //Arrange
            const int amountToWithdraw = 500;


            //Act 
            _account.Withdraw(amountToWithdraw, DateTime.Now);
            var statement = _account.GetStatement();

            //Assert
            Assert.NotNull(statement);
            Assert.Single(statement.Transactions);
            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Withdraw));

        }

        [Fact]
        public void Should_return_transaction_with_amount_and_date_when_withdrawing_twice()
        {
            //Arrange
            const int amountToWithdrawOne = 500;
            const int amountToWithdrawTwo = 400;


            //Act 
            _account.Withdraw(amountToWithdrawOne, DateTime.Now);
            _account.Withdraw(amountToWithdrawTwo, DateTime.Now);
            var statement = _account.GetStatement();

            //Assert
            Assert.NotNull(statement);
            Assert.Equal(2, statement.Transactions.Count);
            Assert.Collection(statement.Transactions, tr => Assert.True(tr is Withdraw), tr => Assert.True(tr is Withdraw));

        }

    }
}