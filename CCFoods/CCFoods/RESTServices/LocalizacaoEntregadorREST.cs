using Modulo1.DAL;
using Modulo1.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modulo1.RESTServices
{
    public class LocalizacaoEntregadorREST
    {
        private HttpClient client;

        public LocalizacaoEntregadorREST ()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task UpdateLocalizacaoToServerAsync(IEnumerable<LocalizacaoEntregador> localizacoes)
        {
            var uri = new Uri(string.Format("https://aplicationserverapi.azurewebsites.net/localizacao/insert"));

            var localizacaoDAL = new LocalizacaoEntregadorDAL();
            foreach (var localizacao in localizacoes)
            {
                var json = JsonConvert.SerializeObject(localizacao);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    localizacao.OperacaoSincronismo = Modelo.Enums.OperacaoSincronismo.Sincronizado;
                    localizacaoDAL.Update(localizacao);
                }
            }
        }

        public async Task<List<LocalizacaoEntregador>> GetLocalizacoesAsync()
        {
            var uri = new Uri(string.Format("https://aplicationserverapi.azurewebsites.net/localizacao/todos"));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<LocalizacaoEntregador>>(content);
            }
            return null;
        }
    }
}
