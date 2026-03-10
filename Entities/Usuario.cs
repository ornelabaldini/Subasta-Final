using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Entities
{
    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string email;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public string Email { get => email; set => email = value; }

        public Usuario()
        {

        }


    }
}

