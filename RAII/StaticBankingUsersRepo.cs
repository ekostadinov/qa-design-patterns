using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAII
{
    /// <summary>
    /// A ConcurrentQueue is used instead of ObjectPoll (based on ConcurrentBag<T>), since
    /// the required by tests multiple instances of a class and the class is not expensive to create or destroy,
    /// but is a matter of locking/releasing them
    /// </summary>
    static class StaticBankingUsersRepo
    {
        private static ConcurrentQueue<StaticBankingUser> _staticBankingUsers;

        public static ConcurrentQueue<StaticBankingUser> StaticBankingUsers
        {
            get { return _staticBankingUsers; }
            set { _staticBankingUsers = value; }
        }

        static StaticBankingUsersRepo()
        {
            _staticBankingUsers = new ConcurrentQueue<StaticBankingUser>();
            _staticBankingUsers.Enqueue(new StaticBankingUser() {UserName = "userCC1"});
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC2" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC3" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC4" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC5" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC6" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC7" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC8" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC9" });
            _staticBankingUsers.Enqueue(new StaticBankingUser() { UserName = "userCC10" });
        }
    }
}
