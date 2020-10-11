using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kenbi.Application.Helpers
{
    public class ServiceHelper : IServiceHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        #region GET
        public async Task<Toutput> GetRequest<Toutput>(string clientName, string requestUri)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                 requestUri);

            var resp = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<Toutput>(resp.Content.ReadAsStringAsync().Result);

            return response;
        }
        #endregion GET

        #region POST
        public async Task<Toutput> PostRequest<Tinput,Toutput>(string clientName, string requestUri, Tinput input)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                 requestUri);

            request.Content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var resp = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<Toutput>(resp.Content.ReadAsStringAsync().Result);

            return response;
        }
        #endregion POST


        //private readonly string _baseUrl;
        //private readonly string _apiVersion;
        //public ServiceHelper(string baseUrl, string apiVersion = null)
        //{
        //    _baseUrl = baseUrl;
        //    _apiVersion = apiVersion;
        //}

        //#region GET

        //public Toutput GetRequest<Toutput>(IHttpClientFactory httpClientFactory,string requestUri, Dictionary<string, string> headers = null)
        //{
        //    var httpClient = _httpClientFactory.CreateClient("APIClient");

        //    var request = new HttpRequestMessage(
        //        HttpMethod.Get,
        //         _apiEndpoints.Challenge.GetAuth);

        //    var response = await httpClient.SendAsync(
        //        request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        //    //var client = new RestClient(_baseUrl);

        //    //var request = BuildRestRequest(requestUri, Method.GET, headers);

        //    //IRestResponse resp = client.Execute(request);
        //    var response = JsonConvert.DeserializeObject<Toutput>(resp.Content);

        //    return response;
        //}
        //#endregion GET

        //#region POST

        //public Toutput PostRequest<Tinput, Toutput>(string requestUri, Tinput input, Dictionary<string, string> headers = null)
        //{
        //    var client = new RestClient(_baseUrl);

        //    var request = BuildRestRequest(requestUri, Method.POST, headers);

        //    var serializerSettings = new JsonSerializerSettings
        //    {
        //        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //    };
        //    var jsonBody = JsonConvert.SerializeObject(input, serializerSettings);

        //    request.AddJsonBody(jsonBody);

        //    IRestResponse resp = client.Execute(request);
        //    var response = JsonConvert.DeserializeObject<Toutput>(resp.Content);

        //    return response;
        //}
        //#endregion POST



        //#region dispose
        //public virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        // Dispose managed resources
        //    }
        //    // Free native resources
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //~ServiceHelper()
        //{
        //    Dispose(false);
        //}
        //#endregion
    }
}
