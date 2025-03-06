using BackAgente.Modelos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace BackAgente.Repositorios
{
    public class NinjaOneRepo
    {
        private HttpClient _httpClient;

        public NinjaOneRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<NinjaOneModel> GetToken()
        {
            var data = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"},
                {"client_id", "OLvqegmGELB2YoSDD-XHrUxpMEA"},
                {"client_secret", "vS4bB90w69o93bvXUIULW5uqI9ERgjEsfv6W9vEia0AdIOv_CAXz1A"},
                {"scope", "monitoring offline_access"},
            };

            var content = new FormUrlEncodedContent(data);
            var response = await _httpClient.PostAsync("https://app.ninjarmm.com/ws/oauth/token", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener el token: {response.StatusCode} - {errorMessage}");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NinjaOneModel>(responseContent);

            return result;
        }
    }
}
