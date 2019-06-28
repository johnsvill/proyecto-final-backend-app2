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
    public class CompraModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyNumeroDocumento = true;
        private bool _IsReadOnlyCodigoProveedor = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _NumeroDocumento;
        private string _CodigoProveedor;
        private string _Fecha;
        private string _Total;

        public string NumeroDocumento
        {
            get
            {
                return this._NumeroDocumento;
            }
            set
            {
                this._NumeroDocumento = value;
                ChangedProperty("NumeroDocumento");
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
        public string Fecha
        {
            get
            {
                return this._Fecha;
            }
            set
            {
                this._Fecha = value;
                ChangedProperty("Fecha");
            }
        }
        public string Total
        {
            get
            {
                return this._Total;
            }
            set
            {
                this._Total = value;
                ChangedProperty("Total");
            }
        }
        private CompraModelView _Instancia;
        public CompraModelView Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
                ChangedProperty("Instancia");
            }
        }
        public Boolean IsReadOnlyNumeroDocumento
        {
            get
            {
                return this._IsReadOnlyNumeroDocumento;
            }
            set
            {
                this._IsReadOnlyNumeroDocumento = value;
                ChangedProperty("IsReadOnlyNumeroDocumento");
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
        public Boolean IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                ChangedProperty("IsReadOnlyFecha");
            }
        }
        public Boolean IsReadOnlyTotal
        {
            get
            {
                return this._IsReadOnlyTotal;
            }
            set
            {
                this._IsReadOnlyTotal = value;
                ChangedProperty("IsReadOnlyTotal");
            }
        }
        private ObservableCollection<Compra> _Compra;
        public ObservableCollection<Compra> Compras
        {
            get
            {
                this._Compra = new ObservableCollection<Compra>();
                foreach (Compra elemento in db.Compras.ToList())
                {
                    this._Compra.Add(elemento);
                }
                return this._Compra;
            }
            set { this._Compra = value; }
        }
        public CompraModelView()
        {
            this.Titulo = "Compras realizadas";
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
                this.IsReadOnlyNumeroDocumento = false;
                this.IsReadOnlyCodigoProveedor = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
            }
            if (parameter.Equals("Save"))
            {
                Compra parametro = new Compra();
                parametro.Numero_Documento = Convert.ToInt16(this.NumeroDocumento);
                parametro.Codigo_Proveedor = Convert.ToInt16(this.CodigoProveedor);
                parametro.Fecha = Convert.ToDateTime(this.Fecha);
                parametro.Total = Convert.ToDecimal(this.Total);
                db.Compras.Add(parametro);
                db.SaveChanges();
                this.Compras.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
        }
    }
}
