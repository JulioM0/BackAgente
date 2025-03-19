using BackAgente.Modelos;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace BackAgente.Repositorios
{
    public class AgenteRepo
    {
        private HttpClient _httpClient;
        private readonly NinjaOneRepo _repo;
        private readonly GetLocationsRepo _getLocationsRepo;
        public AgenteRepo(HttpClient httpClient, NinjaOneRepo repo, GetLocationsRepo getLocationsRepo)
        {
            _httpClient = httpClient;
            _repo = repo;
            _getLocationsRepo = getLocationsRepo;
        }

        public async Task<List<DetallesDispositivoModel>> GetDispositivos(int id)
        {
            var tokenResponse = await _repo.GetToken();
            string token = tokenResponse.access_token;
            string filterLocation = $"location in ({id})";
           
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);  
            var responseOrg = await _httpClient.GetAsync($"https://app.ninjarmm.com/v2/devices-detailed?df={filterLocation}");
            if (!responseOrg.IsSuccessStatusCode)
            {
                var errorMessage = await responseOrg.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener el token {responseOrg.StatusCode} - {errorMessage}");
            }
            var responseContentOrg = await responseOrg.Content.ReadAsStringAsync();
            var dispositivosOrg = JsonConvert.DeserializeObject<List<DetallesDispositivoModel>>(responseContentOrg);
            return dispositivosOrg;
        }
    }
}