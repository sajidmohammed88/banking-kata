using System;

namespace Banking
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException() : base()
        {
        }

        public InvalidAmountException(string message) 
            : base(message)
        {
        }
    }
}