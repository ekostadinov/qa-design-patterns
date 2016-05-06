using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Plugins
{
    /// <summary>
    /// It is build on the same abstraction design as providers and lets you build sections of your code in swappable modules. 
    /// In a way they are similar to providers, but where you generally use providers to obtain information, you use plug-ins typically to perform tasks
    /// </summary>
    class SqlDbReporterPlugin : IReporterPlugin
    {
        public void LogData(string data)
        {
            //some ORM logic to put data into the the DB
            Console.WriteLine("Your data is loged into the SQL DB!");
        }
    }
}
