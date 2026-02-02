using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Controllers
{
    internal class PostorController
    {
        readonly Services.PostorService _postorService;
        public PostorController()
        {
            _postorService = new Services.PostorService();
        }
        public bool CrearPostor(Entities.Postor nuevoPostor)
        {
            return _postorService.CrearPostor(nuevoPostor);
        }
        public List<Entities.Postor> ObtenerTodosPostores()
        {
            return _postorService.ObtenerTodosPostores();
        }
        public Entities.Postor ObtenerPostorPorId(int idPostor)
        {
            return _postorService.ObtenerPostorPorId(idPostor);
        }
        public bool ActualizarPostor(Entities.Postor postorActualizado)
        {
            return _postorService.ActualizarPostor(postorActualizado);
        }
        public bool EliminarPostor(int idPostor)
        {
            return _postorService.EliminarPostor(idPostor);
        }
    }
}
