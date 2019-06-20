using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Exame.Web
{
    public class HttpInstance
    {
        private static HttpClient httpClientInstance;

        public HttpInstance()
        {
        }

        public static HttpClient GetHttpClientInstance()
        {
            if(httpClientInstance == null)
            {
                httpClientInstance = new HttpClient();
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
                httpClientInstance.DefaultRequestHeaders.Accept.Clear();
                httpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return httpClientInstance;
        }
    }
}