using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Servant
{
    /// <summary>
    /// Define an interface specifying requested Send behavior of serviced objects.
    /// If some instance wants to be served by Send servant, it must implement this interface.
    /// </summary>
    interface IXServiceRequestSendable
    {
        IXService MyServiceContract { get; set; }
        Method HttpMethod { get; set; }
        string EndPoint { get; set; }
        string SiteCode { get; set; }
        IRestResponse SendIXRequest();
    }
}
