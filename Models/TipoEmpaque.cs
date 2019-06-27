using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class TipoEmpaque
    {
        public int Codigo_Empaque { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }//Relación muchos a uno
    }
}
