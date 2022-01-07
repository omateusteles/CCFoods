﻿using Modulo1.Modelo;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Modulo1.RESTServices
{
    public class ConfiguracaoDispositivoREST
    {
        private HttpClient client;
        public ConfiguracaoDispositivo ConfiguracaoDispositivo { get; set; }
        
        public ConfiguracaoDispositivoREST()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<long?> GetDispositivoIdAsync(string eMail)
        {
            long? id = null;

            // Testei em uma rede esta URL e por problema com a configuração troquei o domínio para o IP e funcionou.Observe também o HTTPS
            var uri = new Uri(string.Format("https://aplicationserverapi.azurewebsites.net/dispositivos/configuracao?email={0}", eMail));
            var response = await client.GetAsync(uri);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                id = JsonConvert.DeserializeObject<long>(content);
            }
            return id;
        }
    }
}