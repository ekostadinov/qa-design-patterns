using System;

namespace ObjectPool
{
    class ExampleUsage
    {
        static void Main(string[] args)
        {
            Pool.PrintPool();
            var user1 = Pool.GetObject();
            Pool.PrintPool();
            var user2 = Pool.GetObject();
            Pool.PrintPool();
            Pool.ReleaseObject(user2);
            Pool.PrintPool();
            var user3 = Pool.GetObject();
            Pool.PrintPool();
            var user4 = Pool.GetObject();
            Pool.PrintPool();
            var user5 = Pool.GetObject();
            Pool.PrintPool();

            Console.WriteLine("Stop here");
        }
    }
}
