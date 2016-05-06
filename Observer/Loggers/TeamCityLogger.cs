using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Loggers
{
    /// <summary>
    /// Maintains a reference to a ConcreteSubject object, stores state that should stay consistent with the subject's
    /// and implements the Observer updating interface to keep its state consistent with the subject's
    /// </summary>
    class TeamCityLogger: Logger
    {
        private string _name = "TeamCity";
        private string _observerState;
        private UITest _subject;

        // Constructor
        public TeamCityLogger(UITest subject)
        {
            this._subject = subject;
        }

        public override void Update()
        {
            _observerState = _subject.State;
            Console.WriteLine("Observer {0}'s new state is {1}",
                _name, _observerState);
        }

        // Gets or sets subject
        public UITest Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }
}
