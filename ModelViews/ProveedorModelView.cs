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
    public class ProveedorModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoProveedor = true;
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyRazonSocial = true;
        private bool _IsReadOnlyDireccion = true;
        private bool _IsReadOnlyPaginaWeb = true;
        private bool _IsReadOnlyContactoPrincipal = true;
        private string _CodigoProveedor;
        private string _Nit;
        private string _RazonSocial;
        private string _Direccion;
        private string _PaginaWeb;
        private string _ContactoPrincipal;

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
        public string Nit
        {
            get
            {
                return this._Nit;
            }
            set
            {
                this._Nit = value;
                ChangedNotify("Nit");
            }
        }
        public string RazonSocial
        {
            get
            {
                return this._RazonSocial;
            }
            set
            {
                this._RazonSocial = value;
                ChangedNotify("RazonSocial");
            }
        }
        public string Direccion
        {
            get
            {
                return this._Direccion;
            }
            set
            {
                this._Direccion = value;
                ChangedNotify("Direccion");
            }
        }
        public string PaginaWeb
        {
            get
            {
                return this._PaginaWeb;
            }
            set
            {
                this._PaginaWeb = value;
                ChangedNotify("PaginaWeb");
            }
        }
        public string ContactoPrincipal
        {
            get
            {
                return this._ContactoPrincipal;
            }
            set
            {
                this._ContactoPrincipal = value;
                ChangedNotify("ContactoPrincipal");
            }
        }
        private ProveedorModelView _Instancia;
        public ProveedorModelView Instancia
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
        public Boolean IsReadOnlyNit
        {
            get
            {
                return this._IsReadOnlyNit;
            }
            set
            {
                this._IsReadOnlyNit = value;
                ChangedNotify("IsReadOnlyNit");
            }
        }
        public Boolean IsReadOnlyRazonSocial
        {
            get
            {
                return this._IsReadOnlyRazonSocial;
            }
            set
            {
                this._IsReadOnlyRazonSocial = value;
                ChangedNotify("IsReadOnlyRazonSocial");
            }
        }
        public Boolean IsReadOnlyDireccion
        {
            get
            {
                return this._IsReadOnlyDireccion;
            }
            set
            {
                this._IsReadOnlyDireccion = value;
                ChangedNotify("IsReadOnlyDireccion");
            }
        }

        public Boolean IsReadOnlyPaginaWeb
        {
            get
            {
                return this._IsReadOnlyPaginaWeb;
            }
            set
            {
                this._IsReadOnlyPaginaWeb = value;
                ChangedNotify("IsReadOnlyPaginaWeb");
            }
        }
        public Boolean IsReadOnlyContactoPrincipal
        {
            get
            {
                return this._IsReadOnlyContactoPrincipal;
            }
            set
            {
                this._IsReadOnlyContactoPrincipal = value;
                ChangedNotify("IsReadOnlyContactoPrincipal");
            }
        }
        private ObservableCollection<Proveedor> _Proveedor;
        public ObservableCollection<Proveedor> Proveedores
        {
            get
            {
                this._Proveedor = new ObservableCollection<Proveedor>();
                foreach (Proveedor elemento in db.Proveedores.ToList())
                {
                    this.Proveedores.Add(elemento);
                }
                return this._Proveedor;
            }
            set { this._Proveedor = value; }
        }
        public ProveedorModelView()
        {
            this.Titulo = "Lista de proveedores:";
            this.Instancia = this;
        }
        public string Titulo { get; set; }
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
                this.IsReadOnlyCodigoProveedor = false;
                this.IsReadOnlyContactoPrincipal = false;
                this.IsReadOnlyDireccion = false;
                this.IsReadOnlyNit = false;
                this.IsReadOnlyPaginaWeb = false;
                this.IsReadOnlyRazonSocial = false;
            }
            if (parameter.Equals("Save"))
            {
                Proveedor parametro = new Proveedor();
                parametro.Codigo_Proveedor = Convert.ToInt16(this.CodigoProveedor);
                parametro.Contacto_Principal = this.ContactoPrincipal;
                parametro.Direccion = this.Direccion;
                parametro.Nit = this.Nit;
                parametro.Pagina_Web = this.PaginaWeb;
                parametro.Razon_Social = this.RazonSocial;
                db.Proveedores.Add(parametro);
                db.SaveChanges();
                this.Proveedores.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
