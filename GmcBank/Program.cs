using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
//Lazy<IEnumerable<Dictionary<long, AbsctractAccount>>> b = new Lazy<IEnumerable<Dictionary<long, AbsctractAccount>>>(() => c.LoadAccounts());
/*
public IEnumerable<Dictionary<long, AbsctractAccount>> LoadAccounts()
{
    Dictionary<long, AbsctractAccount> acc = new Dictionary<long, AbsctractAccount>();
    foreach (Dictionary<long, AbsctractAccount> a in accounts)
    {
        foreach (KeyValuePair<long, AbsctractAccount> item in a)
        {
            acc.Add(item.Value.accountNumber, item.Value);
        }

    }
    yield return acc;
}*/
namespace GmcBank
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Bank<Client> bank = new Bank<Client>("gmc bank" , 654789);
            bank = bank.LoadFile();
            /*Client client = new Client("achour", 1500);
            bank.Clients.Add(client);
            Business business = new Business(2154, client);
            client.CreateAccount(business);

            business.AddTransaction(new Transaction(222222 , 333333 , 0000000));*/
            foreach (Client client in bank.Clients)
            {
                Console.WriteLine();
                foreach (AbsctractAccount a in client.GetAllAccounts())
                {
                    Console.WriteLine("hello " + a.owner);
                    Console.WriteLine();
                    foreach (Transaction transaction in a.GetAllTransactions())
                    {
                        Console.WriteLine("t = " + transaction.transactionNumber);
                    }
                    foreach (Transaction t in a.GetTransactionsByTarget(333333))
                    {
                        Console.WriteLine("enaaaaaaa " + t.transactionNumber);
                    }
                }
            }
           // bank.SaveFile();

            Console.ReadLine();
        }
    }
}
