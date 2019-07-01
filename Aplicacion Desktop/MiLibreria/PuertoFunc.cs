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
    class PuertoFunc
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
    }
}
