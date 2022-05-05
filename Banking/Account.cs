using System;

namespace Banking
{

    public class Account
    {
        public int Balance { get; private set; } = 0;
        public Statement Statement { get; private set; }

        public void Deposit(int amount, DateTime date)
        {
            if (amount < 0)
                throw new InvalidAmountException("Cannot deposit a negative amount");
            Balance += amount;
        }

        public void Withdraw(int amount, DateTime date)
        {
            Balance -= amount;
        }

    }

}
