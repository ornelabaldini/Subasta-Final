using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_Final.Entities
{
    public class Puja
    {
        private Postor postor;
        private Subasta subasta;
        private double monto;
        private DateTime fecha;


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
            return $"Puja Monto: {monto}, Fecha: {fecha}, Postor: {postor}, Subasta: {subasta}";
        }
    }
}
