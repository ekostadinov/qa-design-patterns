using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainOfResponcibility.DomainObjects
{
    class BankingUser : BasicUser
    {
        public List<int> CardNumbers { get; set; }
        public long TotalCashAmount { get; set; }

        public BankingUser(BasicUser basicUser)
        {
            PlayerId = basicUser.PlayerId;
            UserName = basicUser.UserName;
        }
    }
}
