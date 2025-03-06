using BackAgente.Repositorios;
using Microsoft.AspNetCore.Components;

namespace BackAgente.Services
{
    public class NinjaOneService
    {
        private readonly NinjaOneRepo _repo;
        public NinjaOneService(NinjaOneRepo ninjaOneRepo)
        {
            _repo = ninjaOneRepo;
        }
    }
}
