using AppAlmacenPF2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;//Instalación de Entity Framework
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.DataContex//FLUENT API
{
    public class AlmacenDataContext : DbContext//Se enlaza el namespace con el Entity Framework
    {
        //Esta es la capa de acceso a datos
        public DbSet<Categoria> Categorias { get; set; }//Pluraliza por defecto en inglés
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoEmpaque> TipoEmpaques { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<EmailProveedor> EmailProveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TelefonoCliente> TelefonoClientes { get; set; }
        public DbSet<TelefonoProveedor> TelefonoProveedores { get; set; }
        public DbSet<EmailCliente> EmailClientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Para quitar pluralización
            //MAPEOS
            modelBuilder.Entity<Categoria>()//MAPEO Modelo del lado de C# 
                .ToTable("CATEGORIA")//Modelo del lado de SQL
                .HasKey(x => new { x.Codigo_Categoria });//Para enlazar la llave primaria
            modelBuilder.Entity<Categoria>()
                .Property(x => x.Descripcion)//Para definir un campo requerido
                .IsRequired();
            modelBuilder.Entity<Producto>()//MAPEO 
                .ToTable("PRODUCTO")
                .HasKey(z => new { z.Codigo_Producto });
            modelBuilder.Entity<Producto>()
                .Property(z => z.Codigo_Empaque)
                .IsRequired();
            modelBuilder.Entity<Producto>()
                .Property(z => z.Codigo_Categoria)
                .IsRequired();
            modelBuilder.Entity<Inventario>()//MAPEO 
               .ToTable("INVENTARIO")
               .HasKey(y => new { y.Codigo_Inventario });
            modelBuilder.Entity<Inventario>()
                .Property(y => y.Codigo_Producto)
                .IsRequired();
            modelBuilder.Entity<TipoEmpaque>()//MAPEO 
                .ToTable("TIPO_EMPAQUE")
                .HasKey(x => new { x.Codigo_Empaque });
            modelBuilder.Entity<TipoEmpaque>()
                .Property(x => x.Descripcion)
                .IsRequired();
            modelBuilder.Entity<Compra>()//MAPEO 
                .ToTable("COMPRA")
                .HasKey(y => new { y.ID_Compra });
            modelBuilder.Entity<Compra>()
                .Property(y => y.Codigo_Proveedor)
                .IsRequired();
            modelBuilder.Entity<DetalleCompra>()//MAPEO 
                .ToTable("DETALLE_COMPRA")
                .HasKey(z => new { z.ID_Detalle });
            modelBuilder.Entity<DetalleCompra>()
                .Property(z => z.ID_Compra)
                .IsRequired();
            modelBuilder.Entity<DetalleCompra>()
                .Property(z => z.Codigo_Producto)
                .IsRequired();
            modelBuilder.Entity<DetalleFactura>()//MAPEO 
                .ToTable("DETALLE_FACTURA")
                .HasKey(x => new { x.Codigo_Detalle });
            modelBuilder.Entity<DetalleFactura>()
                .Property(x => x.Codigo_Producto)
                .IsRequired();
            modelBuilder.Entity<DetalleFactura>()
                .Property(x => x.Numero_Factura);
            modelBuilder.Entity<EmailProveedor>()//MAPEO 
                .ToTable("EMAIL_PROVEEDOR")
                .HasKey(y => new { y.Codigo_Email });
            modelBuilder.Entity<EmailProveedor>()
                .Property(y => y.Email)
                .IsRequired();
            modelBuilder.Entity<Factura>()//MAPEO 
                .ToTable("FACTURA")
                .HasKey(z => new { z.Numero_Factura });
            modelBuilder.Entity<Factura>()
                .Property(z => z.Nit)
                .IsRequired();
            modelBuilder.Entity<Factura>()
                .Property(z => z.Total)
                .IsRequired();
            modelBuilder.Entity<Proveedor>()//MAPEO
                .ToTable("PROVEEDOR")
                .HasKey(x => new { x.Codigo_Proveedor });
            modelBuilder.Entity<Proveedor>()
                .Property(x => x.Nit)
                .IsRequired();
            modelBuilder.Entity<Cliente>()//MAPEO
                .ToTable("CLIENTE")
                .HasKey(y => new { y.Nit });
            modelBuilder.Entity<Cliente>()
                .Property(y => y.Nit)
                .IsRequired();
            modelBuilder.Entity<TelefonoProveedor>()//MAPEO
                .ToTable("TELEFONO_PROVEEDOR")
                .HasKey(z => new { z.Codigo_Telefono });
            modelBuilder.Entity<TelefonoProveedor>()
                .Property(z => z.Numero)
                .IsRequired();
            modelBuilder.Entity<EmailCliente>()//MAPEO
                .ToTable("EMAIL_CLIENTE")
                .HasKey(x => new { x.Codigo_Email });
            modelBuilder.Entity<EmailCliente>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<TelefonoCliente>()//MAPEO
                .ToTable("TELEFONO_CLIENTE")
                .HasKey(y => new { y.Codigo_Telefono });
            modelBuilder.Entity<TelefonoCliente>()
                .Property(y => y.Numero)
                .IsRequired();
            modelBuilder.Entity<TelefonoCliente>()
                .Property(y => y.Nit)
                .IsRequired();
        }
    }
}
