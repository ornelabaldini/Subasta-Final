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

        public bool RecibirPuja(int idSubasta, Postor postor, decimal monto, decimal pujaMinima)
        {
            var subasta = ObtenerSubastaPorId(idSubasta);
            if (subasta == null)
                throw new Exception("Subasta no encontrada.");

            // Determinar el mínimo para esta puja
            decimal minimo = subasta.MontoActual == 0 ? subasta.PrecioBase : subasta.MontoActual + pujaMinima;

            // Validar que la puja cumpla con el mínimo
            if (monto < minimo)
                return false;

            // Registrar la puja
            var nuevaPuja = new Puja { Postor = postor, Subasta = subasta, Monto = monto, Fecha = DateTime.Now };
            subasta.Pujas.Add(nuevaPuja);

            // Actualizar MontoActual sumando la puja
            subasta.MontoActual += monto;

            return true;
        }

    }
}
