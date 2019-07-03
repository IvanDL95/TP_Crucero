using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MiLibreria.Modelo;
using System.Data;

namespace MiLibreria
{
    public class ListadoFunc
    {
        public static DataSet Listado(int anio, int semestre, int listado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@semestre", SqlDbType.Int, 100);
            parametro.Value = semestre;
            parametros.Add(parametro);
            parametro = new SqlParameter("@anio", SqlDbType.Int, 100);
            parametro.Value = anio;
            parametros.Add(parametro);

            if (listado == 2)
            {
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                parametro = new SqlParameter("@fechasistema", SqlDbType.DateTime);
                parametro.Value = fechaSistema;
                parametros.Add(parametro);
            }

            
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.sp_listado_estadistico_"+ listado.ToString(), DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }
    }
}
