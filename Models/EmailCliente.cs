using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class EmailCliente
    {
        public int Codigo_Email { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
