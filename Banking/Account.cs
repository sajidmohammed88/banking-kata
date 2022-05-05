using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{

    public class Account
    {
        public int Balance => _transactions.LastOrDefault()?.CurrentBalance ?? 0;

        private List<Transaction> _transactions = new List<Transaction>();

        public void Deposit(int amount, DateTime date)
        {
            if (amount < 0)
                throw new InvalidAmountException("Cannot deposit a negative amount");
            _transactions.Add(new Transaction { Date = date, Value = amount, CurrentBalance = Balance + amount });
        }

        public void Withdraw(int amount, DateTime date)
        {
            if (amount < 0)
                throw new InvalidAmountException("Cannot withdraw a negative amount");
            _transactions.Add(new Transaction { Date = date, Value = amount, CurrentBalance = Balance - amount });
        }

        public Statement GetStatement()
        {
            return new Statement(_transactions);
        }

    }

}
