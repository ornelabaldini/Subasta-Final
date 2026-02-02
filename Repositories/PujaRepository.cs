using Subastas_Final.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Subastas_Final.Repositories
{
    internal class PujaRepository : IPujaRepository
    {
        private static List<Puja> pujas = new List<Puja>();
        private static int siguienteIdPuja = 1;

        public void CrearPuja(Puja puja)
        {
            puja.IdPuja = siguienteIdPuja++;  // asigna ID automáticamente
            pujas.Add(puja);
        }

        public List<Puja> ObtenerTodasPujas()
        {
            return pujas;
        }

        public Puja ObtenerPujaPorId(int idPuja)
        {
            return pujas.FirstOrDefault(p => p.IdPuja == idPuja);
        }

        public void ActualizarPuja(Puja pujaActualizada)
        {
            var puja = ObtenerPujaPorId(pujaActualizada.IdPuja);
            if (puja != null)
            {
                puja.Postor = pujaActualizada.Postor;
                puja.Subasta = pujaActualizada.Subasta;
                puja.Monto = pujaActualizada.Monto;
                puja.Fecha = pujaActualizada.Fecha;
            }
        }

        public void EliminarPuja(int idPuja)
        {
            var puja = ObtenerPujaPorId(idPuja);
            if (puja != null)
            {
                pujas.Remove(puja);
            }
        }
    }
}
