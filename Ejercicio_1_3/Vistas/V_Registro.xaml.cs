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
using System.IO;

namespace Ejercicio_1_3.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class V_Registro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public V_Registro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLiteDB>().GetConnection();
            btnGuardar.Clicked += BtnGuardar_Clicked;
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var DatosContacto = new TDatos
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Edad = txtEdad.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text
            };
            conexion.InsertAsync(DatosContacto);
            limpiarFormulario();
            DisplayAlert("Confirmación", "Registro guardado correctamente", "OK");
        }
        private void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";         
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
        }
    }
}