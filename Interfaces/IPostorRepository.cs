using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Interfaces
{
    internal interface IPostorRepository
    {
        void CrearPostor(Entities.Postor postor);
        List<Entities.Postor> ObtenerTodosPostores();
        Entities.Postor ObtenerPostorPorId(int idPostor);
        void EliminarPostor(int idPostor);
        void ActualizarPostor(Entities.Postor postorActualizado);
    }
}
