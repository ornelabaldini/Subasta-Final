using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System.Collections.Generic;


namespace Subastas_Final.Services
{
    internal class SubastadorService
    {
        readonly SubastadorRepository _subastadorRepository;
        public SubastadorService()
        {
            _subastadorRepository = new SubastadorRepository();
        }
        public bool CrearSubastador(Subastador nuevoSubastador, out Subastador registrado)
{
            // Verificar si ya existe por email
            var existente = _subastadorRepository.ObtenerTodosSubastadores()
                .Find(s => s.Email.ToLower() == nuevoSubastador.Email.ToLower());

            if (existente != null)
            {
                registrado = existente; // devolvemos el que ya existía
                return false;            // no se creó uno nuevo
            }

            // Guardar usando el repositorio (que asigna el ID)
            _subastadorRepository.CrearSubastador(nuevoSubastador);
            registrado = nuevoSubastador;
            return true;                 // se creó uno nuevo
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
