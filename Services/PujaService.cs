using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Linq;

namespace Subastas_Final.Services
{
    internal class PujaService
    {
        private readonly PujaRepository _pujaRepository;
        private readonly SubastaRepository _subastaRepository;

        public PujaService()
        {
            _pujaRepository = new PujaRepository();
            _subastaRepository = new SubastaRepository();
        }

        public bool CrearPuja(int idSubasta, Postor postor, decimal montoIngresado)
        {
            if (postor == null)
                return false;

            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);

            if (subasta == null || !subasta.Estado)
                return false;

            if (DateTime.Now >= subasta.FechaFin)
                return false;

            // El subastador no puede pujar
            if (subasta.Subastador.Email == postor.Email)
                return false;

            decimal montoMinimo = subasta.Pujas.Count == 0
                ? subasta.PrecioBase
                : subasta.MontoActual + subasta.PujaMinima;

            if (montoIngresado < montoMinimo)
                return false;

            // Crear puja
            var nuevaPuja = new Puja(postor, subasta, montoIngresado, DateTime.Now);

            // Persistir en repositorio
            _pujaRepository.CrearPuja(nuevaPuja);

            // Agregar a la subasta
            subasta.Pujas.Add(nuevaPuja);

            if (!subasta.Postores.Any(p => p.IdPostor == postor.IdPostor))
                subasta.Postores.Add(postor);

            subasta.MontoActual = montoIngresado;
            subasta.IdGanador = postor.IdPostor;

            _subastaRepository.ActualizarSubasta(subasta);

            return true;
        }
    }
}
