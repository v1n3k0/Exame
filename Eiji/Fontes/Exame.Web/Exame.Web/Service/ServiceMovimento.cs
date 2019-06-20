using Exame.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Exame.Web.Service
{
    public class ServiceMovimento
    {
        private const string BASEURL = "https://localhost:44335/api/Movimento/";

        public List<Movimento> GetListar()
        {
            string action = "Listar";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Concat(BASEURL, action));

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            var movimentoJson = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Movimento>>(movimentoJson);
        }
    }
}