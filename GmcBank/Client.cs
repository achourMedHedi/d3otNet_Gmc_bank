using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GmcBank
{
    [DataContract]
    public class Client : IClient<AbsctractAccount>
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cin { get; set; }
        [DataMember]
        public Dictionary<long, AbsctractAccount> accounts;

        public Client() { }
        public Client(string n , int c)
        {
            name = n;
            cin = c;
            accounts = new Dictionary<long, AbsctractAccount>();
        }

        public void CloseAccount(AbsctractAccount account)
        {
            accounts[account.accountNumber].state = "Closed";
        }

        public void CreateAccount(AbsctractAccount account)
        {
            throw new NotImplementedException();
        }

        public AbsctractAccount GetAccount(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public Dictionary<long, AbsctractAccount> GetAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
