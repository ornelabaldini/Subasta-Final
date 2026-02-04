using Subastas_Final.Entities;
using System.Collections.Generic;

namespace Subastas_Final.Repositories
{
    internal interface IPujaRepository
    {
        void CrearPuja(Puja puja);

        List<Puja> ObtenerTodasPujas();

        Puja ObtenerPujaPorId(int idPuja);

        void ActualizarPuja(Puja pujaActualizada);

        void EliminarPuja(int idPuja);
    }
}
