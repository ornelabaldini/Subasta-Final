using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subastas_Final.Entities;


namespace Subastas_Final.Entities
{
    public class Postor
    {
            private int idPostor;
            private string nombre;
            private string email;
            private List<Subasta> subastas;

            public int IdPostor { get => idPostor; set => idPostor = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public string Email { get => email; set => email = value; }
            public List<Subasta> Subastas { get => subastas; set => subastas = value; } 


        public Postor()
            {
                subastas = new List<Subasta>();
            }

            public override string ToString()
            {
                return $"Postor ID: {idPostor}, Nombre: {nombre}, Email: {email}";
            }
            
        }
}
