using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponcibility.DomainObjects;

namespace ChainOfResponcibility.Handlers
{
    class RegistrationHandler
    {
        public BasicUser RegisterUser(BasicUser requestedUser)
        {
            // send request to corresponding Registration service
            Console.WriteLine("Basic user is created!");
            Random rand = new Random();
            requestedUser.PlayerId = rand.Next(12345678, 999999999).ToString();
            Console.WriteLine("With ID: " + requestedUser.PlayerId);
            requestedUser.UserName = "tu" + rand.Next(2134, 9999999);
            Console.WriteLine("With Username:" + requestedUser.UserName);
            return requestedUser;
        }
    }
}
