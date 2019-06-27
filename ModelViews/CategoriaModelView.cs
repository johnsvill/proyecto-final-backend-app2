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
    public class CategoriaModelView : INotifyPropertyChanged, ICommand//INTERFAZ
    {
        //Enlace a la base de datos
        private AlmacenDataContext db = new AlmacenDataContext();

        private bool _IsReadOnlyCodigoCategoria = true;
        private bool _IsReadOnlyDescripcion = true;
        private string _CodigoCategoria;
        private string _Descripcion;

        public string CodigoCategoria
        {
            get
            {
                return this._CodigoCategoria;
            }
            set
            {
                this._CodigoCategoria = value;
                ChangeNotify("CodigoCategoria");
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

        private CategoriaModelView _Instancia;
        private ObservableCollection<Categoria> _Categoria;

        public CategoriaModelView Instancia
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
        public Boolean IsReadOnlyCodigoCategoria
        {
            get
            {
                return this._IsReadOnlyCodigoCategoria;
            }
            set
            {
                this._IsReadOnlyCodigoCategoria = value;
                ChangeNotify("IsReadOnlyCodigoCategoria");
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

        public ObservableCollection<Categoria> Categorias//Propiedad
        {
            get
            {
                if (this._Categoria == null)
                {
                    this._Categoria = new ObservableCollection<Categoria>();
                    foreach (Categoria elemento in db.Categorias.ToList())
                    {
                        this._Categoria.Add(elemento);
                    }
                }
                return this._Categoria;
            }
            set { this._Categoria = value; }
        }
        public CategoriaModelView()
        {
            this.Titulo = "Categoria de productos:";//Se inicializa el nombre del título
            this.Instancia = this;//Se hace referencia a la instancia que se creo
        }
        public string Titulo { get; set; }
        /*public object PropertyChangedEventHandler { get; private set; }*/

        //INTERFAZ ICommand
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeNotify(string Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
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
                this.IsReadOnlyCodigoCategoria = false;
                this.IsReadOnlyDescripcion = false;
            }
            if (parameter.Equals("Save"))
            {
                Categoria nuevo = new Categoria();
                nuevo.Codigo_Categoria = Convert.ToInt16(this.CodigoCategoria);
                nuevo.Descripcion = this.Descripcion;
                db.Categorias.Add(nuevo);
                db.SaveChanges();
                this.Categorias.Add(nuevo);
                MessageBox.Show("Registro Almacenado");
                /*throw new NotImplementedException();*/
            }
        }
    }
}
