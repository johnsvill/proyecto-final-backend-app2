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
    public class EmailClienteModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoEmail = true;
        private bool _IsReadOnlyEmail = true;
        private bool _IsReadOnlyNit = true;
        private string _CodigoEmail;
        private string _Email;
        private string _Nit;

        public string CodigoEmail
        {
            get
            {
                return this._CodigoEmail;
            }
            set
            {
                this._CodigoEmail = value;
                ChangedNotify("CodigoEmail");
            }
        }
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
                ChangedNotify("Email");
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
        private EmailClienteModelView _Instancia;
        public EmailClienteModelView Instancia
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
        public Boolean IsReadOnlyCodigoEmail
        {
            get
            {
                return this._IsReadOnlyCodigoEmail;
            }
            set
            {
                this._IsReadOnlyCodigoEmail = value;
                ChangedNotify("IsReadOnlyCodigoEmail");
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
                ChangedNotify("IsReadOnlyEmail");
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
        private ObservableCollection<EmailCliente> _EmailCliente;
        public ObservableCollection<EmailCliente> EmailClientes
        {
            get
            {
                if (this._EmailCliente == null)
                {
                    this._EmailCliente = new ObservableCollection<EmailCliente>();
                    foreach (EmailCliente elemento in db.EmailClientes.ToList())
                    {
                        this._EmailCliente.Add(elemento);
                    }
                }
                return this._EmailCliente;
            }
            set { this._EmailCliente = value; }
        }
        public EmailClienteModelView()
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
                this.IsReadOnlyCodigoEmail = false;
                this.IsReadOnlyEmail = false;
                this.IsReadOnlyNit = false;
            }
            if (parameter.Equals("Save"))
            {
                EmailCliente parametro = new EmailCliente();
                parametro.Codigo_Email = Convert.ToInt16(this.CodigoEmail);
                parametro.Email = this.Email;
                parametro.Nit = this.Nit;
                db.EmailClientes.Add(parametro);
                db.SaveChanges();
                this.EmailClientes.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
