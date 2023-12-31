using System;
using System.Collections;
using System.Windows.Forms;

namespace ControlDeVentas
{
    public partial class frmVentas : Form
    {
        // Inicializamos el arreglo de productos
        static string[] listadoProductos = { "Teclado", "Impresora", "Monitor", "Mouse" };

        // Objeto de la clase ArrayList
        ArrayList arrayProductos = new ArrayList(listadoProductos);

        // Objeto de la clase Venta
        Ventas ventas = new Ventas();

        // acumular totales
        double total;

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            MostrarFecha();
            MostrarHora();
            LimpiarCampos();
            lblTotal.Text = "$0.00";
            LlenarProducto();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // enviar datos a la clase ventas
            ventas.setProducto(cmbProducto.Text);            
            ventas.setCantidad(int.Parse(txtCantidad.Text));
            
            // mostrar resultados
            ListViewItem fila = new ListViewItem(ventas.getProducto());
            fila.SubItems.Add(ventas.getCantidad().ToString());
            fila.SubItems.Add(ventas.asignarPrecio().ToString("C"));
            fila.SubItems.Add(ventas.calcularSubTotal().ToString("C"));
            fila.SubItems.Add(ventas.calcularDescuento().ToString("C"));
            fila.SubItems.Add(ventas.calcularTotal().ToString("C"));            

            // agregamos a la listview la fila que hemos creado recién
            lvRegistrar.Items.Add(fila);

            // suma de productos
            total += ventas.calcularTotal();

            // imprimir totales
            lblTotal.Text = total.ToString("C");

            // limpiar campos
            LimpiarCampos();
        }
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ventas.setProducto(cmbProducto.Text);
            lblPrecio.Text = ventas.asignarPrecio().ToString("C");
        }
        private void MostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }
        private void LimpiarCampos()
        {
            txtCliente.Clear();
            cmbProducto.Text = "Seleccione un producto";
            txtCantidad.Clear();
            lblPrecio.Text = "0.00";
            txtCliente.Focus();
        }
        private void LlenarProducto()
        {
            foreach(var p in arrayProductos)
            {
                cmbProducto.Items.Add(p);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea salir?", "Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes) 
            {
                this.Close();
            }
            else
            {
                LimpiarCampos();
            }
        }

    }
}
