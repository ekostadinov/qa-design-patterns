using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servant
{
    /// <summary>
    /// Is used to offer some functionality to a group of classes without defining that functionality in each of them.
    /// A Servant is a class whose instance (or even just class) provides methods that take care of a desired service, 
    /// while objects for which (or with whom) the servant does something, are taken as parameters.
    /// Thus the shared code appears in only one class which respects the “Separation of Concerns” rule.
    /// Design patterns Command and Servant are very similar and implementations of them are often virtually the same.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            // User/Client don’t know about servant class and calls directly serviced classes.
            // Serviced classes then asks servant themselves to achieve desired functionality.
            XServiceContractRequest request = new XServiceContractRequest();
            var response = request.SendIXRequest();
            //demo purpose
            Console.WriteLine("Responce --> " + response.ErrorMessage);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
