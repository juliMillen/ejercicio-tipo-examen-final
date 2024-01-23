using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ejercicio_tipo_final
{
    [Serializable]
    class GestionVentas
    {
        private Empresa dueño;
        public List<Producto> lista = new List<Producto>();
        public ArrayList listaClientes = new ArrayList();
        private double montoFacturado;
        private DateTime inicioOperaciones = new DateTime();
        private int nroPedido;

        public int NroPedido
        {
            get { return nroPedido; }
            set { nroPedido = value; }
        }

        public GestionVentas(long cuit, string razonSocial)
        {
            dueño = new Empresa(cuit, razonSocial);
            montoFacturado = 0;
            inicioOperaciones = DateTime.Now;
        }

        public void AgregarCliente(ClienteCuenta unCliente)
        {
            listaClientes.Add(unCliente);
        }

        public ClienteCuenta BuscarCliente(long cuit)
        {
            ClienteCuenta miCliente = new ClienteCuenta("", cuit, 00);
            listaClientes.Sort();
            int orden = listaClientes.BinarySearch(miCliente);
            if (orden >= 0)
            {
                miCliente = (ClienteCuenta)listaClientes[orden];
            }
            else
            {
                throw new Exception("Cliente no encontrado!");
            }
            return miCliente;
        }

        public Pedido GenerarPedido(int nro, List<Pedido> lista)
        {

        }

        public bool SumarPedido(ClienteCuenta cliente, Pedido nuevoPedido)
        {

        }

        public bool AgregarPago(long cuit, double monto)
        {
            ClienteCuenta buscado = BuscarCliente(cuit);
            bool existe = false;
            if(buscado != null)
            {
                existe = true;
                buscado.AgregarPago(monto);
            }
            return existe;
        }

        public double VerSaldo(long cuit)
        {
            ClienteCuenta clienteBuscado = BuscarCliente(cuit);
            double saldo = 0;
            if(clienteBuscado != null)
            {
                saldo= clienteBuscado.SaldoCuenta;
            }
            return saldo;
        }
    }
}
