using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChainOfResponcibility.DomainObjects;

namespace ChainOfResponcibility.Handlers
{
    class BankingHandler
    {
        public BankingUser RegisterUser(BankingUser requestedUser)
        {
            // use the player-id for request the cards and amount
            Console.WriteLine("Retrieving banking data for player Id: {0} ...", requestedUser.PlayerId);
            Thread.Sleep(2000);
            // send request to corresponding Banking service
            Console.WriteLine("UserID {0} has: ", requestedUser.PlayerId);
            requestedUser.CardNumbers = new List<int>();
            Random rnd = new Random();
            requestedUser.CardNumbers.Add(rnd.Next(11111111, 99999999));
            Console.WriteLine("- cards added: " + requestedUser.CardNumbers.Count);
            requestedUser.TotalCashAmount = rnd.Next(1, 99999999);
            Console.WriteLine("- total cash amount: " + requestedUser.TotalCashAmount);

            return requestedUser;
        }
    }
}
