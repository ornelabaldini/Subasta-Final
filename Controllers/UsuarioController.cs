using Subastas_Final.Entities;
using Subastas_Final.Services;

namespace Subastas_Final.Controllers
{
    public class UsuarioController
    {
        private UsuarioService service = new UsuarioService();

        public Usuario Login(string nombre, string email)
        {
            return service.RegistrarOObtener(nombre, email);
        }

        public void ConvertirEnPostor(Usuario u)
        {
            service.CrearPostor(u);
        }

        public void ConvertirEnSubastador(Usuario u)
        {
            service.CrearSubastador(u);
        }
    }
}
