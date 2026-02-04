using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subastas_Final.Views;
using Subastas_Final.Controllers;
using Subastas_Final.Services;

namespace Subastas_Final.Services
{
    internal class SubastadorService
    {
        readonly SubastadorRepository _subastadorRepository;
        public SubastadorService()
        {
            _subastadorRepository = new SubastadorRepository();
        }
        public bool CrearSubastador(Subastador nuevoSubastador)
        {
            nuevoSubastador.IdSubastador = _subastadorRepository.SiguienteIdSubastador;
            _subastadorRepository.CrearSubastador(nuevoSubastador);
            return true;
        }

        public List<Subastador> ObtenerTodosSubastadores()
        {
            return _subastadorRepository.ObtenerTodosSubastadores();
        }

        public Subastador ObtenerSubastadorPorId(int idSubastador)
        {
            return _subastadorRepository.ObtenerSubastadorPorId(idSubastador);
        }

        public bool ActualizarSubastador(Subastador subastadorActualizado)
        {
            var subastador = _subastadorRepository.ObtenerSubastadorPorId(subastadorActualizado.IdSubastador);
            if (subastador == null)
            {
                return false;
            }
            _subastadorRepository.ActualizarSubastador(subastadorActualizado);
            return true;
        }

        public bool EliminarSubastador(int idSubastador)
        {
            var subastador = _subastadorRepository.ObtenerSubastadorPorId(idSubastador);
            if (subastador == null)
            {
                return false;
            }
            _subastadorRepository.EliminarSubastador(idSubastador);
            return true;
        }
    }
}
