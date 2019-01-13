using System;
using System.Collections;
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
        public Lazy<Dictionary<long, AbsctractAccount>> accounts; 

        public Client() { }
        public Client(string n , int c)
        {
            accounts = new Lazy<Dictionary<long, AbsctractAccount>>();
            name = n;
            cin = c;
        }

         

        public IEnumerable<AbsctractAccount> GetAllAccounts ()
        {
            foreach (KeyValuePair<long , AbsctractAccount> a in accounts.Value )
            {
                yield return a.Value;
            }
        }
     
        public void CloseAccount(AbsctractAccount account)
        {
            accounts.Value[account.accountNumber].state = "Closed";
        }

        public void CreateAccount(AbsctractAccount a)
        {
            accounts.Value.Add(a.accountNumber , a);
        }

        public AbsctractAccount GetAccount(long accountNumber)
        {
            throw new NotImplementedException();
        }

      


    }
}
