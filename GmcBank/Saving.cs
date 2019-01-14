﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GmcBank
{
    [DataContract]
    public class Saving : AbsctractAccount
    {
        [DataMember]
        public override double TaxRatio { get; set; }

        public Saving() : base() { }
        public Saving(long accNumber, Client client) : base(accNumber, client)
        {
            TaxRatio = 0.01;
        }
        public override void SendMoney(double amount, long targetaccountNumber)
        {
            base.SendMoney(amount, targetaccountNumber);
            var debit = (balance * TaxRatio + amount);
            if ((balance - debit) >= 0)
            {
                Debit(debit);
                Transaction transaction = new Transaction(accountNumber, targetaccountNumber, amount);
                transaction.direction = "OutGoing";
                AddTransaction(transaction);
                Console.WriteLine("eyyyyyy S" + balance);

            }
            else
            {
                throw new Exception("you cant balance < amount ");
            }
        }
        public override void Debit(double amount)
        {
            balance -= (balance * TaxRatio + amount);
        }

    }
}
