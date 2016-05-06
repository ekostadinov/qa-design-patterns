using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Servant
{
    /// <summary>
    /// Serviced class that makes use of external Servant services, some of it's functionality is moved to a Servant
    /// </summary>
    internal class XServiceContractRequest : IXServiceRequestSendable 
    {
        public IXService MyServiceContract { get; set; }
        public Method HttpMethod { get; set; }
        public string EndPoint { get; set; }
        public string SiteCode { get; set; }

        public IRestResponse SendIXRequest()
        {
            var servant = new SendServant();
            return servant.SendIXRequest(GetMyServiceContractRequest());
        }

        // may use param from Enum defining the Contracts that can be used
        private IXServiceRequestSendable GetMyServiceContractRequest()
        {
            var xContract = new XServiceContract();
            xContract.PlayerId = Int64.MaxValue;
            var contractBuilder = new XServiceContractRequestBuilder();
            var request = contractBuilder.WithBody(xContract)
                .AtEndPoint("http://myservice.com:9090") //may be moved to App.config
                .WithHttpMethod(Method.POST)
                .WithSideCode("mysite.com")
                .Build();

            return request;
        }
    }
}
