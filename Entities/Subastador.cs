using System.Collections.Generic;


namespace Subastas_Final.Entities
{
    public class Subastador
    {
        private int idSubastador;
        private string nombre;
        private string email;

        public int IdSubastador { get => idSubastador; set => idSubastador = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Email { get => email; set => email = value; }

        public Subastador()
        {
            
        }

       
    }
}
