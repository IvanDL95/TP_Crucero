using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using System.Data.SqlClient;

namespace MiLibreria
{
    public class Function
    {
        private static Funcion ObtenerFuncion(SqlDataReader reader)
        {
            Funcion funcion = new Funcion();

            funcion.Id = Convert.ToInt32(reader.GetValue(0));
            funcion.Nombre = reader.GetString(reader.GetOrdinal("fun_NOMBRE"));
            funcion.Visible = reader.GetBoolean(reader.GetOrdinal("fun_visible"));

            return funcion;
        }

        public static List<Funcion> ObtenerFunciones()
        {
            List<Funcion> funciones = new List<Funcion>();

            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT * FROM TROLLS.FUNCIONALIDAD");

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Funcion funcion = ObtenerFuncion(reader);
                    funciones.Add(funcion);
                }
            }

            reader.Close();

            return funciones;
        }

        public static List<Funcion> ObtenerFuncionesPorRol(Int32 id)
        {
            List<Funcion> funciones = new List<Funcion>();

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@ID_Rol", id));

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.LISTAR_FUNCIONES_X_ROL",DataBase.Tipos.StoredProcedure,parametros);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Funcion funcion = ObtenerFuncion(reader);
                    funciones.Add(funcion);
                }
            }

            reader.Close();

            return funciones;
        }

        public static List<Funcion> ObtenerFuncionesNoAsignadasPorRol(Int32 id)
        {
            List<Funcion> funciones = new List<Funcion>();

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@ID_Rol", id));

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.LISTAR_FUNCIONES_X_ROL_NO_ASIGNADAS", DataBase.Tipos.StoredProcedure, parametros);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Funcion funcion = ObtenerFuncion(reader);
                    funciones.Add(funcion);
                }
            }

            reader.Close();
            
            return funciones;
        }

    }
}
