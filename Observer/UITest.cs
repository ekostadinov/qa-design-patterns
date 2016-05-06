using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// Stores state of interest to ConcreteObserver
    /// Sends a notification to its observers when its state changes
    /// </summary>
    class UITest : NUnitTest
    {
        private string _subjectState;

        // Gets or sets subject (test teardown) state
        public string State
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }
}
