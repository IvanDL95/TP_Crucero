using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using MiLibreria;
using System.Data;
using System.Data.SqlClient;

namespace MiLibreria
{
    public class CompraFunc
    {

        public static DataSet ListarComprasRealizadas(Int32 idCliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = idCliente;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("RJT.LISTAR_COMPRAS_REALIZADAS", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static void CrearCompra(Compra compra)
        {
            List<SqlParameter> parametros = PrepararParametros(compra);
            DataBase.EscribirEnLaBase("RJT.CREAR_COMPRA", DataBase.Tipos.StoredProcedure, parametros);
        }

        private static List<SqlParameter> PrepararParametros(Compra compra)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = compra.com_cli;
            parametros.Add(parametro);

            parametro = new SqlParameter("@com_fecha", SqlDbType.VarChar, 400);
            parametro.Value = compra.com_fecha;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubicaciones", SqlDbType.Structured);
            parametro.Value = compra.ubicaciones;
            parametros.Add(parametro);          

            return parametros;

        }

        public static void RendirCompra(DataTable compras, DateTime fechaSistema)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@compras", SqlDbType.Structured);
            parametro.Value = compras;
            parametros.Add(parametro);

            parametro = new SqlParameter("@fact_fecha", SqlDbType.DateTime);
            parametro.Value = fechaSistema;
            parametros.Add(parametro);           
            
            DataBase.EscribirEnLaBase("RJT.RENDIR_COMPRA", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static DataSet ListarComprasRendir()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            DataSet ds = DataBase.ObtenerUnDataSet("RJT.LISTAR_COMPRAS_A_RENDIR", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }
    }
}
