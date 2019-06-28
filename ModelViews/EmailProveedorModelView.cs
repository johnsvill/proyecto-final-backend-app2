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
    public class EmailProveedorModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private string _Email;
        private string _CodigoProveedor;

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
                ChangedProperty("Email");
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
                ChangedProperty("CodigoProveedor");
            }
        }
        private EmailProveedorModelView _Instancia;
        public EmailProveedorModelView Instancia
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
        public Boolean IsReadOnlyEmail
        {
            get
            {
                return this._IsReadOnlyEmail;
            }
            set
            {
                this._IsReadOnlyEmail = value;
                ChangedProperty("IsReadOnlyEmail");
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
                ChangedProperty("IsReadOnlyCodigoProveedor");
            }
        }
        private ObservableCollection<EmailProveedor> _EmailProveedor;
        public ObservableCollection<EmailProveedor> EmailProveedores
        {
            get
            {
                if (this._EmailProveedor == null)
                {
                    this._EmailProveedor = new ObservableCollection<EmailProveedor>();
                    foreach (EmailProveedor elemento in db.EmailProveedores.ToList())
                    {
                        this._EmailProveedor.Add(elemento);
                    }
                }
                return this._EmailProveedor;
            }
            set { this._EmailProveedor = value; }
        }
        public EmailProveedorModelView()
        {
            this.Titulo = "Email de proveedores: ";
            this.Instancia = this;
        }
        public string Titulo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        //Interfaz ICommand
        public void ChangedProperty(string property)
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
                this.IsReadOnlyEmail = false;
                this.IsReadOnlyCodigoProveedor = false;
            }
            if (parameter.Equals("Save"))
            {
                EmailProveedor parametro = new EmailProveedor();
                parametro.Codigo_Proveedor = Convert.ToInt16(this.CodigoProveedor);
                parametro.Email = this.Email;
                db.EmailProveedores.Add(parametro);
                db.SaveChanges();
                this.EmailProveedores.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
        }
    }
}
