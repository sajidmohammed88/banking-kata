
using System;

namespace Banking
{
    public class Deposit : ITransaction
    {
        public float Value { get; }

        public DateTime Date { get; }

        public float CurrentBalance { get; }

        public Deposit(float value, DateTime date, float balance)
        {
            if (value < 0){
                throw new InvalidAmountException("Cannot deposit a negative amount");
            }

            Value = value;
            Date = date;
            CurrentBalance = balance + value;
        }
    }
}