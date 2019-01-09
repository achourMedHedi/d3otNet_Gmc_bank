using System;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    class Business : AbsctractAccount
    {
        public override double TaxRatio { get; set; }

        public Business() : base() { }
        public Business (long accNumber , Client client) : base(accNumber , client)
        {
            TaxRatio = 0.1; 
        }
        public override void Debit(double amount)
        {
            throw new NotImplementedException();
        }

    }
}
