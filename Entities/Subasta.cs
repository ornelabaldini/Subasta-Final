using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Entities
{
    public class Subasta
    {
        private int idSubasta;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private decimal precioBase;
        private Subastador subastador;
        private bool estado;
        private int idGanador;
        private decimal montoActual;
        private List<Postor> postores;
        private Articulo articulo;
        private Puja puja;

        public List<Postor> Postores { get => postores; set => postores = value; }
        public decimal MontoActual { get => montoActual; set => montoActual = value; }
        public int IdGanador { get => idGanador; set => idGanador = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int IdSubasta { get => idSubasta; set => idSubasta = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public decimal PrecioBase { get => precioBase; set => precioBase = value; }
        public Subastador Subastador { get => subastador; set => subastador = value; }
        public Articulo Articulo { get => articulo; set => articulo = value; }
        public Puja Puja { get => puja; set => puja = value; }

        public Subasta()
        {
            postores = new List<Postor>();
            articulo = new Articulo();
            subastador = new Subastador();
            puja = new Puja();

        }

        public override string ToString()
        {
            return $"Subasta ID: {idSubasta}, Fecha Inicio: {fechaInicio}, Fecha Fin: {fechaFin},Puja: {puja} Precio Base: {precioBase}, Estado: {estado}, Monto Actual: {montoActual}";
        }
    }
}
