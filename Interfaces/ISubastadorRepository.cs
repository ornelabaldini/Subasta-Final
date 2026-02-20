
using System.Collections.Generic;
using Subastas_Final.Entities;

// Para base de datos
namespace Subastas_Final.Interfaces
{
    internal interface ISubastadorRepository
    {
        void CrearSubastador(Subastador subastador);

        List<Subastador> ObtenerTodosSubastadores();

        Subastador ObtenerSubastadorPorId(int idSubastador);

        void EliminarSubastador(int idSubastador);

        void ActualizarSubastador(Subastador subastadorActualizado);
    }
}


