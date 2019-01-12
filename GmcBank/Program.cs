using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GmcBank
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Bank<Client> bank = new Bank<Client>("gmc aaaaa" , 21458);
            bank = bank.LoadFile();
            // bank = bank2   ;
            Console.WriteLine(bank.name);
            Console.WriteLine();
            List<Client> lista = bank.Clients;
            
            foreach (Client c in bank.Clients)
            {
                //Console.WriteLine(c.account.IsValueCreated + "++++++++");
                foreach (KeyValuePair<long, AbsctractAccount> account in c.accounts)
                {
                    //Console.WriteLine(c.account.IsValueCreated + "------------");

                    Console.WriteLine(account.Value.balance + "xd");
                    account.Value.AddTransaction(new Transaction(1, 1, 1));
                  foreach (KeyValuePair<Guid , Transaction> transaction in account.Value.GetAllTransactions)
                    {
                        Console.WriteLine(transaction.Value.targetAccountnNumber + " " + transaction.Value.date);
                      
                    }
                    foreach (KeyValuePair<Guid, Transaction> t in account.Value.GetTransactionsByTarget(55555))
                    {
                        Console.WriteLine(t.Key + " h " + t.Value.date);
                        
                    }
                   foreach (KeyValuePair<Guid, Transaction> transaction in account.Value.GetTransactionsByDate("10/01/2019 00:00:00"))
                    {
                        Console.WriteLine(transaction.Value.targetAccountnNumber + " time time time  " + transaction.Value.date);

                    }
                }
                Console.WriteLine(c.cin);
            }
         
          /*  Console.WriteLine("---------------");


            bank.AddClient(new Client("achou", 15001950));
            bank.AddAgent();
            Client client = bank.GetClient(15001950);
            Business business = new Business(1, client);
            Saving saving = new Saving(3, new Client("hedi", 3333));
            client.GetAllAccounts().Add(business.accountNumber, business);
            client.GetAllAccounts().Add(saving.accountNumber, saving);
            client.CloseAccount(business);
            Transaction transaction = new Transaction(2145, 55555, 2000);
            business.AddTransaction(new Transaction(1010, 55555, 1000));
            business.AddTransaction(new Transaction(2145, 22222, 2000));
            business.AddTransaction(new Transaction(1010, 33333, 1000));
            business.AddTransaction(new Transaction(2145, 22222, 2000));
            business.GetAllTransactions.Add(Guid.NewGuid(), transaction); 
            foreach (Client c in bank.Clients)
            {
                Console.WriteLine(c.cin);
            }
            
            bank.SaveFile();*/

            Console.ReadLine();
        }
    }
}
