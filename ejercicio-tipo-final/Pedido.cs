using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    class Pedido
    {
        private double valor;
        private int nro;
        private DateTime fechaHora;
        private string detalle;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public int Nro
        {
            get { return nro; }
            set { nro = value; }
        }

        public DateTime FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        public Pedido(int nro, List<Producto> lista)
        {
            this.nro = nro;
        }

        public string VerResumen()
        {
            return Nro + " " + Detalle + " " + FechaHora + " " + Valor;
        }
    }
}
