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

            Bank <Client<AbsctractAccount<Transaction>,Transaction>, AbsctractAccount<Transaction> , Transaction> bank = new Bank<Client<AbsctractAccount<Transaction>, Transaction>, AbsctractAccount<Transaction>, Transaction>("gmc bank" , 654789);
            //string  x = bank.Auther();
            //bank = bank.LoadFile(@"C:\Users\achou\source\repos\GmcBank\GmcBank\data.json");
            bank.Auther();
            Client<AbsctractAccount<Transaction>, Transaction> client = new Client<AbsctractAccount<Transaction>, Transaction>("achour", 1500);
            bank.Clients.Add(client);
            Saving business = new Saving(2154, client);
            Business business2 = new Business(1111, client);
            client.CreateAccount(business);
            client.CreateAccount(business2);

            
            bank.AddAgent();
            bank.AddAgent();
            bank.AddTransaction(new Transaction(2154, 1111, 500));
            bank.AddTransaction(new Transaction(2154, 1111, 500));
            foreach (Client<AbsctractAccount<Transaction> , Transaction> clients in bank.Clients)
            {
                Console.WriteLine();
                foreach (AbsctractAccount<Transaction> a in clients.GetAllAccounts())
                {
                    Console.WriteLine("hello " + a.balance + " " +a.owner );
                    foreach (Transaction transaction in a.GetAllTransactions())
                    {
                        Console.WriteLine("t = " + transaction.direction + " " + transaction.date );
                    }
                    Console.WriteLine("-----");

                }
            }
            bank.SaveFile();

            Console.ReadLine();
        }
    }
}
