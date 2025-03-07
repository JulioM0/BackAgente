using BackAgente.Modelos;
using Newtonsoft.Json;

namespace BackAgente.Repositorios
{
    public class OrganizacionesRepo
    {
        private HttpClient _httpClient;
        private readonly NinjaOneRepo _repo;
        public OrganizacionesRepo(HttpClient httpClient, NinjaOneRepo repo)
        {
            _httpClient = httpClient;
            _repo = repo;
        }
        public async Task<List<OrganizacionesModel>> GetOrganizaciones()
        {
            var tokenResponse = await _repo.GetToken();
            string token = tokenResponse.access_token; 

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("https://app.ninjarmm.com/v2/organizations");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener el token {response.StatusCode} - {errorMessage}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<OrganizacionesModel>>(responseContent);
            return result;
        }

        public async Task<List<DispositivosModel>> GetDispositivos()
        {
            var tokenResponse = await _repo.GetToken();
            string token = tokenResponse.access_token;
            int organizationId = 3;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://app.ninjarmm.com/v2/organization/{organizationId}/devices");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al obtener el token {response.StatusCode} - {errorMessage}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var dispositivos = JsonConvert.DeserializeObject<List<DispositivosModel>>(responseContent);

            return dispositivos.Where(d => d.organizationId == organizationId).ToList();
        }

        //public async Task<List<DetallesDispositivoModel>> GetDetalles()
        //{

        //}
    }
}
