using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

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
        public List<TClient> clients { get; set; }
        //public HashSet<AbsctractAccount> accounts;
        //public Hashtable transactions;

        public Bank() { }
        public Bank (string n , int sCode)
        {
            name = n;
            swiftCode = sCode;
            clients = new List<TClient>();
        }

        
        public bool Equals(TClient other)
        {
            throw new NotImplementedException();
        }
        //public void AddTransaction() { }
        public Hashtable Transactions () { return new Hashtable(); }
        public HashSet<AbsctractAccount> Accounts () { return new HashSet<AbsctractAccount>(); }
        public void AddAgent() { agent++; }
        public void AddAgent(int nbAgents) { agent += nbAgents; }
        public void RemoveAgent() { agent -= 1; }
        public void RemoveAgent(int nbAgents) { agent -= nbAgents; }
        //load file
        public Bank<Client> LoadFile(string path="/data.json" )
        {
            string filePath = File.ReadAllText(@"C:\Users\achou\source\repos\GmcBank\GmcBank\data.json");
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(filePath));
            DataContractJsonSerializer serRead = new DataContractJsonSerializer(typeof(Bank<Client>));

            stream.Position = 0;
            Bank<Client> bank = (Bank<Client>)serRead.ReadObject(stream);
            return bank; 
            
        }
        //save file
        public void SaveFile(string path="/data.json")
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Bank<Client>)) ;
            ser.WriteObject(stream, this);

            stream.Position = 0;
            StreamReader seralize = new StreamReader(stream);
            File.WriteAllText(@"C:\Users\achou\source\repos\GmcBank\GmcBank\data.json", seralize.ReadToEnd());


        }
       
    }
}
