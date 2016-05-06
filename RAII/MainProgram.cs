using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAII
{
    /// <summary>
    /// Main goal is to solve issues like - file never closed, object never deleted, lock never released
    /// </summary>
    class MainProgram
    {
        private static void Main(string[] args)
        {
            //Description of the pattern:
            //holding a resource is tied to object lifetime: resource allocation (acquisition) is done during object creation (specifically initialization),
            //by the constructor, while resource deallocation (release) is done during object destruction, by the destructor. 
            //If objects are destroyed properly, resource leaks do not occur.
            //The constructor and destructor definitions next to each other in the class definition.
            //Resource management therefore needs to be tied to the lifespan of suitable objects in order to gain automatic allocation and reclamation. 
            //Resources are acquired during initialization, when there is no chance of them being used before they are available, 
            //and released with the destruction of the same objects, which is guaranteed to take place even in case of errors.

            #region ParallelTasks
            // Perform three tasks in parallel on the source array
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task...");
                GetDedicatedObjectsManager();
            },  // close first Action

                             () =>
                             {
                                 Console.WriteLine("Begin second task...");
                                 GetDedicatedObjectsManager();
                             }, //close second Action

                             () =>
                             {
                                 Console.WriteLine("Begin third task...");
                                 GetDedicatedObjectsManager();
                             } //close third Action
                         ); //close parallel.invoke
            #endregion

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
           
        }

        private static void GetDedicatedObjectsManager()
        {
            DedicatedObjectsManager manager = new DedicatedObjectsManager();
            Console.WriteLine("Dedicated user used: " + manager.DedicatedObject);
            manager.ReleaseDedicatedObjectAsync();
        }
    }
}
