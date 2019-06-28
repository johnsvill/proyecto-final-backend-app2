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
    public class InventarioModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTipoRegistro = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyEntradas = true;
        private bool _IsReadOnlySalidas = true;
        private string _CodigoProducto;
        private string _Fecha;
        private string _TipoRegistro;
        private string _Precio;
        private string _Entradas;
        private string _Salidas;

        public string CodigoProducto
        {
            get
            {
                return this._CodigoProducto;
            }
            set
            {
                this._CodigoProducto = value;
                ChangeNotify("CodigoProducto");
            }
        }
        public string Fecha
        {
            get
            {
                return this._Fecha;
            }
            set
            {
                this._Fecha = value;
                ChangeNotify("Fecha");
            }
        }
        public string TipoRegistro
        {
            get
            {
                return this._TipoRegistro;
            }
            set
            {
                this._TipoRegistro = value;
                ChangeNotify("TipoRegistro");
            }
        }
        public string Precio
        {
            get
            {
                return this.Precio;
            }
            set
            {
                this.Precio = value;
                ChangeNotify("Precio");
            }
        }
        public string Entradas
        {
            get
            {
                return this._Entradas;
            }
            set
            {
                this._Entradas = value;
                ChangeNotify("Entradas");
            }
        }
        public string Salidas
        {
            get
            {
                return this._Salidas;
            }
            set
            {
                this._Salidas = value;
                ChangeNotify("Salidas");
            }
        }

        private ObservableCollection<Inventario> _Inventarios;

        public Boolean IsReadOnlyCodigoProducto
        {
            get
            {
                return this._IsReadOnlyCodigoProducto;
            }
            set
            {
                this._IsReadOnlyCodigoProducto = value;
                ChangeNotify("IsReadOnlyCodigoProducto");
            }
        }
        public Boolean IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                ChangeNotify("IsReadOnlyFecha");
            }
        }
        public Boolean IsReadOnlyTipoRegistro
        {
            get
            {
                return this._IsReadOnlyTipoRegistro;
            }
            set
            {
                this._IsReadOnlyTipoRegistro = value;
                ChangeNotify("IsReadOnlyTipoRegistro");
            }
        }
        public Boolean IsReadOnlyPrecio
        {
            get
            {
                return this._IsReadOnlyPrecio;
            }
            set
            {
                this._IsReadOnlyPrecio = value;
                ChangeNotify("IsReadOnlyPrecio");
            }
        }
        public Boolean IsReadOnlyEntradas
        {
            get
            {
                return this._IsReadOnlyEntradas;
            }
            set
            {
                this._IsReadOnlyEntradas = value;
                ChangeNotify("IsReadOnlyEntradas");
            }
        }
        public Boolean IsReadOnlySalidas
        {
            get
            {
                return this._IsReadOnlySalidas;
            }
            set
            {
                this._IsReadOnlySalidas = value;
                ChangeNotify("IsReadOnlySalidas");
            }
        }

        private InventarioModelView _Instancia;

        public InventarioModelView Instancia
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
        public ObservableCollection<Inventario> Inventarios//Propiedad
        {
            get
            {
                if (this.Inventarios == null)
                {
                    this.Inventarios = new ObservableCollection<Inventario>();
                    foreach (Inventario elemento in db.Inventarios.ToList())
                    {
                        this.Inventarios.Add(elemento);
                    }
                }
                return this._Inventarios;
            }
            set { this._Inventarios = value; }
        }
        public InventarioModelView()
        {
            this.Titulo = "Productos en inventario:";//Se inicializa el nombre del título
            this.Instancia = this;//Se hace referencia a la instancia que se creo
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        //Interfaz Icommand
        public void ChangeNotify(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
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
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTipoRegistro = false;
                this.IsReadOnlyPrecio = false;
                this.IsReadOnlyEntradas = false;
                this.IsReadOnlySalidas = false;
            }
            if (parameter.Equals("Save"))
            {
                Inventario nuevo = new Inventario();
                nuevo.Codigo_Producto = Convert.ToInt16(this.CodigoProducto);
                nuevo.Fecha = Convert.ToDateTime(this.Fecha);
                nuevo.Tipo_Registro = this.TipoRegistro;
                nuevo.Precio = Convert.ToDecimal(this.Precio);
                nuevo.Entradas = Convert.ToInt16(this.Entradas);
                nuevo.Salidas = Convert.ToInt16(this.Salidas);
                db.Inventarios.Add(nuevo);
                db.SaveChanges();
                this.Inventarios.Add(nuevo);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
