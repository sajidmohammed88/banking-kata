using System;

namespace Banking
{
    public interface ITransaction
    {
        float Value { get; }
        DateTime Date { get; }
        float CurrentBalance { get; }
    }
}
