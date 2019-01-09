using System;
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
        public override void Debit(double amount)
        {
            throw new NotImplementedException();
        }

    }
}
