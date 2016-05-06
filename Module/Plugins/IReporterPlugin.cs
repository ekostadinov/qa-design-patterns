using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Plugins
{
    interface IReporterPlugin
    {
        void LogData(string data);
    }
}
