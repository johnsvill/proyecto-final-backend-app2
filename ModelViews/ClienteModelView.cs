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
    public class ClienteModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyDpi = true;
        private bool _IsReadOnlyNombre = true;
        private bool _IsReadOnlyDireccion = true;
        private string _Nit;
        private string _Dpi;
        private string _Nombre;
        private string _Direccion;

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
        public string Dpi
        {
            get
            {
                return this._Dpi;
            }
            set
            {
                this._Dpi = value;
                ChangedNotify("Dpi");
            }
        }
        public string Nombre
        {
            get
            {
                return this._Nombre;
            }
            set
            {
                this._Nombre = value;
                ChangedNotify("Nombre");
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
        private ClienteModelView _Instancia;
        public ClienteModelView Instancia
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
        public Boolean IsReadOnlyDpi
        {
            get
            {
                return this._IsReadOnlyDpi;
            }
            set
            {
                this._IsReadOnlyDpi = value;
                ChangedNotify("IsReadOnlyDpi");
            }
        }
        public Boolean IsReadOnlyNombre
        {
            get
            {
                return this._IsReadOnlyNombre;
            }
            set
            {
                this._IsReadOnlyNombre = value;
                ChangedNotify("IsReadOnlyNombre");
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
        private ObservableCollection<Cliente> _Cliente;
        public ObservableCollection<Cliente> Clientes
        {
            get
            {
                if (this._Cliente == null)
                {
                    this._Cliente = new ObservableCollection<Cliente>();
                    foreach (Cliente elemento in db.Clientes.ToList())
                    {
                        this._Cliente.Add(elemento);
                    }
                }
                return this._Cliente;
            }
            set { this._Cliente = value; }
        }
        public ClienteModelView()
        {
            this.Titulo = "";
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
                this.IsReadOnlyDireccion = false;
                this.IsReadOnlyDpi = false;
                this.IsReadOnlyNit = false;
                this.IsReadOnlyNombre = false;
            }
            if (parameter.Equals("Save"))
            {
                Cliente parametro = new Cliente();
                parametro.Nit = this.Nit;
                parametro.DPI = this.Dpi;
                parametro.Direccion = this.Direccion;
                parametro.Nombre = this.Nombre;
                db.Clientes.Add(parametro);
                db.SaveChanges();
                this.Clientes.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
