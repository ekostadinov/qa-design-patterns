using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Loggers
{
    /// <summary>
    /// Defines an updating interface for objects that should be notified of changes in a subject.
    /// </summary>
    abstract class Logger
    {
        public abstract void Update();
    }
}
