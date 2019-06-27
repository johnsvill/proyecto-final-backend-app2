using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class Factura
    {
        public int Numero_Factura { get; set; }
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
