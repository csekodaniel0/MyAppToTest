using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppToTest
{
    class Manager : IManager
    {

        public List<Account> Accounts { get; } = new List<Account>();

        public Account CreateAccount(Account account)
        {
            var oldAccount = (from a in Accounts
                              where a.Name.Equals(account.Name)
                              select a).FirstOrDefault();

            if (oldAccount != null)
                throw new ApplicationException(
                    "Már létezik felhasználó ilyen nevvel! ");

            Accounts.Add(account);

            return account;
        }
    }
}
