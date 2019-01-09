using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    abstract public class AbsctractAccount : IComparable
    {
        public double balance { get; set; }
        public long accountNumber { get; set; }
        public Client owner { get; set; }
        public Hashtable transactions { get; set; }
        public DateTime creationDate { get; set; }
        public string state { get; set; }
        public virtual double TaxRatio { get; set; }

        public AbsctractAccount() { } 
        public AbsctractAccount(long accNumber , Client client)
        {
            balance = 1000;
            accountNumber = accNumber;
            owner = client;
            transactions = new Hashtable();
            creationDate = new DateTime(DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day);
            state = "Active";
        }

        public abstract void Debit(double amount);  
        public void Credit(double amount ) { }
        public virtual void SendMoney(double amount ,long targetaccountNumber) { }
        public Hashtable GetAllTransactions => new Hashtable();
        public Hashtable GetTransactionsByDate (DateTime dateTime) => new Hashtable();
        public Hashtable GetTransactionsByTarget (Transaction transaction) => new Hashtable();
        public Hashtable GetTransactionsByQuery (Func<Hashtable> func) => new Hashtable();

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
