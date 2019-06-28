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
    public class FacturaModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyNumeroFactura = true;
        private bool _IsReadOnlyNit = true;
        private bool _IsReadOnlyFecha = true;
        private bool _IsReadOnlyTotal = true;
        private string _NumeroFactura;
        private string _Nit;
        private string _Fecha;
        private string _Total;

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
        public string Fecha
        {
            get
            {
                return this._Fecha;
            }
            set
            {
                this._Fecha = value;
                ChangedNotify("Fecha");
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
                ChangedNotify("Total");
            }
        }
        private FacturaModelView _Instancia;
        public FacturaModelView Instancia
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
        public Boolean IsReadOnlyFecha
        {
            get
            {
                return this._IsReadOnlyFecha;
            }
            set
            {
                this._IsReadOnlyFecha = value;
                ChangedNotify("IsReadOnlyFecha");
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
                ChangedNotify("IsReadOnlyTotal");
            }
        }
        private ObservableCollection<Factura> _Factura;
        public ObservableCollection<Factura> Facturas
        {
            get
            {
                if (this._Factura == null)
                {
                    this._Factura = new ObservableCollection<Factura>();
                    foreach (Factura elemento in db.Facturas.ToList())
                    {
                        this._Factura.Add(elemento);
                    }
                }
                return this._Factura;
            }
            set { this._Factura = value; }
        }
        public FacturaModelView()
        {
            this.Titulo = "Facturas";
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
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                this.IsReadOnlyNumeroFactura = false;
                this.IsReadOnlyNit = false;
                this.IsReadOnlyFecha = false;
                this.IsReadOnlyTotal = false;
            }
            if (parameter.Equals("Save"))
            {
                Factura parametro = new Factura();
                parametro.Numero_Factura = Convert.ToInt16(this.NumeroFactura);
                parametro.Nit = this.Nit;
                parametro.Fecha = Convert.ToDateTime(this.Fecha);
                parametro.Total = Convert.ToDecimal(this.Total);
                db.Facturas.Add(parametro);
                db.SaveChanges();
                this.Facturas.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
