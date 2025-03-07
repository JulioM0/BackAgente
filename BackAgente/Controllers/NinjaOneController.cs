using BackAgente.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace BackAgente.Controllers
{
    [Route("/activos")]
    public class NinjaOneController : Controller
    {
        private readonly NinjaOneRepo _repo;
        private readonly OrganizacionesRepo _organizacionesRepo;
        public NinjaOneController(NinjaOneRepo ninjaOneRepo, OrganizacionesRepo organizacionesRepo)
        {
            _repo = ninjaOneRepo;
            _organizacionesRepo = organizacionesRepo;
        }
        [HttpGet("token")]
        public async Task<IActionResult> Index()
        {
            var respuesta = await _repo.GetToken();
            return Ok(respuesta);
        }
        [HttpGet("organizations")]
        public async Task<IActionResult> Organizaciones()
        {
            var respuesta = await _organizacionesRepo.GetOrganizaciones();
            return Ok(respuesta);
        }
        [HttpGet("devices")]
        public async Task<IActionResult> Dispositivos()
        {
            var respuesta = await _organizacionesRepo.GetDispositivos();
            return Ok(respuesta);
        }
    }
}
