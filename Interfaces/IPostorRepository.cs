using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
