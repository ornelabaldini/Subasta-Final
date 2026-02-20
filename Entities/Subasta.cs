using System;
using System.Collections.Generic;
using System.Linq;


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
        private List<Puja> pujas;
        private decimal pujaMinima;


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
        public List<Puja> Pujas { get => pujas; set => pujas = value; }
        public decimal PujaMinima { get => pujaMinima; set => pujaMinima = value; }

        public Subasta()
        {
            postores = new List<Postor>();
            articulo = new Articulo();
            subastador = new Subastador();
            pujas = new List<Puja>();

        }

    }
}
