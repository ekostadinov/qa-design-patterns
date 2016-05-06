using System;
using System.Linq;

//The object pool pattern is a software creational design pattern that uses
//a set of initialized objects kept ready to use – a "pool" – 
//rather than allocating and destroying them on demand. 
//A client of the pool will request an object from the pool and perform 
//operations on the returned object. When the client has finished, 
//it returns the object to the pool rather than destroying it - 
//this can be done manually or automatically.

namespace ObjectPool
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            Username = RandomString(8);
            Password = RandomString(8);
        }

        public User(string username)
        {
            Username = username;
            Password = RandomString(8);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random(Environment.TickCount);
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
