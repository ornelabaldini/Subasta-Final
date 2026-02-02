using System;

namespace Subastas_Final.Entities
{
    public class Puja
    {
        private int idPuja;
        private Postor postor;
        private Subasta subasta;
        private double monto;
        private DateTime fecha;

        public int IdPuja { get => idPuja; set => idPuja = value; }  
        public double Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Postor Postor { get => postor; set => postor = value; }
        public Subasta Subasta { get => subasta; set => subasta = value; }

        public Puja(Postor postor, Subasta subasta, double monto, DateTime fecha)
        {
            this.postor = postor;
            this.subasta = subasta;
            this.monto = monto;
            this.fecha = fecha;
        }

        public Puja()
        {
        }

        public override string ToString()
        {
            return $"Puja Id: {idPuja}, Monto: {monto}, Fecha: {fecha}, Postor: {postor?.Nombre}, Subasta: {subasta?.IdSubasta}";
        }
    }
}
