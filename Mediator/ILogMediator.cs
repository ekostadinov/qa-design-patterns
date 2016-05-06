using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// Defines the properties and the methods that all mediators must support:
    /// </summary>
    interface ILogMediator
    {
        // This is the list of the registered participants
        IList<ILogger> LoggersList { get; }
        // Sends the messages from the sender to all the participants
        void DistributeMessage(ILogger sender, string message);
        // Register the participant to receive the message from the mediator
        void Register(ILogger logger);
    }
}
