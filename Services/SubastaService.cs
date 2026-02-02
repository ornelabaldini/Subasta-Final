using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            nuevaSubasta.IdSubasta = _subastaRepository.SiguienteIdSubasta;
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
            {
                return false;
            }
            _subastaRepository.EliminarSubasta(idSubasta);
            return true;
        }
        public bool ActualizarSubasta(Subasta subastaActualizada)
        {
            var subasta = _subastaRepository.ObtenerSubastaPorId(subastaActualizada.IdSubasta);
            if (subasta == null)
            {
                return false;
            }
            _subastaRepository.ActualizarSubasta(subastaActualizada);
            return true;
        }
        public bool ActualizarPostorGanador(int idSubasta, int idGanador)
            {
            var subasta = _subastaRepository.ObtenerSubastaPorId(idSubasta);
            if (subasta == null)
            {
                return false;
            }
            subasta.IdGanador = idGanador;
            _subastaRepository.ActualizarSubasta(subasta);
            return true;
        }
    }
}