using Importador.Dtos;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Importador
{
    public class FeriadoDestinoHttpClient
    {
        private readonly HttpClient _httpClient;

        public FeriadoDestinoHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarFeriadosAsync(IEnumerable<FeriadoDestinoDto> feriados)
        {
            var feriadosJsonString = new StringContent(
                JsonSerializer.Serialize(feriados),
                Encoding.UTF8,
                Application.Json);

            using var httpResponseMessage = await _httpClient.PostAsync("", feriadosJsonString);

            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}
