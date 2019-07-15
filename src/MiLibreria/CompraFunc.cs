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

        public static bool ValidarClienteViaje(DateTime desde, DateTime hasta, Int32 idCliente, Int32 tipoDoc, Int32 pue_id_desde, Int32 pue_id_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@via_fecha_salida", SqlDbType.DateTime);
            parametro.Value = desde;
            parametros.Add(parametro);
            parametro = new SqlParameter("@via_fecha_llegada", SqlDbType.DateTime);
            parametro.Value = hasta;
            parametros.Add(parametro);
            parametro = new SqlParameter("@pue_id_desde", SqlDbType.Int, 100);
            parametro.Value = pue_id_desde;
            parametros.Add(parametro);
            parametro = new SqlParameter("@pue_id_hasta", SqlDbType.Int, 100);
            parametro.Value = pue_id_hasta;
            parametros.Add(parametro);
            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = idCliente;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Int, 100);
            parametro.Value = tipoDoc;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.VALIDARCLIENTEVIAJE", DataBase.Tipos.StoredProcedure, parametros);
            bool resultado;
            if (reader.HasRows)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }
            reader.Close();
            return resultado;
        }

        public static DataSet ListarComprasRealizadas(Int32 idCliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = idCliente;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_COMPRAS_REALIZADAS", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static SqlDataReader ObtenerMp()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERMP", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static SqlDataReader CrearCompra(Compra compra)
        {
            List<SqlParameter> parametros = PrepararParametros(compra);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.CREAR_COMPRA", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static DataSet VoucherCompra(Compra compra, int com_id)
        {
            List<SqlParameter> parametros = PrepararParametros(compra);

            SqlParameter parametro;

            parametro = new SqlParameter("@com_id", SqlDbType.Int, 100);
            parametro.Value = com_id;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.VOUCHER_COMPRA", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static DataSet VerificarReserva(int idReserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@res_id", SqlDbType.Int, 100);
            parametro.Value = idReserva;
            parametros.Add(parametro);
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.VERIFICAR_RESERVA", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static void CancelarReserva()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaSistemaCancelaReserva = ChangeTimeCancelaReserva(fechaSistema);

            parametro = new SqlParameter("@fecha_sistema", SqlDbType.DateTime);
            parametro.Value = fechaSistemaCancelaReserva;
            parametros.Add(parametro);  

            DataBase.EscribirEnLaBase("TROLLS.CANCELAR_RESERVA", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void ComprarReserva(int idReserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@res_id", SqlDbType.Int, 100);
            parametro.Value = idReserva;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.RESERVA_COMPRADA", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static DataSet VoucherReserva(Reserva reserva)
        {
            List<SqlParameter> parametros = PrepararParametrosVoucher(reserva);
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.VOUCHER_RESERVA", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        private static List<SqlParameter> PrepararParametrosVoucher(Reserva reserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = reserva.res_cli;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Int, 100);
            parametro.Value = reserva.res_tipoDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cabinas", SqlDbType.Structured);
            parametro.Value = reserva.cabinas;
            parametros.Add(parametro);

            return parametros;

        }

        public static void CrearReserva(Reserva reserva)
        {
            List<SqlParameter> parametros = PrepararParametros(reserva);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_RESERVA", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static Int32 ObtenerIDMp(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT MP_ID FROM TROLLS.MEDIOPAGO WHERE MP_DESC = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static DataSet ListarVoucherCompra(DataTable cabinasCompradas, Int32 IDCliente, Int32 pue_id_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cli_id", SqlDbType.Int);
            parametro.Value = IDCliente;    
            parametros.Add(parametro);

            parametro = new SqlParameter("@pue_id_hasta", SqlDbType.Int);
            parametro.Value = pue_id_hasta;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cabinas", SqlDbType.Structured);
            parametro.Value = cabinasCompradas;
            parametros.Add(parametro);  

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_VOUCHER_COMPRA", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        private static List<SqlParameter> PrepararParametros(Compra compra)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = compra.com_cli;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Int, 100);
            parametro.Value = compra.com_tipoDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@com_fecha", SqlDbType.DateTime);
            parametro.Value = compra.com_fecha;
            parametros.Add(parametro);

            parametro = new SqlParameter("@com_mp", SqlDbType.Int, 100);
            parametro.Value = compra.com_mp;
            parametros.Add(parametro);

            parametro = new SqlParameter("@detalle", SqlDbType.VarChar, 400);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(compra.com_detalle))
            {
                parametro.Value = compra.com_detalle;
            }
            parametros.Add(parametro);
            parametro = new SqlParameter("@cabinas", SqlDbType.Structured);
            parametro.Value = compra.cabinas;
            parametros.Add(parametro);          

            return parametros;

        }

        private static List<SqlParameter> PrepararParametros(Reserva reserva)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = reserva.res_cli;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Int, 100);
            parametro.Value = reserva.res_tipoDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@res_fecha", SqlDbType.DateTime);
            parametro.Value = reserva.res_fecha;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cabinas", SqlDbType.Structured);
            parametro.Value = reserva.cabinas;
            parametros.Add(parametro);

            return parametros;

        }

        public static DateTime ChangeTimeCancelaReserva(DateTime dateTime)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                (dateTime.Day-4),
                dateTime.Hour,
                dateTime.Minute,
                dateTime.Second,
                dateTime.Millisecond,
                dateTime.Kind);
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
            
            DataBase.EscribirEnLaBase("TROLLS.RENDIR_COMPRA", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static DataSet ListarComprasRendir()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_COMPRAS_A_RENDIR", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }
    }
}
