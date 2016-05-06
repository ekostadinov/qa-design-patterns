using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton.TargetSystems
{
    /// <summary>
    /// The Multiton design pattern is an extension of the singleton pattern. It ensures that a limited number of instances
    /// of a class can exist by specifying a key for each instance and allowing only a single object to be created for each of those keys.
    /// </summary>
    internal sealed class TestRail
    {
        private static Dictionary<string, TestRail> _instances = new Dictionary<string, TestRail>();
        private static object _lock = new object();

        public string TestRunId { get; private set; }

        private TestRail()
        {
            TestRunId = Guid.NewGuid().ToString();
        }

        public static TestRail GetMultiton(string key)
        {
            lock (_lock)
            {
                if (!_instances.ContainsKey(key)) _instances.Add(key, new TestRail());
            }
            return _instances[key];
        }
    }
}
