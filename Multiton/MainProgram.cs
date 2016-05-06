using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiton.TargetSystems;

namespace Multiton
{
    /// <summary>
    /// The multiton pattern expands on the singleton concept to manage a map of named instances as key-value pairs. The pattern simplifies
    /// retrieval of shared objects in an application. First, the multiton does not allow clients to add mappings. Secondly, the multiton 
    /// never returns a null or empty reference; instead, it creates and stores a multiton instance on the first request with the associated key. 
    /// Subsequent requests with the same key return the original instance. 
    /// This pattern, like the Singleton pattern, makes unit testing far more difficult, as it introduces global state into an application.
    /// With garbage collected languages it may become a source of memory leaks as it introduces global strong references to the objects.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            TestRail inhouseRun = TestRail.GetMultiton("TestRail");
            TestRail clientRun = TestRail.GetMultiton("TestRail");

            Console.WriteLine(inhouseRun.TestRunId);
            Console.WriteLine(clientRun.TestRunId);
            Console.ReadKey();
        }
    }
}
