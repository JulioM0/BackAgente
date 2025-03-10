using BackAgente.Modelos;
using Newtonsoft.Json;

namespace BackAgente.Repositorios
{
    public class GetLocationsRepo
    {
        private HttpClient _httpClient;
        private readonly NinjaOneRepo _repo;

        public GetLocationsRepo(HttpClient httpClient, NinjaOneRepo repo)
        {
            _httpClient = httpClient;
            _repo = repo;
        }
        public async Task<List<LocationsModel>> GetLocations()
        {
            var tokenResponse = await _repo.GetToken();
            string token = tokenResponse.access_token;

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("https://app.ninjarmm.com/v2/locations");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener el token {response.StatusCode} - {errorMessage}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<LocationsModel>>(responseContent);
            return result;
        }
    }
}
