using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MiLibreria
{
    public class FabricanteFunc
    {
        public static SqlDataReader ObtenerFabricante()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERFABRICANTES", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataTable ObtenerFabricanteList()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENERFABRICANTES", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

    }
}
