using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subastas_Final.Entities;

namespace Subastas_Final.Controllers
{
    internal class PostorController
    {
        readonly Services.PostorService _postorService;
        public PostorController()
        {
            _postorService = new Services.PostorService();
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
    }
}
