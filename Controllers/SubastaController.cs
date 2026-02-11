using Subastas_Final.Entities;
using Subastas_Final.Services;
using System.Collections.Generic;


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

        public bool ActualizarPostorGanador(int idSubasta, int idGanador)
        {
            return _subastaService.ActualizarPostorGanador(idSubasta, idGanador);
        }

        public bool Pujar(int idSubasta, Postor postor, decimal montoIngresado)
        {
            return _subastaService.Pujar(idSubasta, postor, montoIngresado);
        }

        public List<Subasta> FiltrarSubastas(string tipoFiltro)
        {
            return _subastaService.FiltrarSubastas(tipoFiltro);
        }
        public void ActualizarSubastasVencidas()
        {
            _subastaService.ActualizarSubastasVencidas();
        }


    }
}
