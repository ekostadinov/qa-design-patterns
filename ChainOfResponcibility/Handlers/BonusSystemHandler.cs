using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChainOfResponcibility.DomainObjects;

namespace ChainOfResponcibility.Handlers
{
    class BonusSystemHandler
    {

        public BonusUser RegisterUser(BonusUser requestedUser)
        {
            // use the player-id to request and retrieve the available bonuses
            Console.WriteLine("Retrieving available bonuses for player Id: {0} ...", requestedUser.PlayerId);
            Thread.Sleep(1500);
            // send request to corresponding Bonus system service
            Console.WriteLine("UserID {0} has: ", requestedUser.PlayerId);
            requestedUser.AvailableBonuses = new List<string>();
            Random rnd = new Random();
            requestedUser.AvailableBonuses.Add(new Guid().ToString());
            requestedUser.AvailableBonuses.Add(new Guid().ToString());
            Console.WriteLine("- applicable bonuses: " + requestedUser.AvailableBonuses.Count);


            return requestedUser;
        }
    }
}
