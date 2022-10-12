using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Ejercicio_1_3.Tablas;
using Ejercicio_1_3.Datos;
using Xamarin.Forms;
using Ejercicio_1_3.Droid;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Ejercicio_1_3.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            // Se crea la base de datos
            var path = Path.Combine(ruta, "Datos_Usuario.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}