using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Servant
{
    /// <summary>
    /// Servant that takes care of requests sending, and accepts Serviced class instance as param
    /// </summary>
    class SendServant
    {
        internal IRestResponse SendIXRequest(IXServiceRequestSendable myServiceContractRequest)
        {
            RestClient client = new RestClient(myServiceContractRequest.EndPoint);
            RestRequest request = new RestRequest(myServiceContractRequest.HttpMethod);

            AddHeaders(request, myServiceContractRequest.SiteCode);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(myServiceContractRequest.MyServiceContract);
            
            //demo purpose
            Console.WriteLine("Request info: ");
            Console.WriteLine(request.Parameters[0].Name + ": " + request.Parameters[0].Value);
            Console.WriteLine(request.Parameters[3].Name + ": " + request.Parameters[3].Value);
            
            var response = client.Execute(request);
            
            return response;
        }

        private void AddHeaders(IRestRequest request, string siteCode)
        {
            request.AddHeader("x-site-code", siteCode);
            request.AddHeader("x-correlation-token", Guid.NewGuid().ToString());
            request.AddHeader("Content-Type", "application/json");
        }
    }
}
