using Subastas_Final.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Subastas_Final.Repositories
{
    internal class PostorRepository
    {
        private static List<Postor> postores = new List<Postor>();

        private static int siguienteIdPostor = 0;

        public List<Postor> Postores { get => postores; }

        public PostorRepository()
        {
            //  usamos la lista estática existente
        }

        public void CrearPostor(Postor postor)
        {
            siguienteIdPostor++;         
            postor.IdPostor = siguienteIdPostor; 
            postores.Add(postor);
        }

        public List<Postor> ObtenerTodosPostores()
        {
            return postores;
        }

        public Postor ObtenerPostorPorId(int idPostor)
        {
            return postores.FirstOrDefault(p => p.IdPostor == idPostor);
        }

        public void EliminarPostor(int idPostor)
        {
            var postor = ObtenerPostorPorId(idPostor);
            if (postor != null)
            {
                postores.Remove(postor);
            }
        }

        public void ActualizarPostor(Postor postorActualizado)
        {
            var postor = ObtenerPostorPorId(postorActualizado.IdPostor);
            if (postor != null)
            {
                postor.Nombre = postorActualizado.Nombre;
                postor.Email = postorActualizado.Email;
            }
        }
    }
}
