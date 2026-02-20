using Subastas_Final.Entities;
using Subastas_Final.Services;
using System.Collections.Generic;

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

        public List<Puja> ObtenerTodasPujas()
        {
            return _pujaService.ObtenerTodasPujas();
        }

        public Puja ObtenerPujaPorId(int idPuja)
        {
            return _pujaService.ObtenerPujaPorId(idPuja);
        }

        public List<Puja> ObtenerPujasPorSubasta(int idSubasta)
        {
            return _pujaService.ObtenerPujasPorSubasta(idSubasta);
        }

        public List<Puja> ObtenerPujasPorPostor(int idPostor)
        {
            return _pujaService.ObtenerPujasPorPostor(idPostor);
        }

         public void ActualizarPuja(Puja puja)
        {
            _pujaService.ActualizarPuja(puja);
        }
  
        public void EliminarPuja(int idPuja)
        {
            _pujaService.EliminarPuja(idPuja);
        }
    }
}