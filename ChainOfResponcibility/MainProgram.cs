using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponcibility
{
    /// <summary>
    /// This pattern encapsulates the processing elements inside a "pipeline" abstraction and have clients "launch and leave" their requests at the entrance to the pipeline.
    /// Can be implemented as
    /// [#1] One or more Receiver handles the Request, or 
    /// #2 Only one Receiver handles the Request
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            TestCaseClient client = new TestCaseClient();
            //client.TestUser = new CreateUserHandler().RegisterTestUser("basic");
            //client.TestUser = new CreateUserHandler().RegisterTestUser("banking");
            client.TestUser = new CreateUserHandler().RegisterTestUser("bonus");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
