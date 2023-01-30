using Importador.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Importador
{
    public class FeriadoOrigemHttpClient
    {
        private readonly HttpClient _httpClient;

        public FeriadoOrigemHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<FeriadoOrigemDto>> ObterFeriadosAsync()
        {
            var feriados = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<FeriadoOrigemDto>>("");
            return feriados;
        }
    }
}
