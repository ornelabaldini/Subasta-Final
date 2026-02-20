using Subastas_Final.Entities;
using Subastas_Final.Services;

namespace Subastas_Final.Controllers
{
    internal class PujaController
    {
        private readonly PujaService _pujaService;

        public PujaController()
        {
            _pujaService = new PujaService();
        }

        public bool CrearPuja(int idSubasta, Postor postor, decimal monto)
        {
            return _pujaService.CrearPuja(idSubasta, postor, monto);
        }
    }
}
