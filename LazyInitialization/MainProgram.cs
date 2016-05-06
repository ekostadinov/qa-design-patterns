using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LazyInitialization
{
    class MainProgram
    {
        /// <summary>
        /// This pattern delays certain tasks. It typically improves the startup time of a C# application.
        /// This has always been possible to implement. But the .NET Framework now offers the Lazy type, which provides this feature.
        /// Implement your own Lazy initialization -> http://stackoverflow.com/questions/978759/what-is-lazy-initialization-and-why-is-it-useful
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create Lazy
            Lazy<LazyPage> lazyPage = new Lazy<LazyPage>();
            // Show that IsValueCreated is false
            Console.WriteLine("IsValueCreated = {0}", lazyPage.IsValueCreated);
            // Get the Value
            // ... This executes parameterless Constructor()
            LazyPage page = lazyPage.Value;
            // Show the IsValueCreated is true
            Console.WriteLine("IsValueCreated = {0}", lazyPage.IsValueCreated);
            // The object can be used.
            Console.WriteLine("Is page driver null = {0}", page.Driver.Equals(null));

            Console.ReadKey();
        }
    }
}
