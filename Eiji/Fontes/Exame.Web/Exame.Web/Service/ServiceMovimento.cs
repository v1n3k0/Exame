using Exame.Web.Arguments.Movimento;
using Exame.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Exame.Web.Service
{
    public class ServiceMovimento
    {
        private const string BASEURL = "https://localhost:44335/api/Movimento/";

        public List<Movimento> Listar()
        {
            string action = "Listar";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Concat(BASEURL, action));

            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

            var movimentosJson = response.Content.ReadAsStringAsync().Result;

            var movimentosResponse = JsonConvert.DeserializeObject<List<MovimentoResponse>>(movimentosJson);

            return movimentosResponse.Select(x => (Movimento)x).ToList();
        }

        public Movimento AdicionarMovimento(Movimento movimento)
        {
            string action = "Adicionar";
            
            HttpResponseMessage response = HttpInstance.GetHttpClientInstance().PostAsJsonAsync(string.Concat(BASEURL, action), (AdicionarMovimentoRequest)movimento).Result;

            var movimentoJson = response.Content.ReadAsStringAsync().Result;

            var movimentoResponse = JsonConvert.DeserializeObject<MovimentoResponse>(movimentoJson);

            return (Movimento)movimentoResponse;
        }
    }
}