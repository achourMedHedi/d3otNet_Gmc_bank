using System;

namespace GmcBank
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Bank<Client> bank = new Bank<Client>("gmc bank" , 21458);
            bank = bank.LoadFile();
            foreach (Client c in bank.clients)
            {
                Console.WriteLine(c.cin);
            }
           /* bank.AddClient(new Client("achou", 15001950));
            bank.AddAgent();
            Client client = bank.GetClient(15001950);
            Business business = new Business(1, client);
            Saving saving = new Saving(3, client);
            client.accounts.Add(business.accountNumber, business);
            client.accounts.Add(saving.accountNumber, saving);
            client.CloseAccount(business);
            Transaction transaction = new Transaction(2145, 55555, 2000);
            //business.AddTransaction(new Transaction(2145, 55555, 2000));
            business.transactions.Add(Guid.NewGuid(), transaction); 
            foreach (Client c in bank.clients)
            {
                Console.WriteLine(c.cin);
            }

            bank.SaveFile();*/

            Console.ReadLine();
        }
    }
}
