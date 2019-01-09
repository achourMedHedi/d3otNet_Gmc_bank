using System;
using System.Collections;
using System.Collections.Generic;
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
        public Dictionary<Guid , Transaction> transactions { get; set; }
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
