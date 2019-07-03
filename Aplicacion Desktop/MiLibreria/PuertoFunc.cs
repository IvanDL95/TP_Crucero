using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using MiLibreria;
using System.Data;

namespace MiLibreria
{
    public class PuertoFunc
    {
        public static SqlDataReader ObtenerPuerto()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_PUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataTable ObtenerPuertoList()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_PUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static String ObtenerNombre(int pue_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 30);
            parametro.Value = pue_id;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_NOMBRE_PUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return reader.GetString(0);
        }

    }
}
