using Exame.Dominio.Arguments.Produto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Exame.Web.Service
{
    public class ServiceProduto
    {
        private const string BASEURL = "https://localhost:44335/api/Produto/";

        public List<ProdutoResponse> GetListar()
        {
            string action = "Listar";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Concat(BASEURL, action));

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            var produtosJson = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<ProdutoResponse>>(produtosJson);
        }
    }
}