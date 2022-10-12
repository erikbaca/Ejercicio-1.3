using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio_1_3.Tablas
{
   public class personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string Apellidos { get; set; }
        [MaxLength(200)]
        public string Edad { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
