using System.Collections.Generic;
using System.Text;

namespace Banking
{
    public class Statement
    {
        public Statement(List<ITransaction> transactions)
        {
            Transactions = transactions;
        }
        public IReadOnlyCollection<ITransaction> Transactions { get; private set; }
    }
}
