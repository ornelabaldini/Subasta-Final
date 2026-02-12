using Subastas_Final.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Subastas_Final.Repositories
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();
        private static int ultimoId = 1;

        public Usuario Agregar(Usuario u)
        {
            u.IdUsuario = ultimoId++;
            usuarios.Add(u);
            return u;
        }

        public Usuario ObtenerPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email == email);
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }
    }
}
