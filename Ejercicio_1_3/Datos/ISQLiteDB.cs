using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio_1_3.Datos
{
   public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
