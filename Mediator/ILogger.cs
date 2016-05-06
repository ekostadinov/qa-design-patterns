using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// Defines the methods that all participants must support
    /// </summary>
    interface ILogger
    {
        // Sends the message to the mediator
        void SendMessage(ILogMediator mediator, string message);
        // Gets the message from the mediator
        void ReceiveMessage(string message);

    }
}
