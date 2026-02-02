using Subastas_Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Repositories
{
    internal class PostorRepository
    {  
        readonly List<Postor> postores;
        private int siguienteIdPostor = 1;
        public List<Postor> Postores { get => postores; }
        public int SiguienteIdPostor { get => siguienteIdPostor++; }
        public PostorRepository()
        {
            postores = new List<Postor>();
        }
        public void CrearPostor(Postor postor)
        {
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
