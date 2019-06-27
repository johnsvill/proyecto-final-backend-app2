using AppAlmacenPF2.DataContex;
using AppAlmacenPF2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppAlmacenPF2.ModelViews
{
    public class ProductoModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la Base de Datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoCategoria = true;
        private bool _IsReadOnlyCodigoEmpaque = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyPrecioUnitario = true;
        private bool _IsReadOnlyPrecioPorDocena = true;
        private bool _IsReadOnlyPrecioPorMayor = true;
        private bool _IsReadOnlyExistencia = true;
        private bool _IsReadOnlyImagen = true;
        private string _CodigoCategoria;
        private string _CodigoEmpaque;
        private string _Descripcion;
        private string _PrecioUnitario;
        private string _PrecioPorDocena;
        private string _PrecioPorMayor;
        private string _Existencia;
        private string _Imagen;

        public string CodigoCategoria
        {
            get
            {
                return this._CodigoCategoria;
            }
            set
            {
                this._CodigoCategoria = value;
                ChangeNotify("CodigoCategoria");
            }
        }
        public string CodigoEmpaque
        {
            get
            {
                return this._CodigoEmpaque;
            }
            set
            {
                this._CodigoEmpaque = value;
                ChangeNotify("CodigoEmpaque");
            }
        }
        public string Descripcion
        {
            get
            {
                return this._Descripcion;
            }
            set
            {
                this._Descripcion = value;
                ChangeNotify("Descripcion");
            }
        }
        public string PrecioUnitario
        {
            get
            {
                return this._PrecioUnitario;
            }
            set
            {
                this._PrecioUnitario = value;
                ChangeNotify("PrecioUnitario");
            }
        }
        public string PrecioPorDocena
        {
            get
            {
                return this._PrecioPorDocena;
            }
            set
            {
                this._PrecioPorDocena = value;
                ChangeNotify("PrecioPorDocena");
            }
        }
        public string PrecioPorMayor
        {
            get
            {
                return this._PrecioPorMayor;
            }
            set
            {
                this._PrecioPorMayor = value;
                ChangeNotify("PrecioPorMayor");
            }
        }
        public string Existencia
        {
            get
            {
                return this._Existencia;
            }
            set
            {
                this._Existencia = value;
                ChangeNotify("Existencia");
            }
        }
        public string Imagen
        {
            get
            {
                return this._Imagen;
            }
            set
            {
                this._Imagen = value;
                ChangeNotify("Imagen");
            }
        }
        private ProductoModelView _Instancia;
        private ObservableCollection<Producto> _Producto;
        public ProductoModelView Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
            }
        }
        public Boolean IsReadOnlyCodigoCategoria
        {
            get
            {
                return this._IsReadOnlyCodigoCategoria;
            }
            set
            {
                this._IsReadOnlyCodigoCategoria = value;
                ChangeNotify("IsReadOnlyCodigoCategoria");
            }
        }
        public Boolean IsReadOnlyCodigoEmpaque
        {
            get
            {
                return this._IsReadOnlyCodigoEmpaque;
            }
            set
            {
                this._IsReadOnlyCodigoEmpaque = value;
                ChangeNotify("IsReadOnlyCodigoEmpaque");
            }
        }
        public Boolean IsReadOnlyDescripcion
        {
            get
            {
                return this._IsReadOnlyDescripcion;
            }
            set
            {
                this._IsReadOnlyDescripcion = value;
                ChangeNotify("IsReadOnlyDescripcion");
            }
        }
        public Boolean IsReadOnlyPrecioUnitario
        {
            get
            {
                return this._IsReadOnlyPrecioUnitario;
            }
            set
            {
                this._IsReadOnlyPrecioUnitario = value;
                ChangeNotify("IsReadOnlyPrecioUnitario");
            }
        }
        public Boolean IsReadOnlyPrecioPorDocena
        {
            get
            {
                return this._IsReadOnlyPrecioPorDocena;
            }
            set
            {
                this._IsReadOnlyPrecioPorDocena = value;
                ChangeNotify("IsReadOnlyPrecioPorDocena");
            }
        }
        public Boolean IsReadOnlyPrecioPorMayor
        {
            get
            {
                return this._IsReadOnlyPrecioPorMayor;
            }
            set
            {
                this._IsReadOnlyPrecioPorMayor = value;
                ChangeNotify("IsReadOnlyPrecioPorMayor");
            }
        }
        public Boolean IsReadOnlyExistencia
        {
            get
            {
                return this._IsReadOnlyExistencia;
            }
            set
            {
                this._IsReadOnlyExistencia = value;
                ChangeNotify("IsReadOnlyExistencia");
            }
        }
        public Boolean IsReadOnlyImagen
        {
            get
            {
                return this._IsReadOnlyImagen;
            }
            set
            {
                this._IsReadOnlyImagen = value;
                ChangeNotify("IsReadOnlyImagen");
            }
        }

        public ObservableCollection<Producto> Productos
        {
            get
            {
                if (this._Producto == null)
                {
                    this._Producto = new ObservableCollection<Producto>();
                    foreach (Producto elemento in db.Productos.ToList())
                    {
                        this._Producto.Add(elemento);
                    }
                }
                return this._Producto;
            }
            set { this._Producto = value; }
        }
        public ProductoModelView()
        {
            this.Instancia = this;//Se hace referencia a la instancia que se creo
            this.Titulo = "Lista de Productos:";//Se inicializa el nombre del título
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public string Titulo { get; set; }
        public object Proveedores { get; internal set; }

        //INTERFAZ ICommand
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeNotify(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this._IsReadOnlyCodigoCategoria = false;
                this._IsReadOnlyCodigoEmpaque = false;
                this._IsReadOnlyDescripcion = false;
                this._IsReadOnlyExistencia = false;
                this._IsReadOnlyImagen = false;
                this._IsReadOnlyPrecioPorDocena = false;
                this._IsReadOnlyPrecioPorMayor = false;
                this._IsReadOnlyPrecioUnitario = false;
            }
            if (parameter.Equals("Save"))
            {
                Producto nuevo = new Producto();
                nuevo.Codigo_Categoria = Convert.ToInt16(this.CodigoCategoria);
                nuevo.Codigo_Empaque = Convert.ToInt16(this.CodigoEmpaque);
                nuevo.Descripcion = this.Descripcion;
                nuevo.Precio_Unitario = Convert.ToDecimal(this.PrecioUnitario);
                nuevo.Precio_por_Docena = Convert.ToDecimal(this.PrecioPorDocena);
                nuevo.Precio_por_Mayor = Convert.ToDecimal(this.PrecioPorMayor);
                nuevo.Existencia = Convert.ToInt16(this.Existencia);
                nuevo.Imagen = this.Imagen;
                db.Productos.Add(nuevo);
                db.SaveChanges();
                this.Productos.Add(nuevo);
                MessageBox.Show("Registro Almacenado");
                /*throw new NotImplementedException();*/
            }
        }
    }
}
