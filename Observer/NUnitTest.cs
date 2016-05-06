using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Loggers;

namespace Observer
{
    /// <summary>
    /// Subject participant knows its observers. Any number of Observer objects may observe a subject
    /// provides an interface for attaching and detaching Observer objects.
    /// </summary>
    abstract class NUnitTest
    {
        private List<Logger> _observers = new List<Logger>();

        public void Attach(Logger observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Logger observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var logger in _observers)
            {
                logger.Update();
            }
        }
    }
}
