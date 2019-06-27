using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class TelefonoCliente
    {
        public int Codigo_Telefono { get; set; }
        public string Numero { get; set; }
        public string Descripcion { get; set; }
        public string Nit { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
