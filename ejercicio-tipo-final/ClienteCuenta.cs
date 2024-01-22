﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_tipo_final
{
    [Serializable]
    class ClienteCuenta:IComparable
    {
        List<Pedido> listaPedidos = new List<Pedido>();
        private string nombre;
        private long cuit;
        private double saldoCuenta;
        private double tope;

        private string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public long Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        public double SaldoCuenta
        {
            get { return saldoCuenta; }
            set
            {
                saldoCuenta = value;
            }
        }

        public double Tope
        {
            get { return tope; }
            set { tope = value; }
        }

        public ClienteCuenta(string nombre, long cuit, double topeCuenta)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            tope = topeCuenta;
            saldoCuenta = 0;
        }

        public double AgregarPedido(Pedido nuevoPedido)
        {
            listaPedidos.Add(nuevoPedido);
            if (listaPedidos.Count > 0)
            {
                saldoCuenta++;
            }
            return saldoCuenta;
        }

        public bool AgregarPago(double monto)
        {
            bool puedePagar = false;
            if (monto<tope)
            {
                puedePagar = true;
                saldoCuenta -= monto;
            }
            return puedePagar;
        }

        public int CompareTo(Object obj)
        {
            return this.Cuit.CompareTo(((ClienteCuenta)obj).Cuit);
        }
    }
}
