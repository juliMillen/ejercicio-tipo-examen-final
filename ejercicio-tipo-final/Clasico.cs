using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    class Clasico:Producto
    {
        public Clasico(string descripcion, double precioA) : base(descripcion, precioA)
        {

        }

        public override double Precio(double kilo)
        {
            kilo = 50 + (precioBaseA * 1.4);
            return kilo;
        }

        public override string Descripcion()
        {
            return descripcion + " " + precioBaseA;
        }
    }
}
