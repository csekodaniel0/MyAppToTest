using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppToTest
{
    public interface IManager
    {
        List<Account> Accounts { get; }

        Account CreateAccount(Account account);
        void CrucialBusinessAction();
        Account ModifyName(Account acc, string newName);

    }
}
