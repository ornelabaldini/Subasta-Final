using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Subastas_Final.Services
{
    internal class SubastaService
    {
        private readonly SubastaRepository _subastaRepository;

        public SubastaService()
        {
            _subastaRepository = new SubastaRepository();
        }

        public bool CrearSubasta(Subasta nuevaSubasta)
        {
            if (nuevaSubasta == null)
                return false;

            DateTime ahora = DateTime.Now;

            // La fecha de inicio siempre la define el sistema
            nuevaSubasta.FechaInicio = ahora;

            // Validaciones de fecha
            if (nuevaSubasta.FechaFin <= ahora)
                return false;

            if (nuevaSubasta.FechaFin < ahora.AddMinutes(1))
                return false;

            // Inicializaciones obligatorias
            nuevaSubasta.Estado = true;
            nuevaSubasta.MontoActual = nuevaSubasta.PrecioBase;
            nuevaSubasta.Pujas = new List<Puja>();
            nuevaSubasta.Postores = new List<Postor>();

            _subastaRepository.CrearSubasta(nuevaSubasta);
            return true;
        }

        public List<Subasta> ObtenerTodasSubastas()
        {
            return _subastaRepository.ObtenerTodasSubastas();
        }

        public Subasta ObtenerSubastaPorId(int idSubasta)
        {
            return _subastaRepository.ObtenerSubastaPorId(idSubasta);
        }

        public bool EliminarSubasta(int idSubasta)
        {
            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);
            if (subasta == null)
                return false;

            _subastaRepository.EliminarSubasta(idSubasta);
            return true;
        }

        public bool ActualizarSubasta(Subasta subastaActualizada)
        {
            var subasta = _subastaRepository.ObtenerSubastaPorId(subastaActualizada.IdSubasta);
            if (subasta == null)
                return false;

            _subastaRepository.ActualizarSubasta(subastaActualizada);
            return true;
        }

        public bool ActualizarPostorGanador(int idSubasta, int idGanador)
        {
            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);
            if (subasta == null)
                return false;

            subasta.IdGanador = idGanador;
            _subastaRepository.ActualizarSubasta(subasta);
            return true;
        }

        public List<Subasta> FiltrarSubastas(string tipoFiltro)
            {
                var todas = ObtenerTodasSubastas() ?? new List<Subasta>();
                var hoy = DateTime.Now;

                switch (tipoFiltro)
                {
                    case "Subastas en curso":
                        return todas.Where(s => s.Estado && s.FechaInicio <= hoy && s.FechaFin >= hoy).ToList();

                    case "Últimas 10 finalizadas":
                        return todas.Where(s => !s.Estado)
                                    .OrderByDescending(s => s.FechaFin)
                                    .Take(10)
                                    .ToList();

                    case "Subastas pendientes":
                        return todas.Where(s => s.FechaInicio > hoy).ToList();

                    default:
                        return todas;
                }
            }

        public void ActualizarSubastasVencidas()
        {
            var subastas = _subastaRepository.ObtenerTodasSubastas();
            var ahora = DateTime.Now;

            foreach (var subasta in subastas)
            {
                if (subasta.Estado && subasta.FechaFin <= ahora)
                {
                    subasta.Estado = false;

                    // calcular ganador
                    if (subasta.Pujas != null && subasta.Pujas.Count > 0)
                    {
                        var pujaGanadora = subasta.Pujas
                            .OrderByDescending(p => p.Monto)
                            .First();

                        subasta.IdGanador = pujaGanadora.Postor.IdPostor;
                        subasta.MontoActual = pujaGanadora.Monto;
                    }

                    _subastaRepository.ActualizarSubasta(subasta);
                }
            }
        }

    }
}

