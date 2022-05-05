using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Banking.Tests.Unit
{
    public class PrinterTest
    {
        private Printer _printer;
        private Account _account;

        public PrinterTest()
        {
            _printer = new Printer();
            _account = new Account();
        }


        [Fact]
        public void Should_print_header_when_no_transaction()
        {
            // Arrange
            var statment = _account.GetStatement();

            // Act
            var result = _printer.Print(statment);

            // Assert
            Assert.Equal("date       ||   credit ||    debit ||  balance", result);
        }

        [Fact]
        public void Should_print_statment_when_deposit()
        {
            // Arrange
            _account.Deposit(1000, DateTime.Now);
            var statment = _account.GetStatement();
            string expectedResult = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                                    "06-05-2022 ||  1000.00 ||          ||  1000.00";

            // Act
            var result = _printer.Print(statment);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_print_statement_when_withdraw()
        {
            // Arrange
            _account.Withdraw(500, DateTime.Now);
            var statment = _account.GetStatement();
            string expectedResult = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                                    "06-05-2022 ||          ||   500.00 ||  -500.00";

            // Act
            var result = _printer.Print(statment);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_print_statement_when_deposit_twice()
        {
            // Arrange
            _account.Deposit(1000, new DateTime(2022,5,5));
            _account.Deposit(500, new DateTime(2022,5,6));

            var statment = _account.GetStatement();
            string expectedResult = "date       ||   credit ||    debit ||  balance" + Environment.NewLine +
                                    "06-05-2022 ||   500.00 ||          ||  1500.00" + Environment.NewLine +
                                    "05-05-2022 ||  1000.00 ||          ||  1000.00";

            // Act
            var result = _printer.Print(statment);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
