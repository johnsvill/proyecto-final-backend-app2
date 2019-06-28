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
    class DetalleCompraModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyIdCompra = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private string _IdCompra;
        private string _CodigoProducto;
        private string _Cantidad;
        private string _Precio;

        public string IdCompra
        {
            get
            {
                return this._IdCompra;
            }
            set
            {
                this._IdCompra = value;
                ChangeNotify("IdCompra");
            }
        }
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
        public string Cantidad
        {
            get
            {
                return this._Cantidad;
            }
            set
            {
                this._Cantidad = value;
                ChangeNotify("Cantidad");
            }
        }
        public string Precio
        {
            get
            {
                return this._Precio;
            }
            set
            {
                this._Precio = value;
                ChangeNotify("Precio");
            }
        }
        private DetalleCompraModelView _Instancia;
        public DetalleCompraModelView Instancia
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
        private ObservableCollection<DetalleCompra> _DetalleCompra;
        public Boolean IsReadOnlyIdCompra
        {
            get
            {
                return this._IsReadOnlyIdCompra;
            }
            set
            {
                this._IsReadOnlyIdCompra = value;
                ChangeNotify("IsReadOnlyIdCompra");
            }
        }
        public Boolean IsReadOnlyCodigoProducto
        {
            get
            {
                return this._IsReadOnlyCodigoProducto;
            }
            set
            {
                this._IsReadOnlyCodigoProducto = value;
                ChangeNotify("_IsReadOnlyCodigoProducto");
            }
        }
        public Boolean IsReadOnlyCantidad
        {
            get
            {
                return this._IsReadOnlyCantidad;
            }
            set
            {
                this._IsReadOnlyCantidad = value;
                ChangeNotify("IsReadOnlyCantidad");
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
        public ObservableCollection<DetalleCompra> DetalleCompras
        {
            get
            {
                if (this.DetalleCompras == null)
                {
                    this.DetalleCompras = new ObservableCollection<DetalleCompra>();
                    foreach (DetalleCompra elemento in db.DetalleCompras.ToList())
                    {
                        this._DetalleCompra.Add(elemento);
                    }
                }
                return this._DetalleCompra;
            }
            set { this._DetalleCompra = value; }
        }
        public DetalleCompraModelView()
        {
            this.Titulo = "Detalle de compras:";
            this.Instancia = this;//Se hace referencia a la instancia que se creo
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        //Interfaz ICommand
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
            /*throw new NotImplementedException();*/
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this.IsReadOnlyIdCompra = false;
                this.IsReadOnlyCantidad = false;
                this.IsReadOnlyPrecio = false;
                this.IsReadOnlyCodigoProducto = false;
            }
            if (parameter.Equals("Save"))
            {
                DetalleCompra parametro = new DetalleCompra();
                parametro.ID_Compra = Convert.ToInt16(this.IdCompra);
                parametro.Cantidad = Convert.ToInt16(this.Cantidad);
                parametro.Precio = Convert.ToInt16(this.Precio);
                parametro.Codigo_Producto = Convert.ToInt16(this.CodigoProducto);
                db.DetalleCompras.Add(parametro);
                db.SaveChanges();
                this.DetalleCompras.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
