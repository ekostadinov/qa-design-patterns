using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponcibility.DomainObjects;
using ChainOfResponcibility.Handlers;

namespace ChainOfResponcibility
{
    /// <summary>
    /// Composite class that intent to "compose" our Handler objects into tree structures to represent part-whole hierarchies (our pipeline).
    /// Implementing the composite pattern lets clients treat individual objects and compositions uniformly.
    /// </summary>
    class CreateUserHandler
    {
        private IUser _user;

        public IUser RegisterTestUser(string userType)
        {
            if (userType.ToLower().Contains("basic"))
            {
                _user = new RegistrationHandler().RegisterUser(new BasicUser());
            }
            else if(userType.ToLower().Contains("banking"))
            {
                var basicUser = new RegistrationHandler().RegisterUser(new BasicUser());
                _user = new BankingHandler().RegisterUser(new BankingUser(basicUser));
            }
            else if (userType.ToLower().Contains("bonus"))
            {
                var basicUser = new RegistrationHandler().RegisterUser(new BasicUser());
                var bankingUser = new BankingHandler().RegisterUser(new BankingUser(basicUser));
                _user = new BonusSystemHandler().RegisterUser(new BonusUser(bankingUser, basicUser));
            }

            return _user;
        }
    }
}
