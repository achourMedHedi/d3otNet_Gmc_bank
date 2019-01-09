using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GmcBank
{
    public static class BankExtensions
    {
        public static void AddClient(this Bank<Client> bank, Client client )
        {
            bank.clients.Add(client);
        }
        public static Client GetClient(this Bank<Client> bank, long nbClient)
        {
            Client client = (from c in bank.clients where c.cin.Equals(nbClient) select c).FirstOrDefault() ;
            if (client == null)
            {
                throw new Exception("cant found this account");
            }
            return client;
        }
    }
}
