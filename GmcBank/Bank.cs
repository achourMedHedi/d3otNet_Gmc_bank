using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    public class Bank<TClient> : IEquatable<TClient>
        where TClient : Client
    {
        public string name { get; set; } 
        public int swiftCode { get; set; }

        public int agent { get; set; }
        
        public List<TClient> clients;
        //public HashSet<AbsctractAccount> accounts;
        //public Hashtable transactions;

        public Bank() { }
        public Bank (string n , int sCode)
        {
            name = n;
            swiftCode = sCode; 
        }

        
        public bool Equals(TClient other)
        {
            throw new NotImplementedException();
        }

        public Hashtable Transactions () { return new Hashtable(); }
        public HashSet<AbsctractAccount> Accounts () { return new HashSet<AbsctractAccount>(); }
        public void AddAgent() { }
        public void AddAgent(int nbAgents) { }
        public void RemoveAgent() { }
        public void RemoveAgent(int nbAgents) { }
        public void AddTransaction() { }
        //load file
        //save file




    }
}
