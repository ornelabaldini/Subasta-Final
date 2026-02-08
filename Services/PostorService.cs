using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System.Collections.Generic;


namespace Subastas_Final.Services
{
    internal class PostorService
    {
        readonly PostorRepository _postorRepository;

        public PostorService()
        {
            _postorRepository = new PostorRepository();
        }

        public bool CrearPostor(Postor nuevoPostor)
        {
            nuevoPostor.IdPostor = _postorRepository.SiguienteIdPostor;
            _postorRepository.CrearPostor(nuevoPostor);
            return true;
        }

        public List<Postor> ObtenerTodosPostores()
        {
            return _postorRepository.ObtenerTodosPostores();
        }

        public Postor ObtenerPostorPorId(int idPostor)
        {
            return _postorRepository.ObtenerPostorPorId(idPostor);
        }

        public bool ActualizarPostor(Postor postorActualizado)
        {
            var postor = _postorRepository.ObtenerPostorPorId(postorActualizado.IdPostor);
            if (postor == null)
            {
                return false;
            }
            _postorRepository.ActualizarPostor(postorActualizado);
            return true;
        }

        public bool EliminarPostor(int idPostor)
        {
            var postor = _postorRepository.ObtenerPostorPorId(idPostor);
            if (postor == null)
            {
                return false;
            }
            _postorRepository.EliminarPostor(idPostor);
            return true;
        }

        public Postor ObtenerOCrear(Postor datos)
        {
            var existente = _postorRepository.ObtenerPostorPorId(datos.IdPostor);

            if (existente != null)
                return existente;

            _postorRepository.CrearPostor(datos);
            return datos;
        }

    }
}
