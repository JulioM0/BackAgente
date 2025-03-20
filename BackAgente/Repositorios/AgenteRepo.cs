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
        private readonly OrganizationsRepo _organizationsRepo;
        public AgenteRepo(HttpClient httpClient, NinjaOneRepo repo, GetLocationsRepo getLocationsRepo, OrganizationsRepo organizationsRepo)
        {
            _httpClient = httpClient;
            _repo = repo;
            _getLocationsRepo = getLocationsRepo;
            _organizationsRepo = organizationsRepo;
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
                throw new HttpRequestException($"Error al obtener los dispositivos {responseOrg.StatusCode} - {errorMessage}");
            }

            var responseContentOrg = await responseOrg.Content.ReadAsStringAsync();
            var dispositivosOrg = JsonConvert.DeserializeObject<List<DetallesDispositivoModel>>(responseContentOrg);

            var organizaciones = await _organizationsRepo.GetOrganizations(0);
            var dictOrganizaciones = organizaciones.ToDictionary(o => o.id, o => o.name);

            foreach (var dispositivo in dispositivosOrg)
            {
                if (dictOrganizaciones.TryGetValue(dispositivo.organizationId, out string orgName))
                {
                    dispositivo.organizationName = orgName;
                }
                else
                {
                    dispositivo.organizationName = "Desconocido";
                }
            }
            return dispositivosOrg;
        }
    }
}