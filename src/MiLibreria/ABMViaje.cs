using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria.Modelo;
using System.Data;

namespace MiLibreria
{
    public class ViajeFunc
    {
        public static void CrearViaje(Viaje viaje)
        {
            List<SqlParameter> parametros = PrepararParametros(viaje);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_VIAJE", DataBase.Tipos.StoredProcedure, parametros);
        }


        private static List<SqlParameter> PrepararParametros(Viaje viaje)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = viaje.cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_id", SqlDbType.VarChar, 30);
            parametro.Value = viaje.rec_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@via_fecha_salida", SqlDbType.DateTime, 100);
            parametro.Value = viaje.fecha_salida;
            parametros.Add(parametro);

            parametro = new SqlParameter("@via_fecha_llegada", SqlDbType.DateTime, 100);
            parametro.Value = viaje.fecha_llegada;
            parametros.Add(parametro);

            return parametros;

        }

        public static int ObtenerIDViaje(Viaje viaje)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cru_id", viaje.cru_id));
            parametros.Add(new SqlParameter("@rec_id", viaje.rec_id));
            parametros.Add(new SqlParameter("@via_fecha_salida", viaje.fecha_salida));
            parametros.Add(new SqlParameter("@via_fecha_llegada", viaje.fecha_llegada));

            int id = DataBase.queryForInt("TROLLS.OBTENER_ID_VIAJE", DataBase.Tipos.StoredProcedure, parametros);

            return id;
        }

        public static void CrearCabinasViaje(Int32 via_id, String cru_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@via_id", SqlDbType.Int);
            parametro.Value = via_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_CABINA_VIAJE", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static DataSet ListarRecorrido(String puerto_desde, String puerto_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@puerto_desde", SqlDbType.VarChar);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(puerto_desde))
            {
                parametro.Value = puerto_desde;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@puerto_hasta", SqlDbType.VarChar);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(puerto_hasta))
            {
                parametro.Value = puerto_hasta;
            }
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static DataSet ListarViaje(int pue_id_desde, int pue_id_hasta, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@pue_id_desde", SqlDbType.Int);
            parametro.Value = pue_id_desde;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pue_id_hasta", SqlDbType.Int);
            parametro.Value = pue_id_hasta;
            parametros.Add(parametro);

            parametro = new SqlParameter("@via_fecha_salida", SqlDbType.DateTime, 100);
            parametro.Value = fechaDesde;
            parametros.Add(parametro);

            parametro = new SqlParameter("@via_fecha_llegada", SqlDbType.DateTime, 100);
            parametro.Value = fechaHasta;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_VIAJE", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static SqlDataReader ObtenerPuerto()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERPUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }
    }
}
