using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Interfaces
{
    internal interface ISubastaRepository
    {
            void CrearSubasta(Entities.Subasta subasta);
            List<Entities.Subasta> ObtenerTodasSubastas();
            Entities.Subasta ObtenerSubastaPorId(int idSubasta);
            void EliminarSubasta(int idSubasta);
            void ActualizarSubasta(Entities.Subasta subastaActualizada);
        
    }
}
