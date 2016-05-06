using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer.Loggers;

namespace Observer
{
    /// <summary>
    /// Define a one-to-many dependency between objects so that when one object changes state, all its dependents are 
    /// notified and updated automatically.  Encapsulate the core (or common or engine) components in a Subject abstraction, 
    /// and the variable (or optional or user interface) components in an Observer hierarchy. The "push" model compromises reuse, 
    /// while the "pull" model is less efficient.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            // Configure Observer pattern
            UITest test = new UITest();
            
            test.Attach(new DbLogger(test));
            test.Attach(new TeamCityLogger(test));
            test.Attach(new TestRailLogger(test));

            // Change subject and notify observers
            test.State = "Last executed step: Given I navigate to URL.";
            test.Notify();

            Console.WriteLine("-------- Change subject state again -----------");
            test.State = "Last executed step: When I login.";
            test.Notify();

            // Wait for user
            Console.ReadKey();
        }
    }
}
