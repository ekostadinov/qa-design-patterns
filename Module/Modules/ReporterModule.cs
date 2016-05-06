using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.DataProviders;
using Module.Plugins;

namespace Module.Modules
{
    /// <summary>
    /// Extensibility modules let you consolidate your plug-ins into a centralized class, giving all your coders one place to go to
    /// in order to figure out what kind of extensibility is available to them for a given application.
    /// </summary>
    public static class ReporterModule
    {
        public static void ReportDataToSources(string data)
        {
            if (!String.IsNullOrEmpty(data))
            {
                Hashtable table = new Hashtable((from key in System.Configuration.ConfigurationManager.AppSettings.Keys.Cast<string>()
                                                 let value = System.Configuration.ConfigurationManager.AppSettings[key]
                                                 select new { key, value }).ToDictionary(x => x.key, x => x.value));
                foreach (var element in table.Keys)
                {
                    if (element.ToString().Contains("reporter"))
                    {
                        string reporterStr = table[element].ToString();
                        Object obj = Activator.CreateInstance(Type.GetType(reporterStr));
                        IReporterPlugin reporterPlugin = obj as IReporterPlugin;
                        reporterPlugin.LogData(data);
                    }
                }
            }
        }
    }
}
