using System;
using Xunit;

namespace Banking.Tests.Unit
{

    public class BankingTest
    {

        Account _account;
        public BankingTest()
        {
            _account = new Account();
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
    }

}
