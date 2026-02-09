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

        public bool CrearPostor(Postor nuevoPostor, out Postor registrado)
        {
            // Verificar si ya existe por email
            var existente = _postorRepository.ObtenerTodosPostores()
                .Find(p => p.Email.ToLower() == nuevoPostor.Email.ToLower());

            if (existente != null)
            {
                registrado = existente; // devolvemos el existente
                return false;            // no se creó uno nuevo
            }

            // Guardar usando el repositorio (que asigna el ID)
            _postorRepository.CrearPostor(nuevoPostor);
            registrado = nuevoPostor;
            return true;                 // se creó uno nuevo
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


    }
}
