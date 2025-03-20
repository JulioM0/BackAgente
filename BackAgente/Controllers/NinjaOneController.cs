using BackAgente.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace BackAgente.Controllers
{
    [Route("/activos")]
    public class NinjaOneController : Controller
    {
        private readonly NinjaOneRepo _repo;
        private readonly AgenteRepo _agenteRepo;
        private readonly GetLocationsRepo _getLocationsRepo;
        private readonly OrganizationsRepo _organizationsRepo;
        public NinjaOneController(NinjaOneRepo ninjaOneRepo, AgenteRepo agenteRepo, GetLocationsRepo getLocationsRepo, OrganizationsRepo organizationsRepo)
        {
            _repo = ninjaOneRepo;
            _agenteRepo = agenteRepo;
            _getLocationsRepo = getLocationsRepo;
            _organizationsRepo = organizationsRepo;
        }
        [HttpGet("token")]
        public async Task<IActionResult> Index()
        {
            var respuesta = await _repo.GetToken();
            return Ok(respuesta);
        }
        [HttpGet("organizations")]
        public async Task<IActionResult> Organizaciones([FromQuery] int organizationId)
        {
            var respuesta = await _organizationsRepo.GetOrganizations(organizationId);
            return Ok(respuesta);
        }
        [HttpGet("locations")]
        public async Task<IActionResult> Localizaciones()
        {
            var respuesta = await _getLocationsRepo.GetLocations();
            return Ok(respuesta);
        }
        [HttpGet("devices")]
        public async Task<IActionResult> Dispositivos([FromQuery] int id)
        {
            var respuesta = await _agenteRepo.GetDispositivos(id);
            return Ok(respuesta);
        }
    }
}