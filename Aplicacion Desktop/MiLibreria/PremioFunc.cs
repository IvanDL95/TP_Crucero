using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using MiLibreria;
using System.Data.SqlClient;
using System.Data;

namespace MiLibreria
{
    public static class PremioFunc
    {
        public static DataSet ListarPremiosExistentes()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("RJT.LISTAR_PREMIOS_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);
            return ds;
        }

        public static void CanjearPuntos(Int32 idCliente, Int32 tipoPremio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@cli_id", SqlDbType.Int);
            parametro.Value = idCliente;
            parametros.Add(parametro);

            parametro = new SqlParameter("@tp_id", SqlDbType.Int);
            parametro.Value = tipoPremio;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("RJT.CANJEAR_PUNTOS", DataBase.Tipos.StoredProcedure, parametros);
        }
    }
}
