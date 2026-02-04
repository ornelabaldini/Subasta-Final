using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subastas_Final.Entities;

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


