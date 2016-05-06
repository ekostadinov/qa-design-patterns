using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Servant
{
    /// <summary>
    /// Fluent builder pattern
    /// </summary>
    class XServiceContractRequestBuilder
    {
        private IXService _myServiceContract;
        private Method _httpMethod;
        private string _endPoint;
        private string _siteCode;

        public XServiceContractRequestBuilder WithBody(IXService myServiceContract)
        {
            this._myServiceContract = myServiceContract;
            return this;
        }

        public XServiceContractRequestBuilder WithHttpMethod(Method httpMethod)
        {
            this._httpMethod = httpMethod;
            return this;
        }

        public XServiceContractRequestBuilder AtEndPoint(string endPoint)
        {
            this._endPoint = endPoint;
            return this;
        }

        public XServiceContractRequestBuilder WithSideCode(string siteCode)
        {
            this._siteCode = siteCode;
            return this;
        }

        public XServiceContractRequest Build()
        {
            return new XServiceContractRequest()
            {
                MyServiceContract = this._myServiceContract,
                HttpMethod = this._httpMethod,
                EndPoint = this._endPoint,
                SiteCode = this._siteCode
            };
        }
    }
}
