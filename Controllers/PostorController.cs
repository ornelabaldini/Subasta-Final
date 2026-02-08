using System.Collections.Generic;
using Subastas_Final.Entities;
using Subastas_Final.Services;

namespace Subastas_Final.Controllers
{
    internal class PostorController
    {
        readonly PostorService _postorService;
        public PostorController()
        {
            _postorService = new PostorService();
        }
        public bool CrearPostor(Postor nuevoPostor)
        {
            return _postorService.CrearPostor(nuevoPostor);
        }
        public List<Postor> ObtenerTodosPostores()
        {
            return _postorService.ObtenerTodosPostores();
        }
        public Postor ObtenerPostorPorId(int idPostor)
        {
            return _postorService.ObtenerPostorPorId(idPostor);
        }
        public bool ActualizarPostor(Postor postorActualizado)
        {
            return _postorService.ActualizarPostor(postorActualizado);
        }
        public bool EliminarPostor(int idPostor)
        {
            return _postorService.EliminarPostor(idPostor);
        }

        public Postor ObtenerOCrear(Postor datos)
        {
            return _postorService.ObtenerOCrear(datos);
        }
    }
}
