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
        public DateTime creationDate { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public virtual double TaxRatio { get; set; }

        [DataMember]
        private Lazy<Dictionary<Guid, Transaction>> transactions;

        public AbsctractAccount() { } 
        public AbsctractAccount(long accNumber , Client client)
        {
            balance = 1000;
            accountNumber = accNumber;
            owner = client.name;
            transactions = new Lazy<Dictionary<Guid, Transaction>>();
            creationDate = DateTime.Now;
            state = "Active";
        }

     

        public IEnumerable<Transaction> GetAllTransactions ()
        {
            foreach (KeyValuePair<Guid , Transaction> t in transactions.Value)
            {
                yield return t.Value; 
            }
        }

        public void AddTransaction (Transaction t)
        {
            transactions.Value.Add(t.transactionNumber, t);
        }

        public abstract void Debit(double amount);  

        public void Credit(double amount ) { }

        public virtual void SendMoney(double amount ,long targetaccountNumber) { balance.CompareTo(amount); }

        public IEnumerable<Transaction> GetTransactionsByDate (string dateTime)
        {
            var result = from i in transactions.Value where i.Value.date.Equals(DateTime.Parse(dateTime)) select i;
            foreach (KeyValuePair<Guid , Transaction> transaction in result)
            {
                yield return transaction.Value;
            } 
        }
        public IEnumerable<Transaction> GetTransactionsByTarget(long accountNumber)
        {
            var result = from i in transactions.Value where i.Value.targetAccountnNumber == accountNumber orderby i.Value.date select i;
            foreach (KeyValuePair<Guid, Transaction> transaction in result)
            {
                yield return transaction.Value;
            }
        }
       

        public Dictionary<Guid, Transaction> GetTransactionsByQuery (string exp)
        {

            return new Dictionary<Guid, Transaction>();
        }

        public int CompareTo(object obj)
        {
            return balance.CompareTo(obj);
        }
        

    }
}
