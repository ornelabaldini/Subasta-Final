using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Subastas_Final.Services
{
    internal class SubastaService
    {
        readonly SubastaRepository _subastaRepository;

        public SubastaService()
        {
            _subastaRepository = new SubastaRepository();
        }

        public bool CrearSubasta(Subasta nuevaSubasta)
        {
            if (nuevaSubasta == null)
                return false;

            DateTime ahora = DateTime.Now;

            // Fecha inicio SIEMPRE la decide el sistema
            nuevaSubasta.FechaInicio = ahora;

            // Validaciones
            if (nuevaSubasta.FechaFin <= ahora)
                return false;

            if (nuevaSubasta.FechaFin < ahora.AddHours(1))
                return false;

            // Inicializaciones obligatorias
            nuevaSubasta.Estado = true;
            nuevaSubasta.MontoActual = nuevaSubasta.PrecioBase;
            nuevaSubasta.Pujas = new List<Puja>();

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
            if (subasta == null) return false;
            _subastaRepository.ActualizarSubasta(subastaActualizada);
            return true;
        }

        public bool ActualizarPostorGanador(int idSubasta, int idGanador)
        {
            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);
            if (subasta == null) return false;
            subasta.IdGanador = idGanador;
            _subastaRepository.ActualizarSubasta(subasta);
            return true;
        }

        public bool Pujar(int idSubasta, Postor postor)
        {
            // Obtener la subasta
            var subasta = ObtenerSubastaPorId(idSubasta);
            if (subasta == null || !subasta.Estado)
                return false;

            // Evitar que el subastador puje su propia subasta
            if (subasta.Subastador.IdSubastador == postor.IdPostor)
                return false;

            // Arranca desde el precio base si no hay pujas
            if (subasta.Pujas.Count == 0)
                subasta.MontoActual = subasta.PrecioBase;

            // La puja siempre es la puja mínima
            decimal monto = subasta.PujaMinima;

            // Crear y agregar la nueva puja
            Puja nuevaPuja = new Puja(postor, subasta, monto, DateTime.Now);
            subasta.Pujas.Add(nuevaPuja);

            // Si el postor no estaba en la subasta, lo agregamos
            if (!subasta.Postores.Any(p => p.IdPostor == postor.IdPostor))
                subasta.Postores.Add(postor);

            // Actualizar monto actual
            subasta.MontoActual += monto;

            return true;
        }


    }
}
