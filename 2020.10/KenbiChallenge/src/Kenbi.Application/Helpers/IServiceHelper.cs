using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kenbi.Application.Helpers
{
    public interface IServiceHelper
    {
        Task<Toutput> GetRequest<Toutput>(string requestUri, string clientName);
        Task<Toutput> PostRequest<Tinput, Toutput>(string clientName, string requestUri, Tinput input);
    }
}
