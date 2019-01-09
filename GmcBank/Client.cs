using System;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    public class Client : IClient<AbsctractAccount>
    {
        public string name { get; set; }
        public int cin { get; set; }
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
            throw new NotImplementedException();
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
