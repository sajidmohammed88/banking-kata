using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Banking
{

    public class Account
    {
        public float Balance => _transactions.LastOrDefault()?.CurrentBalance ?? 0;

        private List<ITransaction> _transactions = new List<ITransaction>();

        public void Deposit(float amount, DateTime date)
        {
            _transactions.Add(new Deposit( amount, date, Balance));
        }

        public void Withdraw(int amount, DateTime date)
        {
            
            _transactions.Add(new Withdraw(amount, date, Balance));
        }

        public Statement GetStatement()
        {
            _transactions.Sort(new DateTimeComparer());
            return new Statement(_transactions);
        }

        public class DateTimeComparer : IComparer<ITransaction>
        {
            public int Compare([AllowNull] ITransaction x, [AllowNull] ITransaction y)
            {
                return DateTime.Compare(y.Date, x.Date);
            }
        }

    }

}
