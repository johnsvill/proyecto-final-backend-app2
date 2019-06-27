using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class TelefonoProveedor
    {
        public int Codigo_Telefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public int Codigo_Proveedor { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
