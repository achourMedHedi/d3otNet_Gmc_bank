using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GmcBank
{
    [DataContract]
    [KnownType(typeof(Business))]
    [KnownType(typeof(Saving))]
    abstract public class AbsctractAccount : IComparable
    {
        [DataMember]
        public double balance { get; set; }
        [DataMember]
        public long accountNumber { get; set; }
        [DataMember]
        public string owner { get; set; }
        [DataMember]
        public Dictionary<Guid, Transaction> transactions;
        [DataMember]
        public DateTime creationDate { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public virtual double TaxRatio { get; set; }

        public AbsctractAccount() { } 
        public AbsctractAccount(long accNumber , Client client)
        {
            balance = 1000;
            accountNumber = accNumber;
            owner = client.name;
            transactions = new Dictionary<Guid, Transaction>();
            creationDate = DateTime.Now;
            state = "Active";
        }

        public abstract void Debit(double amount);  
        public void Credit(double amount ) { }
        public virtual void SendMoney(double amount ,long targetaccountNumber) { }
        public Dictionary<Guid, Transaction> GetAllTransactions => (from i in transactions.Values orderby i.date descending select i).ToDictionary(d => d.transactionNumber); 
        public Dictionary<Guid, Transaction> GetTransactionsByDate (string dateTime)
        {
            var result = from i in transactions.Values where i.date.Equals(DateTime.Parse(dateTime)) select i;

            return result.ToDictionary(d => d.transactionNumber) ;
        }
        public Dictionary<Guid, Transaction> GetTransactionsByTarget(long accountNumber)
        {
            var result = from i in transactions.Values where i.targetAccountnNumber == accountNumber orderby i.date select i;
            return result.ToDictionary( d => d.transactionNumber);
        }

        public Dictionary<Guid, Transaction> GetTransactionsByQuery (Func<Hashtable> func) => new Dictionary<Guid, Transaction>();
        
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
