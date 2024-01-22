using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    class Premium:Producto
    {
        private double precioBaseB;

        public Premium(string descripcion, double precioA, double precioB) : base(descripcion, precioA)
        {
            precioBaseB = precioB;
        }

        public override double Precio(double kilo)
        {
            kilo= 70 * (precioBaseA * 0.85 + precioBaseB * 0.15) * 1.8;
            return kilo;
        }

        public override string Descripcion()
        {
            return descripcion + " "+precioBaseB.ToString();
        }
    }
}
