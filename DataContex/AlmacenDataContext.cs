using AppAlmacenPF2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlmacenPF2.DataContex
{
    public class AlmacenDataContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }//Pluraliza por defecto en inglés
        public DbSet<Producto> Productos { get; set; }

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
        }
    }
}
