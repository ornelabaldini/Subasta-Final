using Subastas_Final.Entities;
using Subastas_Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Controllers
{
    internal class SubastaController
    {
        readonly SubastaService _subastaService;

        public SubastaController()
        {
            _subastaService = new SubastaService();
        }

        public bool CrearSubasta(Subasta nuevaSubasta)
        {
            return _subastaService.CrearSubasta(nuevaSubasta);
        }

        public List<Subasta> ObtenerTodasSubastas()
        {
            return _subastaService.ObtenerTodasSubastas();
        }   

        public Subasta ObtenerSubastaPorId(int idSubasta)
        {
            return _subastaService.ObtenerSubastaPorId(idSubasta);
        }

        public bool ActualizarSubasta(Subasta subastaActualizado)
        {
            return _subastaService.ActualizarSubasta(subastaActualizado);
        }

        public bool EliminarSubasta(int idSubasta)
        {
            return _subastaService.EliminarSubasta(idSubasta);
        }

    }
}
