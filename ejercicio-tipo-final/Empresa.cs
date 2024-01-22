using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    class Empresa
    {
        private long cuit;
        private string razonSocial;
        private string direccion;

        public long Cuit
        {
            get { return cuit; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Empresa(long cuit, string razonSocial)
        {
            this.cuit = cuit;
            this.razonSocial = razonSocial;
        }

        public override string ToString()
        {
            return cuit + razonSocial + direccion;
        }
    }
}
