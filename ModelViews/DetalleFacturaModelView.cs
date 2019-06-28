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
    public class DetalleFacturaModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyNumeroFactura = true;
        private bool _IsReadOnlyCodigoProducto = true;
        private bool _IsReadOnlyCantidad = true;
        private bool _IsReadOnlyPrecio = true;
        private bool _IsReadOnlyDescuento = true;
        private string _NumeroFactura;
        private string _CodigoProducto;
        private string _Precio;
        private string _Descuento;
        private string _Cantidad;

        public string NumeroFactura
        {
            get
            {
                return this._NumeroFactura;
            }
            set
            {
                this._NumeroFactura = value;
                ChangedNotify("NumeroFactura");
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
                ChangedNotify("CodigoProducto");
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
                ChangedNotify("Precio");
            }
        }
        public string Descuento
        {
            get
            {
                return this._Descuento;
            }
            set
            {
                this._Descuento = value;
                ChangedNotify("Descuento");
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
                ChangedNotify("Cantidad");
            }
        }
        private DetalleFacturaModelView _Instancia;
        private ObservableCollection<DetalleFactura> _DetalleFactura;

        public DetalleFacturaModelView Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
                ChangedNotify("Instancia");
            }
        }
        public ObservableCollection<DetalleFactura> DetalleFacturas
        {
            get
            {
                if (this._DetalleFactura == null)
                {
                    this._DetalleFactura = new ObservableCollection<DetalleFactura>();
                    foreach (DetalleFactura elemento in db.DetalleFacturas.ToList())
                    {
                        this._DetalleFactura.Add(elemento);
                    }
                }
                return this._DetalleFactura;
            }
            set { this._DetalleFactura = value; }
        }
        public DetalleFacturaModelView()
        {
            this.Titulo = "Detalle de facturas";
            this.Instancia = this;
        }
        public string Titulo { get; set; }
        public Boolean IsReadOnlyNumeroFactura
        {
            get
            {
                return this._IsReadOnlyNumeroFactura;
            }
            set
            {
                this._IsReadOnlyNumeroFactura = value;
                ChangedNotify("IsReadOnlyNumeroFactura");
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
                ChangedNotify("IsReadOnlyCodigoProducto");
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
                ChangedNotify("IsReadOnlyCantidad");
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
                ChangedNotify("IsReadOnlyPrecio");
            }
        }
        public Boolean IsReadOnlyDescuento
        {
            get
            {
                return this._IsReadOnlyDescuento;
            }
            set
            {
                this._IsReadOnlyDescuento = value;
                ChangedNotify("IsReadOnlyDescuento");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        //Interfaz ICommand
        public void ChangedNotify(string property)
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
                this.IsReadOnlyCantidad = false;
                this.IsReadOnlyCodigoProducto = false;
                this.IsReadOnlyDescuento = false;
                this.IsReadOnlyNumeroFactura = false;
                this.IsReadOnlyPrecio = false;
            }
            if (parameter.Equals("Save"))
            {
                DetalleFactura parametro = new DetalleFactura();
                parametro.Cantidad = Convert.ToInt16(this.Cantidad);
                parametro.Codigo_Producto = Convert.ToInt16(this.CodigoProducto);
                parametro.Descuento = Convert.ToInt16(this.Descuento);
                parametro.Numero_Factura = Convert.ToInt16(this.NumeroFactura);
                parametro.Precio = Convert.ToInt16(this.Precio);
                db.DetalleFacturas.Add(parametro);
                db.SaveChanges();
                this.DetalleFacturas.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
