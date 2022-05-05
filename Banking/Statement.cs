using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class Statement
    {
        public Statement(List<Transaction> transactions)
        {
            Transactions = transactions;
        }
        public IReadOnlyCollection<Transaction> Transactions { get; private set; }
    }

    public class Transaction
    {
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public int CurrentBalance { get; set; }


    }
}
