using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using State.Context;

namespace State
{
    /// <summary>
    /// Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            MyCustomTest test = new MyCustomTest();
            test.UseProfile();

            Console.ReadKey();
        }
    }
}
