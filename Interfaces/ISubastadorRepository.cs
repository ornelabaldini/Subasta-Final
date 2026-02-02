using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Interfaces
{
    internal interface ISubastadorRepository
    {
        void CrearSubastador(Entities.Subastador subastador);
        List<Entities.Subastador> ObtenerTodosSubastadores();
        Entities.Subastador ObtenerSubastadorPorId(int idSubastador);
        void EliminarSubastador(int idSubastador);
        void ActualizarSubastador(Entities.Subastador subastadorActualizado);
    }
}


