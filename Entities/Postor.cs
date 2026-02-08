using System.Collections.Generic;

namespace Subastas_Final.Entities
{
    public class Postor
    {
        private int idPostor;
        private string nombre;
        private string email;
        private List<Puja> pujas;

        public int IdPostor { get => idPostor; set => idPostor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public List<Puja> Pujas { get => pujas; set => pujas = value; }

        public Postor()
        {
            pujas = new List<Puja>();
        }

        public override string ToString()
        {
            return $"Postor ID: {idPostor}, Nombre: {nombre}, Email: {email}";
        }
    }
}
