﻿using System.Net.Http;

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
            }
            return httpClientInstance;
        }
    }
}