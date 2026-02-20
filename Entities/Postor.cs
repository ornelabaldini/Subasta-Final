

namespace Subastas_Final.Entities
{
    public class Postor
    {
        private int idPostor;
        private string nombre;
        private string email;

        public int IdPostor { get => idPostor; set => idPostor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
       

        public Postor()
        {
          
        }

    }
}
