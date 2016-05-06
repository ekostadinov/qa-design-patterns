using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    /// <summary>
    /// The Mediator Design Pattern allows you to decouple the direct communication between objects by introducing a middle object, 
    /// that facilitates the communication between the objects. Imagine you have a system where numerous objects communicate with each other
    /// by holding the reference to other objects. As the number of object grows and the references to other objects increases the system becomes hard to maintain.
    /// </summary>
    class LogMediator : ILogMediator
    {
        private IList<ILogger> _loggers;

        public IList<ILogger> LoggersList
        {
            get { return _loggers; }
        }

        public LogMediator()
        {
            _loggers =  new List<ILogger>();
        }

        public void Register(ILogger logger)
        {
            _loggers.Add(logger);
        }

        public void DistributeMessage(ILogger sender, string message)
        {
            foreach (var logger in _loggers)
            {
                if (logger != sender) //don't need to send message to sender
                {
                    logger.ReceiveMessage(message);       
                }   
            }
        }
    }
}
