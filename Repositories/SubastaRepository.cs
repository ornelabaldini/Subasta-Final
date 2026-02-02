using Subastas_Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Repositories
{
    internal class SubastaRepository
    {

        private static List<Subasta> subastas = new List<Subasta>();
        private static int siguienteIdSubasta = 1;

        public List<Subasta> Subastas { get => subastas; }
        public int SiguienteIdSubasta { get => siguienteIdSubasta++; }

        public SubastaRepository()
        {
            // No sobrescribir la lista estática
        }

        public void CrearSubasta(Subasta subasta)
        {
            subasta.IdSubasta = SiguienteIdSubasta;
            subastas.Add(subasta);
        }
        public List<Subasta> ObtenerTodasSubastas()
        {
            return subastas;
        }
        public Subasta ObtenerSubastaPorId(int idSubasta)
        {
            return subastas.FirstOrDefault(s => s.IdSubasta == idSubasta);
        }
        public void ActualizarSubasta(Subasta subastaActualizada)
        {
            var subasta = ObtenerSubastaPorId(subastaActualizada.IdSubasta);
            if (subasta != null)
            {
                subasta.FechaInicio = subastaActualizada.FechaInicio;
                subasta.FechaFin = subastaActualizada.FechaFin;
                subasta.PrecioBase = subastaActualizada.PrecioBase;
                subasta.Subastador = subastaActualizada.Subastador;
                subasta.Estado = subastaActualizada.Estado;
                subasta.IdGanador = subastaActualizada.IdGanador;
                subasta.MontoActual = subastaActualizada.MontoActual;
                subasta.Postores = subastaActualizada.Postores;
                subasta.Articulo = subastaActualizada.Articulo;
                subasta.Pujas = subastaActualizada.Pujas;
            }
        }
        public void EliminarSubasta(int idSubasta)
        {
            var subasta = ObtenerSubastaPorId(idSubasta);
            if (subasta != null)
            {
                subastas.Remove(subasta);
            }
        }
    }
}
