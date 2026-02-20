
using System.Collections.Generic;
using Subastas_Final.Entities;

namespace Subastas_Final.Interfaces
{
    internal interface IPostorRepository
    {
        void CrearPostor(Postor postor);

        List<Postor> ObtenerTodosPostores();

        Postor ObtenerPostorPorId(int idPostor);

        void EliminarPostor(int idPostor);

        void ActualizarPostor(Postor postorActualizado);
    }
}
