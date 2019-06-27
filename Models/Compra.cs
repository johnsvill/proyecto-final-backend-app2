using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class Compra
    {
        public int ID_Compra { get; set; }
        public int Numero_Documento { get; set; }
        public int Codigo_Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }//Relación uno a muchos
        public virtual Proveedor Proveedor { get; set; }
    }
}
