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
    public class TipoEmpaqueModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoEmpaque = true;
        private bool _IsReadOnlyDescripcion = true;
        private string _CodigoEmpaque;
        private string _Descripcion;

        public string CodigoEmpaque
        {
            get
            {
                return this._CodigoEmpaque;
            }
            set
            {
                this._CodigoEmpaque = value;
                ChangeNotify("CodigoEmpaque");
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
                ChangeNotify("Descripcion");
            }
        }

        private TipoEmpaqueModelView _Instancia;
        public TipoEmpaqueModelView Instancia
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
        private ObservableCollection<TipoEmpaque> _TipoEmpaque;

        public Boolean IsReadOnlyCodigoEmpaque
        {
            get
            {
                return this._IsReadOnlyCodigoEmpaque;
            }
            set
            {
                this._IsReadOnlyCodigoEmpaque = value;
                ChangeNotify("IsReadOnlyCodigoEmpaque");
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
                ChangeNotify("IsReadOnlyDescripcion");
            }
        }
        public ObservableCollection<TipoEmpaque> TipoEmpaques
        {
            get
            {
                if (TipoEmpaques == null)
                {
                    this._TipoEmpaque = new ObservableCollection<TipoEmpaque>();
                    foreach (TipoEmpaque elemento in db.TipoEmpaques.ToList())
                    {
                        this._TipoEmpaque.Add(elemento);
                    }
                }
                return this._TipoEmpaque;
            }
            set { this._TipoEmpaque = value; }
        }
        public TipoEmpaqueModelView()
        {
            this.Titulo = "Descripción";
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
                this.IsReadOnlyCodigoEmpaque = false;
                this.IsReadOnlyDescripcion = false;
            }
            if (parameter.Equals("Save"))
            {
                TipoEmpaque parametro = new TipoEmpaque();
                parametro.Codigo_Empaque = Convert.ToInt16(this.CodigoEmpaque);
                parametro.Descripcion = this.Descripcion;
                db.TipoEmpaques.Add(parametro);
                db.SaveChanges();
                this.TipoEmpaques.Add(parametro);
                MessageBox.Show("Registro Almacenado");
            }
            /*throw new NotImplementedException();*/
        }
    }
}
