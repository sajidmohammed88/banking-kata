using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Banking
{
    public class Printer
    {
        public string Print(Statement statement)
        {
            const string header = "date       ||   credit ||    debit ||  balance";
            IList<string> table = new List<string> { header };

            foreach (var transaction in statement.Transactions)
            {
                if (transaction is Deposit)
                {
                    table.Add($"{transaction.Date:dd-MM-yyyy} ||  {FormatValue(transaction.Value)} ||          ||  {FormatValue(transaction.CurrentBalance)}");
                }
                else
                {
                    table.Add($"{transaction.Date:dd-MM-yyyy} ||          ||  {FormatValue(transaction.Value)} ||  {FormatValue(transaction.CurrentBalance)}");

                }
            }

            return string.Join(Environment.NewLine, table);
        }

        private string FormatValue(float value) =>
            value.ToString("0.00", CultureInfo.InvariantCulture).PadLeft(7);

    }
}
