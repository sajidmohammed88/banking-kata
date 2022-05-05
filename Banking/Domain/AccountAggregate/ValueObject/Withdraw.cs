
using System;

namespace Banking
{
    public class Withdraw : ITransaction
    {
        public float Value { get; }

        public DateTime Date { get; }

        public float CurrentBalance { get; }

        public Withdraw(float value, DateTime date, float balance)
        {
            if (value < 0)
            {
                throw new InvalidAmountException("Cannot withdraw a negative amount");
            }

            Value = value;
            Date = date;
            CurrentBalance = balance - value;
        }
    }
}