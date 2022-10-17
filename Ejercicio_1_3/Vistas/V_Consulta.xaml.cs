using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Ejercicio_1_3.Tablas;
using Ejercicio_1_3.Datos;
using System.Collections.ObjectModel;

namespace Ejercicio_1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Consulta : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<TDatos> TablaContacto;
        public V_Consulta()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            ListaContactos.ItemSelected += ListaContactos_ItemSelected;
        }
        private void ListaContactos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (TDatos)e.SelectedItem;
            var item = Obj.Id.ToString();
            var nom = Obj.Nombre;
            var ap = Obj.Apellidos;
            var edad = Obj.Edad;
            var correo = Obj.Correo;
            var direccion = Obj.Direccion;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new V_Detalle(ID, nom, ap, edad, correo, direccion));
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected async override void OnAppearing()
        {
            var ResulRegistros = await conexion.Table<TDatos>().ToListAsync();
            TablaContacto = new ObservableCollection<TDatos>(ResulRegistros);
            ListaContactos.ItemsSource = TablaContacto;
            base.OnAppearing();
        }
    }
}