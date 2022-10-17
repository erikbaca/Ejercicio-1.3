using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio_1_3.Tablas;
using Ejercicio_1_3.Datos;
using SQLite;
using System.IO;

namespace Ejercicio_1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Detalle : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, ApSeleccionado, EdadSeleccionado, CorreoSeleccionado, DireccionSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<TDatos> ResultadoDelete;
        IEnumerable<TDatos> ResultadoUpdate;

        public V_Detalle(int id, string nom, string ap, string edad, string correo, string direccion)
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            IdSeleccionado = id;
            NomSeleccionado = nom;
            ApSeleccionado = ap;
            EdadSeleccionado = edad;
            CorreoSeleccionado = correo;
            DireccionSeleccionado = direccion;

            btn_actualizar.Clicked += Btn_actualizar_Clicked;
            btn_eliminar.Clicked += Btn_eliminar_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = " ID :" + IdSeleccionado;
            txtNombre.Text = NomSeleccionado;
            txtApellidos.Text = ApSeleccionado;
            txtedad.Text = EdadSeleccionado;
            txtcorreo.Text = CorreoSeleccionado;
            txtdireccion.Text = DireccionSeleccionado;
        }
        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Datos_Usuario.db3");
            var db = new SQLiteConnection(rutaDB);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Confirmación", "Registro eliminado correctamente", "OK");
            Limpiar();
        }
        private void Btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutadb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Datos_Usuario.db3");
            var db = new SQLiteConnection(rutadb);
            ResultadoUpdate = Update(db, txtNombre.Text, txtApellidos.Text, txtedad.Text, txtcorreo.Text, txtdireccion.Text, IdSeleccionado);
            DisplayAlert("Confirmación", "Contacto acualizado correctamente", "OK");
        }
        public static IEnumerable<TDatos> Delete(SQLiteConnection db, int id)
        {
            return db.Query<TDatos>("Delete FROM TDatos WHERE Id = ?", id);
        }
        public static IEnumerable<TDatos> Update(SQLiteConnection db, string nombre, string apellidos, string edad, string correo, string direccion, int id)
        {
            return db.Query<TDatos>("UPDATE TDatos SET Nombre = ?, Apellidos = ?, Edad = ?, Correo=?, Direccion=?, WHERE Id =?", nombre, apellidos, edad, correo, direccion, id);
        }
        public void Limpiar()
        {
            lblMensaje.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtedad.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
        }
    }
}