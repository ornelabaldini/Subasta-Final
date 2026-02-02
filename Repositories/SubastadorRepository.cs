using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Repositories
{
    internal class SubastadorRepository
    {
        readonly List<Entities.Subastador> subastadores;
        private static int nextId = 1;

        public List<Entities.Subastador> Subastadores { get => subastadores; }
        public int SiguienteIdSubastador { get => nextId++; }

        public SubastadorRepository()
        {
            subastadores = new List<Entities.Subastador>();

        }
        public void CrearSubastador(Entities.Subastador subastador)
        {
            subastadores.Add(subastador);
        }
        public List<Entities.Subastador> ObtenerTodosSubastadores()
        {
            return subastadores;
        }
        public Entities.Subastador ObtenerSubastadorPorId(int idSubastador)
        {
            return subastadores.FirstOrDefault(s => s.IdSubastador == idSubastador);
        }
        public void ActualizarSubastador(Entities.Subastador subastadorActualizado)
        {
            var subastador = ObtenerSubastadorPorId(subastadorActualizado.IdSubastador);
            if (subastador != null)
            {
                subastador.Nombre = subastadorActualizado.Nombre;
                subastador.Email = subastadorActualizado.Email;
            }
        }
        public void EliminarSubastador(int idSubastador)
        {
            var subastador = ObtenerSubastadorPorId(idSubastador);
            if (subastador != null)
            {
                subastadores.Remove(subastador);
            }
        }
        // public void AsignarArticuloASubastador(Entities.Subastador subastador, Entities.Articulo articulo)
        // {
        //    subastador.Articulos.Add(articulo);
        // }
    }
}
