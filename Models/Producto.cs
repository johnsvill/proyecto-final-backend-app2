using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.Models
{
    public class Producto
    {
        public int Codigo_Producto { get; set; }
        public int Codigo_Categoria { get; set; }
        public int Codigo_Empaque { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio_Unitario { get; set; }
        public Decimal Precio_por_Docena { get; set; }
        public Decimal Precio_por_Mayor { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }
        public virtual Categoria Categoria { get; set; }//Relación muchos a uno
        public virtual ICollection<Inventario> Inventarios { get; set; }//Relación uno a muchos
        public virtual ICollection<TipoEmpaque> TipoEmpaques { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
