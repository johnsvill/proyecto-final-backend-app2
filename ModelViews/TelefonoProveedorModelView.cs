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
    public class TelefonoProveedorModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoTelefono = true;
        private bool _IsReadOnlyNumero = true;
        private bool _IsReadOnlyDescripcion = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _CodigoTelefono;
        private string _Numero;
        private string _CodigoProveedor;
        private string _Descripcion;

        public string CodigoTelefono
        {
            get
            {
                return this._CodigoTelefono;
            }
            set
            {
                this._CodigoTelefono = value;
                ChangedNotify("CodigoTelefono");
            }
        }
        public string Numero
        {
            get
            {
                return this._Numero;
            }
            set
            {
                this._Numero = value;
                ChangedNotify("Numero");
            }
        }
        public string CodigoProveedor
        {
            get
            {
                return this._CodigoProveedor;
            }
            set
            {
                this._CodigoProveedor = value;
                ChangedNotify("CodigoProveedor");
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
                ChangedNotify("Descripcion");
            }
        }
        private TelefonoProveedorModelView _Instancia;
        public TelefonoProveedorModelView Instancia
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
        public Boolean IsReadOnlyCodigoTelefono
        {
            get
            {
                return this._IsReadOnlyCodigoTelefono;
            }
            set
            {
                this._IsReadOnlyCodigoTelefono = value;
                ChangedNotify("IsReadOnlyCodigoTelefono");
            }
        }
        public Boolean IsReadOnlyNumero
        {
            get
            {
                return this._IsReadOnlyNumero;
            }
            set
            {
                this._IsReadOnlyNumero = value;
                ChangedNotify("IsReadOnlyNumero");
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
                ChangedNotify("IsReadOnlyDescripcion");
            }
        }
        public Boolean IsReadOnlyCodigoProveedor
        {
            get
            {
                return this._IsReadOnlyCodigoProveedor;
            }
            set
            {
                this._IsReadOnlyCodigoProveedor = value;
                ChangedNotify("IsReadOnlyCodigoProveedor");
            }
        }
        private ObservableCollection<TelefonoProveedor> _TelefonoProveedor;
        public ObservableCollection<TelefonoProveedor> TelefonoProveedores
        {
            get
            {
                if (this._TelefonoProveedor == null)
                {
                    this._TelefonoProveedor = new ObservableCollection<TelefonoProveedor>();
                    foreach (TelefonoProveedor elemento in db.TelefonoProveedores.ToList())
                    {
                        this._TelefonoProveedor.Add(elemento);
                    }
                }
                return this._TelefonoProveedor;
            }
            set { this._TelefonoProveedor = value; }
        }
        public TelefonoProveedorModelView()
        {
            this.Titulo = "Telefonos de proveedores:";
            this.Instancia = this;
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
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
                this.IsReadOnlyCodigoProveedor = false;
                this.IsReadOnlyCodigoTelefono = false;
                this.IsReadOnlyDescripcion = false;
                this.IsReadOnlyNumero = false;
            }
            if (parameter.Equals("Save"))
            {
                TelefonoProveedor parametro = new TelefonoProveedor();
                parametro.Codigo_Telefono = Convert.ToInt16(this.CodigoTelefono);
                parametro.Numero = this.Numero;
                parametro.Descripcion = this.Descripcion;
                parametro.Codigo_Proveedor = Convert.ToInt16(this.CodigoProveedor);
                db.TelefonoProveedores.Add(parametro);
                db.SaveChanges();
                this.TelefonoProveedores.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
