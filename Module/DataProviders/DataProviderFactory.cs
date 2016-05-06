using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.DataProviders
{
    static class DataProviderFactory
    {
        private static IDataProvider _dataProvider;

        static DataProviderFactory()
        {
            _dataProvider = GetDataProvider();
        }

        private static IDataProvider GetDataProvider()
        {
            string providerStr = ConfigurationManager.AppSettings["dataProvider"];
            Object providerObj = Activator.CreateInstance(Type.GetType(providerStr));
            IDataProvider provider = providerObj as IDataProvider;

            return provider;
        }

        public static string GetData()
        {
            string data = _dataProvider.GetData();
            return data;
        }
    }
}
