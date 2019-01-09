using System;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    public class Transaction
    {
        public Guid transactionNumber { get; set; }
        public long sourceAccountnNumber { get; set; }
        public long targetAccountnNumber { get; set; }
        public double amount { get; set; }
        public DateTime date { get; set; }
        public string state { get; set; }
        public string direction { get; set; }

        public Transaction() { }
        public Transaction(long source , long target , double a )
        {
            transactionNumber = Guid.NewGuid();
            sourceAccountnNumber = source;
            targetAccountnNumber = target;
            amount = a;
            date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            state = "Ready"; 
            // transaction direction will depend on the user
        }
    }
}
