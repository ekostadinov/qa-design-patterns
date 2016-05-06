using System;
using System.Collections.Generic;

namespace ObjectPool
{
    public class Pool
    {
        public static Stack<User> UsersPool = new Stack<User>(new[] {new User("Yanko"), new User("Ina"), new User("Evgeni")});

        public static User GetObject()
        {
            lock (UsersPool)
            {
                if (UsersPool.Count != 0)
                {
                    var user = UsersPool.Pop();
                    Console.WriteLine("Will use user from the pool: " + user.Username);
                    return user;
                }
                else
                {
                    UsersPool.Push(new User());
                    var user = UsersPool.Pop();
                    Console.WriteLine("Pool is empty so new User is created: " + user.Username);
                    return user;
                    //If you don't want new user creation use the commented code below
                    //throw new Exception("Pool is empty! You need to wait!");
                }
            }
        }

        public static void ReleaseObject(User user)
        {
            lock (UsersPool)
            {
                UsersPool.Push(user);
                Console.WriteLine("User is push back in the pool: " + user.Username);
            }
        }

        public static void PrintPool()
        {
            Console.WriteLine("Pool count: " + UsersPool.Count);
            if (UsersPool.Count != 0)
            {
                Console.WriteLine("Available users: ");
                foreach (var user in UsersPool)
                {
                    Console.Write(user.Username + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Users pool is empty!");
            }
            Console.WriteLine();
        }
    }
}