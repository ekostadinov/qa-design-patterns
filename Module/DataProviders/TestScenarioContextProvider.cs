using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.DataProviders;
using TechTalk.SpecFlow;

namespace Module.DataProviders
{
    /// <summary>
    /// A simple placeholder for the Specflow's ScenarioContext object available during test case execution.
    /// It lets you design your data and behavior in an abstraction so that you can swap out implementation at any time.
    /// </summary>
    class TestScenarioContextProvider : IDataProvider
    {
        string IDataProvider.GetData()
        {
            //return ScenarioContext.Current.TestError.Message;
            return "Some dummy test case data:" + DateTime.Now;
        }
    }
}
