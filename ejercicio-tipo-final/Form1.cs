using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ejercicio_tipo_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GestionVentas nuevaG;
        private void btnResumen_Click(object sender, EventArgs e)
        {
           
                // Supongamos que tienes información del pedido, cliente y productos disponibles
                int numeroPedido = 1; // Reemplaza con el número de pedido real
                DateTime fechaPedido = DateTime.Now; // Reemplaza con la fecha real del pedido
                ClienteCuenta cliente = nuevaG.BuscarCliente(0243876639); // Reemplaza con el CUIT del cliente real
                List<Producto> productos = nuevaG.lista; // Reemplaza con la lista real de productos del pedido

                // Crear una nueva instancia de la ventana de resumen
                FResumen nuevoResumen = new FResumen();

                // Llenar la información en la ventana de resumen
                nuevoResumen.lBresumen.Items.Add("Pedido Nº: " + numeroPedido.ToString("D4"));
                nuevoResumen.lBresumen.Items.Add("Fecha del pedido: " + fechaPedido.ToString("dd/MM/yyyy HH:mm"));
                nuevoResumen.lBresumen.Items.Add("Cliente: " + cliente.Nombre);
                nuevoResumen.lBresumen.Items.Add("Cuit: " + cliente.Cuit.ToString("D11"));

                // Agregar información de productos al resumen
                foreach (Producto producto in productos)
                {
                    string descripcion = producto.Descripcion();
                    double peso = producto.CantidadKilos;
                    double precioUnitario = producto.Precio(1); // Precio por kilo, puedes ajustar según tus necesidades
                    double precioTotal = producto.Precio(peso);

                    nuevoResumen.lBresumen.Items.Add($"{descripcion} {peso:F2} kg {precioUnitario:C2} {precioTotal:C2}");
                }

                // Calcular y agregar el total al resumen
                double total = productos.Sum(producto => producto.Precio(producto.CantidadKilos));
                nuevoResumen.lBresumen.Items.Add("Total: " + total.ToString("C2"));

                // Mostrar la ventana de resumen
                nuevoResumen.ShowDialog();
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream archivo = new FileStream("miArchivo.csv", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            nuevaG = (GestionVentas)formatter.Deserialize(archivo);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            nuevaG = new GestionVentas(098674726, "Boulevar SA");
            Producto p1Pre = new Premium("Cerveza pura malta", 53.3, 55.5);
            Producto p2Pre = new Premium("Cerveza negra", 50.5, 52.4);
            Producto p1Cla = new Clasico("Manies saborizados", 4.3);
            Producto p2Cla = new Clasico("Papas saladas", 3.3);
            ClienteCuenta c1 = new ClienteCuenta("Francisco Rodriguez", 0243876639, 15000);
            nuevaG.AgregarCliente(c1);
            ClienteCuenta c2 = new ClienteCuenta("Julian Millen", 24425766627, 30000);
            nuevaG.AgregarCliente(c2);
            ClienteCuenta c3 = new ClienteCuenta("Ricardo Kaka", 334857291, 70000);
            nuevaG.AgregarCliente(c3);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = "miArchivo.csv";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream archivo = new FileStream(openFileDialog1.FileName, FileMode.CreateNew, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(archivo, nuevaG);
        }

        public void Leer()
        {
            try
            {
                if(openFileDialog1.ShowDialog()== DialogResult.OK)
                {
                    FileStream nuevoArchivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sR = new StreamReader(nuevoArchivo);
                    string linea;
                    string[] datos;

                    while (!sR.EndOfStream)
                    {
                        linea = sR.ReadLine();
                        datos = linea.Split(',');
                        if (datos.Length == 4)
                        {
                            string desc = datos[0];
                            double precioA = Convert.ToDouble(datos[1]);
                            double precioB = Convert.ToDouble(datos[2]);
                            char tipo = char.ToUpperInvariant(datos[3].Trim()[0]);
                            Producto prod = null;

                            if(tipo == 'P')
                            {
                                prod = new Premium(desc, precioA, precioB);
                            }
                            else if(tipo=='C')
                            {
                                prod = new Clasico(desc, precioA);
                            }
                            else
                            {
                                throw new Exception("Tipo no valido");
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error de formato");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error en el archivo" + ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
