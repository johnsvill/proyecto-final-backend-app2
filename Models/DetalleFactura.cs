using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class DetalleFactura
    {
        public int Codigo_Detalle { get; set; }
        public int Numero_Factura { get; set; }
        public int Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
