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
        public bool CrearSubastador(Subastador sub, out Subastador registrado)
        {
            return _subastadorService.CrearSubastador(sub, out registrado);
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
