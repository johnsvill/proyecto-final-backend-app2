using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class Inventario
    {
        public int Codigo_Inventario { get; set; }
        public int Codigo_Producto { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo_Registro { get; set; }
        public decimal Precio { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public virtual Producto Producto { get; set; }//Relación muchos a uno
    }
}
