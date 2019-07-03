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
    public class CruceroFunc
    {
        public static DataSet ListarCrucerosExistentes(int? tser_id, int? fab_id, String cru_mod_desc, String cru_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@CRU_ID", SqlDbType.VarChar, 30);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(cru_id))
            {
                parametro.Value = cru_id;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_mod_desc", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(cru_mod_desc))
            {
                parametro.Value = cru_mod_desc;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_tser_id", SqlDbType.Int, 100);
            if (!tser_id.HasValue)
                parametro.Value = DBNull.Value;
            else
                if (tser_id == 0 )
                    parametro.Value = DBNull.Value;
            else
                parametro.Value = tser_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fab_id", SqlDbType.Int, 100);
            if (fab_id == 0)
                parametro.Value = DBNull.Value;
            else
                if (!fab_id.HasValue)
                    parametro.Value = DBNull.Value;
            else
            parametro.Value = fab_id;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_CRUCEROS_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static DataSet ListarCrucerosViaje(DateTime fechasalida, DateTime fechallegada)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@via_fecha_salida", SqlDbType.DateTime);
            parametro.Value = fechasalida;
            parametros.Add(parametro);

            parametro = new SqlParameter("@via_fecha_llegada", SqlDbType.DateTime);
            parametro.Value = fechallegada;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_CRUCEROS_VIAJE", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static DataSet ListarCrucerosReemplazo(String cru_id, DateTime fechabaja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id_original", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_definitiva", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_CRUCEROS_REEMPLAZO", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static void CancelarViajes(String cru_id, String motivo, DateTime fechabaja, DateTime fechareinicio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_fuera_servicio", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_reinicio_servicio", SqlDbType.DateTime);
            parametro.Value = fechareinicio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@can_motivo", SqlDbType.VarChar, 100);
            parametro.Value = motivo;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CANCELAR_VIAJES", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void CruceroBajaServicio(String cru_id, DateTime fechabaja, DateTime fechareinicio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_fuera_servicio", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_reinicio_servicio", SqlDbType.DateTime);
            parametro.Value = fechareinicio;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CRUCERO_BAJA_SERVICIO", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void CruceroBajaDefinitiva(String cru_id, DateTime fechabaja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_definitiva", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CRUCERO_BAJA_DEFINITIVA", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void CancelarViajesBajaDefinitiva(String cru_id, DateTime fechabaja, String motivo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_definitiva", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            parametro = new SqlParameter("@can_motivo", SqlDbType.VarChar, 100);
            parametro.Value = motivo;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CANCELAR_VIAJES_BAJA_DEFINITIVA", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ActualizarViajeReemplazo(String cru_id_original, String cru_id_reemplazo, DateTime fechabaja)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id_original", SqlDbType.VarChar, 30);
            parametro.Value = cru_id_original;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_definitiva", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.ACTUALIZAR_VIAJES_REEMPLAZO", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ReprogramarViajes(String cru_id, DateTime fechabaja, int dias, DateTime fechareinicio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.VarChar, 30);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja_fuera_servicio", SqlDbType.DateTime);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_reinicio_servicio", SqlDbType.DateTime);
            parametro.Value = fechareinicio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@dias", SqlDbType.Int);
            parametro.Value = dias;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.REPROGRAMAR_VIAJES", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static DataSet ListarPublicacionesPublicadas(String desc, DateTime pub_fecha_espec_de, DateTime pub_fecha_espec_hasta, DataTable dt)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@pub_desc", SqlDbType.VarChar, 400);
            if (!string.IsNullOrEmpty(desc))
                parametro.Value = desc;
            else
                parametro.Value = DBNull.Value;

            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_espec_de", SqlDbType.DateTime);
            //Fecha desde 00:00:00
            TimeSpan tsDe = new TimeSpan(0, 0, 0);
            pub_fecha_espec_de = pub_fecha_espec_de.Date + tsDe;
            parametro.Value = pub_fecha_espec_de;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_espec_hasta", SqlDbType.DateTime);
            //Fecha hasta 23:59:59
            TimeSpan tsHasta = new TimeSpan(23, 59, 59);
            pub_fecha_espec_hasta = pub_fecha_espec_hasta.Date + tsHasta;
            parametro.Value = pub_fecha_espec_hasta;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rubro", SqlDbType.Structured);
            parametro.Value = dt;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_PUBLICACIONES_PUBLICADAS", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static SqlDataReader ObtenerCrucero(String id_crucero)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.VarChar, 30);
            parametro.Value = id_crucero;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Crucero ObtenerCruceroDesdeUnReader(SqlDataReader reader)
        {
            Crucero crucero = new Crucero();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        crucero.id = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        crucero.mod = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        crucero.fab_id = Convert.ToInt32(reader.GetDecimal(2));
                    if (!reader.IsDBNull(3))
                        crucero.tser_id = Convert.ToInt32(reader.GetDecimal(3));
                    if (!reader.IsDBNull(4))
                        crucero.fecha_alta= reader.GetDateTime(4);
                    if (!reader.IsDBNull(5))
                        crucero.baja_fuera_servicio = reader.GetBoolean(5);
                    if (!reader.IsDBNull(6))
                        crucero.baja_vida_util = reader.GetBoolean(6);
                    if (!reader.IsDBNull(7))
                        crucero.fecha_fuera_servicio = reader.GetDateTime(7);
                    if (!reader.IsDBNull(8))
                        crucero.fecha_reinicio_servicio = reader.GetDateTime(8);
                    if (!reader.IsDBNull(9))
                        crucero.fecha_baja_definitiva = reader.GetDateTime(9);
                }
            }

            reader.Close();
            return crucero;
        }

        public static bool EsValidoIdCrucero(String id_crucero)
        {
            bool resultado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = id_crucero;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.VALIDAR_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);

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

        public static bool ValidarViajesPendientes(String id_crucero, DateTime fechabaja)
        {
            bool resultado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = id_crucero;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_baja", SqlDbType.DateTime, 100);
            parametro.Value = fechabaja;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.VALIDAR_VIAJES_PENDIENTES", DataBase.Tipos.StoredProcedure, parametros);

            if (reader.HasRows)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            reader.Close();


            return resultado;
        }

        public static void CrearCrucero(Crucero crucero)
        {
            List<SqlParameter> parametros = PrepararParametros(crucero);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void ModificarCrucero(Crucero crucero)
        {
            List<SqlParameter> parametros = PrepararParametrosModificar(crucero);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);
        }

        private static List<SqlParameter> PrepararParametrosModificar(Crucero crucero)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = crucero.id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_mod", SqlDbType.VarChar, 50);
            parametro.Value = crucero.mod;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fab_id", SqlDbType.Int, 100);
            parametro.Value = crucero.fab_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_tser_id", SqlDbType.Int, 100);
            parametro.Value = crucero.tser_id;
            parametros.Add(parametro);

            return parametros;

        }

        private static List<SqlParameter> PrepararParametros(Crucero crucero)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.Char, 30);
            parametro.Value = crucero.id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_mod", SqlDbType.VarChar, 50);
            parametro.Value = crucero.mod;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fab_id", SqlDbType.Int, 100);
            parametro.Value = crucero.fab_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_tser_id", SqlDbType.Int, 100);
            parametro.Value = crucero.tser_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cru_fecha_alta", SqlDbType.DateTime, 100);
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            parametro.Value = fechaSistema;
            parametros.Add(parametro);

            return parametros;

        }
    }
}
