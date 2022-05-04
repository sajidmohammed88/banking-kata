using System;

namespace Banking
{

    public class Account
    {
        public Statement Statement { get; private set; }

        public void Deposit(int amount, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(int amount, DateTime date)
        {
            throw new NotImplementedException();
        }

    }

}
