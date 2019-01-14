using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace GmcBank
{
 
    [DataContract]
    public class Bank<TClient> : IEquatable<TClient>
        where TClient : Client
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int swiftCode { get; set; }
        [DataMember]
        public int agent { get; set; }
        [DataMember]
        private List<TClient> clients;

        private readonly object lockAgent = new object();

        public  Queue transactionsQueue = new Queue();

        //public HashSet<AbsctractAccount> accounts;
        //public Hashtable transactions;

        public Bank() { }
        public Bank (string n , int sCode)
        {
            agent = 1;
            name = n;
            swiftCode = sCode;
            clients = new List<TClient>();
        }

        public List<TClient> Clients
        {
            get
            {
                return clients;
            }
        }
      

        /// <summary>
        /// add transaction to the Queue 
        /// and test if there an agents to execute the transaction 
        /// send money from sender and credit the receiver
        /// </summary>
        public void AddTransaction(Transaction transaction)
        {
            // add transaction to the queue 
            // if theres an agent 
                //transactionsQueue.Enqueue(transaction);

            if (agent > 0)
            {

                // lock 
                // sender account
                // receiver account 
                // sender.sendMoney
                // receiver.credit 
                agent--; 
                lock (lockAgent)
                {
                    transactionsQueue.Enqueue(transaction);
                    Console.WriteLine("queue");
                    // with thread :/
                    AbsctractAccount sender = account(transaction.sourceAccountnNumber);
                    AbsctractAccount receiver = account(transaction.targetAccountnNumber);
                    try
                    {
                        Thread.Sleep(3000);
                        sender.SendMoney(transaction.amount, transaction.targetAccountnNumber);
                        receiver.Credit(transaction.amount);
                        receiver.AddTransaction(transaction);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    transactionsQueue.Dequeue();
                    Console.WriteLine("dequeue");
                    agent++; 
                }
        
            }
            else
            {
                throw new Exception("no agents ");
            }
         

        }


        public bool Equals(TClient other)
        {
            throw new NotImplementedException();
        }

        //public Hashtable Transactions () { return new Hashtable(); }
        public AbsctractAccount account (long accNumber)
        {
            foreach (Client client in clients)
            {
                foreach (AbsctractAccount a in client.GetAllAccounts())
                {
                    if (a.accountNumber == accNumber)
                    {
                        return a;
                    }
                }
            }
            return null;
        }
        public void AddAgent() { agent++; }
        public void AddAgent(int nbAgents) { agent += nbAgents; }
        public void RemoveAgent() { agent -= 1; }
        public void RemoveAgent(int nbAgents) { agent -= nbAgents; }
        //load file
        public Bank<Client> LoadFile(string path)
        {
            string filePath = File.ReadAllText(path);
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(filePath));
            DataContractJsonSerializer serRead = new DataContractJsonSerializer(typeof(Bank<Client>));

            stream.Position = 0;
            Bank<Client> bank = (Bank<Client>)serRead.ReadObject(stream);
            return bank; 
            
        }
        //save file
        public void SaveFile(string path=@"C:\Users\achou\source\repos\GmcBank\GmcBank\data.json")
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Bank<Client>)) ;
            ser.WriteObject(stream, this);

            stream.Position = 0;
            StreamReader seralize = new StreamReader(stream);
            File.WriteAllText(path, seralize.ReadToEnd());


        }
       
    }
}
