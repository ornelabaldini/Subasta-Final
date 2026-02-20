
using System.Collections.Generic;
using Subastas_Final.Entities;

namespace Subastas_Final.Interfaces
{
    internal interface ISubastaRepository
    {
            void CrearSubasta(Subasta subasta);
            List<Subasta> ObtenerTodasSubastas();

            Subasta ObtenerSubastaPorId(int idSubasta);

            void EliminarSubasta(int idSubasta);

            void ActualizarSubasta(Subasta subastaActualizada);
        
    }
}
