using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class Proveedor
    {
        public int Codigo_Proveedor { get; set; }
        public string Nit { get; set; }
        public string Razon_Social { get; set; }
        public string Direccion { get; set; }
        public string Pagina_Web { get; set; }
        public string Contacto_Principal { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<EmailProveedor> EmailProveedores { get; set; }
        public virtual ICollection<TelefonoProveedor> TelefonoProveedores { get; set; }
    }
}
