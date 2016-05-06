using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.DataProviders;
using Module.Modules;

namespace Module
{
    /// <summary>
    /// The Module pattern can be considered a creational pattern and a structural pattern. It manages the creation and organization of other elements,
    /// and groups them as the structural pattern does. An object that applies this pattern can provide the equivalent of a namespace,
    /// providing the initialization and finalization process of a static class or a class with static members with cleaner, more concise syntax and semantics.
    /// It supports specific cases where a class or object can be considered structured, procedural data.
    /// And, vice versa, migrate structured, procedural data, and considered as object-oriented.
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            string testCaseData = DataProviderFactory.GetData();
            ReporterModule.ReportDataToSources(testCaseData);
        }
    }
}
