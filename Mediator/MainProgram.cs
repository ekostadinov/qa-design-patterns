using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by
    /// keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            //list of participants
            ILogger teamCity = new TeamCityLogger();
            ILogger testRail = new TestRailLogger();
            ILogger sqlDb = new DbLogger();

            //first mediator
            ILogMediator mediator = new LogMediator();
            //participants registers to the mediator
            mediator.Register(teamCity);
            mediator.Register(testRail);
            mediator.Register(sqlDb);
            
            //participants send out a message to each other
            teamCity.SendMessage(mediator, "Build X triggered from TeamCity");
            testRail.SendMessage(mediator, "Created plan Y from TestRail");
            sqlDb.SendMessage(mediator, "Proxy related errors Z from DB query");

            Console.ReadKey();
        }
    }
}
