using Subastas_Final.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Subastas_Final.Repositories
{
    internal class SubastadorRepository
    {
        private static List<Subastador> subastadores = new List<Subastador>();
        private static int siguienteIdSubastador = 0;

        public List<Subastador> Subastadores { get => subastadores; }

        public SubastadorRepository()
        {
            // lista estática existente

        }

        public void CrearSubastador(Subastador subastador)
        {

            siguienteIdSubastador++; 
            subastador.IdSubastador = siguienteIdSubastador; 
            subastadores.Add(subastador);
        }

        public List<Subastador> ObtenerTodosSubastadores()
        {
            return subastadores;
        }

        public Subastador ObtenerSubastadorPorId(int idSubastador)
        {
            return subastadores.FirstOrDefault(s => s.IdSubastador == idSubastador);
        }

        public void ActualizarSubastador(Subastador subastadorActualizado)
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
     
    }
}
