using Subastas_Final.Entities;
using Subastas_Final.Services;
using System.Collections.Generic;


namespace Subastas_Final.Controllers
{
    internal class SubastadorController
    {
        readonly SubastadorService _subastadorService;
        public SubastadorController()
        {
            _subastadorService = new SubastadorService();
        }
        public bool CrearSubastador(Subastador nuevoSubastador)
        {
            return _subastadorService.CrearSubastador(nuevoSubastador);
        }
        public List<Subastador> ObtenerTodosSubastadores()
        {
            return _subastadorService.ObtenerTodosSubastadores();
        }
        public Subastador ObtenerSubastadorPorId(int idSubastador)
        {
            return _subastadorService.ObtenerSubastadorPorId(idSubastador);
        }
        public bool ActualizarSubastador(Subastador subastadorActualizado)
        {
            return _subastadorService.ActualizarSubastador(subastadorActualizado);
        }
        public bool EliminarSubastador(int idSubastador)
        {
            return _subastadorService.EliminarSubastador(idSubastador);
        }
    }
}
