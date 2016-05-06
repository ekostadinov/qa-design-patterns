using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAII
{
    /// <summary>
    /// This functionality is based on shared/dedicated resources concept
    /// http://artoftroubleshooting.com/2013/03/22/dedicated-and-shared-resources/
    /// It works with file containing shared objects having flag ("shared" or "dedicated"), 
    /// idicating the availability state of the resource 
    /// </summary>
    class DedicatedObjectsManager
    {
        private readonly StaticBankingUser _dedicatedObject;

        // Zeus tests only need the username, no need to couple the Client projects with knowledge about StaticBankingUser class
        public string DedicatedObject
        {
            get { return this._dedicatedObject.UserName; }
        }

        // resource allocation (acquisition) by the constructor
        public DedicatedObjectsManager()
        {
            if (StaticBankingUsersRepo.StaticBankingUsers.TryDequeue(out _dedicatedObject)) { }
            Console.WriteLine("Currently available/shared banking users: " + StaticBankingUsersRepo.StaticBankingUsers.Count);
        }

        //The final "resource acquisition" part of RAII - destructor 
        public void ReleaseDedicatedObjectAsync()
        {
            StaticBankingUsersRepo.StaticBankingUsers.Enqueue(_dedicatedObject);
            Console.WriteLine("Currently available/shared banking users: " + StaticBankingUsersRepo.StaticBankingUsers.Count);
        }
        
    }
}
