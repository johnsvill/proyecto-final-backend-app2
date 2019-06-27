using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class DetalleCompra
    {
        public int ID_Detalle { get; set; }
        public int ID_Compra { get; set; }
        public int Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public virtual Producto Producto { get; set; }//Relación muchos a uno
        public virtual Compra Compra { get; set; }
    }
}
