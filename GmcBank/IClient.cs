using System;
using System.Collections.Generic;
using System.Text;

namespace GmcBank
{
    interface IClient<TAccount> where TAccount : AbsctractAccount
    {
        Dictionary<long, TAccount> GetAllAccounts(); 
        AbsctractAccount GetAccount(long accountNumber);
        void CreateAccount(TAccount account);
        void CloseAccount(TAccount account);

    }
}
