using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeVentas
{
    class Ventas
    {
        private string producto;
        private int cantidad;

        public void setProducto(string producto)
        {
            this.producto = producto;
        }
        public string getProducto() 
        {
            return this.producto; 
        }
        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }
        public int getCantidad() 
        { 
            return this.cantidad; 
        }
        // asignación de precios de los productos
        public double asignarPrecio()
        {
            switch (producto)
            {
                case "Teclado":
                    return 35;
                case "Impresora":
                    return 350;
                case "Monitor":
                    return 550;
                case "Mouse":
                    return 20;                
            }
            return 0;
        }

        // calcular subtotal
        public double calcularSubTotal()
        {
            return asignarPrecio() * cantidad;
        }

        // calcular descuento
        public double calcularDescuento()
        {
            double subTotal = calcularSubTotal();
            if(subTotal <= 300)
            {
                return 5.0 / 100 * subTotal; // descuento del 5 %
            }
            else if(subTotal > 300 && subTotal <= 500)
            {
                return 10.0/100 * subTotal; // descuento del 10 %
            }
            else
            {
                return 12.5 / 100 * subTotal;
            }
        }

        // calcular total
        public double calcularTotal()
        {
            return calcularSubTotal() - calcularDescuento();
        }
	}
}
