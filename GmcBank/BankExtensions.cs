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
            bank.Clients.Add(client);
        }
        public static Client GetClient(this Bank<Client> bank, long nbClient)
        {
            Client client = (from c in bank.Clients where c.cin == nbClient select c).FirstOrDefault() ;
            if (client == null)
            {
                throw new Exception("account not found ");
            }
            return client;
        }

        public static void AddTransaction(this AbsctractAccount account, Transaction transaction)
        {
            account.transactions.Add(transaction.transactionNumber, transaction);
        }


    }
}
