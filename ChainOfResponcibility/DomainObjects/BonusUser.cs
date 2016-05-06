using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChainOfResponcibility.DomainObjects
{
    class BonusUser : BankingUser
    {
        public List<string> AvailableBonuses { get; set; }

        public BonusUser(BankingUser bankingUser, BasicUser basicUser)
            : base(basicUser)
        {
            PlayerId = basicUser.PlayerId;
            UserName = basicUser.UserName;
            CardNumbers = bankingUser.CardNumbers;
            TotalCashAmount = bankingUser.TotalCashAmount;
        }
    }
}
