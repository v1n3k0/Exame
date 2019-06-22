using Exame.Web.Arguments.Cosif;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Exame.Web.Service
{
    public class ServiceCosif
    {
        private const string BASEURL = "https://localhost:44335/api/Cosif/";

        public List<CosifResponse> Listar()
        {
            string action = "Listar";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Concat(BASEURL, action));

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            var cosifsJson = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<CosifResponse>>(cosifsJson);
        }

        public List<CosifResponse> ListarPorProduto(Guid codigoProduto)
        {
            string action = "ListarPorProduto";

            string parametro = $"?codigoProduto={codigoProduto}";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Concat(BASEURL, action, parametro));

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            var cosifsJson = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<CosifResponse>>(cosifsJson);
        }
    }
}