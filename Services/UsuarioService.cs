using Subastas_Final.Entities;
using Subastas_Final.Repositories;

namespace Subastas_Final.Services
{
    public class UsuarioService
    {
        private UsuarioRepository repo = new UsuarioRepository();

        public Usuario RegistrarOObtener(string nombre, string email)
        {
            var usuario = repo.ObtenerPorEmail(email);
            if (usuario != null)
                return usuario;

            return repo.Agregar(new Usuario
            {
                Nombre = nombre,
                Email = email
            });
        }

        public Postor CrearPostor(Usuario u)
{
    if (u.Postor == null)
        u.Postor = new Postor
        {
            IdPostor = u.IdUsuario,
            Nombre = u.Nombre,
            Email = u.Email
        };

    return u.Postor;
}

public Subastador CrearSubastador(Usuario u)
{
    if (u.Subastador == null)
        u.Subastador = new Subastador
        {
            IdSubastador = u.IdUsuario,
            Nombre = u.Nombre,
            Email = u.Email
        };

    return u.Subastador;
}
    }
}
