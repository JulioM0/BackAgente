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
        public NinjaOneController(NinjaOneRepo ninjaOneRepo, AgenteRepo agenteRepo, GetLocationsRepo getLocationsRepo)
        {
            _repo = ninjaOneRepo;
            _agenteRepo = agenteRepo;
            _getLocationsRepo = getLocationsRepo;
        }
        [HttpGet("token")]
        public async Task<IActionResult> Index()
        {
            var respuesta = await _repo.GetToken();
            return Ok(respuesta);
        }
        [HttpGet("locations")]
        public async Task<IActionResult> Localizaciones()
        {
            var respuesta = await _getLocationsRepo.GetLocations();
            return Ok(respuesta);
        }
        [HttpGet("devices")]
        public async Task<IActionResult> Dispositivos()
        {
            var respuesta = await _agenteRepo.GetDispositivos();
            return Ok(respuesta);
        }
    }
}
