using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    abstract class Producto
    {
        protected string descripcion;
        protected double precioBaseA;
        private double cantidadKilos;

        public double CantidadKilos
        {
            get { return cantidadKilos; }
            set { cantidadKilos = value; }
        }

        public Producto(string desc, double precioBaseA)
        {
            descripcion = desc;
            this.precioBaseA = precioBaseA;
        }
        public abstract double Precio(double kilo);
        public abstract string Descripcion();
    }
}
