using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Entities
{
    public class Subastador
    {
        private int idSubastador;
        private string nombre;
        private string email;
        private List<Subasta> subastas;

        public int IdSubastador { get => idSubastador; set => idSubastador = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Email { get => email; set => email = value; }

        public List<Subasta> Subastas { get => subastas; set => subastas = value; }

        public Subastador()
        {
            subastas = new List<Subasta>();
        }

        public override string ToString()
        {
            return $"Subastador ID: {idSubastador}, Nombre: {nombre}, Email: {email}";
        }
    }
}
