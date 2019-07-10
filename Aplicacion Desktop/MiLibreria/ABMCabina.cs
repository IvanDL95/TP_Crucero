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
    public class ABMCabina
    {
        public static DataTable ObtenerUbicaciones(Int32 id_publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_UBICACIONES", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static Int32 ObtenerIDTipo(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT TCAB_ID FROM TROLLS.TIPO_CABINA WHERE TCAB_TIPO = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerDescTipo(Int32 id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERDESCTIPOCABINA", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static decimal ObtenerPrecioRecorrido(Int32 rec_id, Int32 pue_id_desde, Int32 pue_id_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@REC_ID", SqlDbType.Int, 100);
            parametro.Value = rec_id;
            parametros.Add(parametro);
            parametro = new SqlParameter("@PUE_ID_DESDE", SqlDbType.Int, 100);
            parametro.Value = pue_id_desde;
            parametros.Add(parametro);
            parametro = new SqlParameter("@PUE_ID_HASTA", SqlDbType.Int, 100);
            parametro.Value = pue_id_hasta;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERPRECIORECORRIDO", DataBase.Tipos.StoredProcedure, parametros);

            decimal precio=0;
            if (reader.Read())
            {
                precio = reader.GetDecimal(0);
            }

            return precio;
        }

        public static decimal ObtenerPorc(Int32 id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERPORCTIPOCABINA", DataBase.Tipos.StoredProcedure, parametros);

            decimal porc = 0;

            if (reader.Read())
            {
                porc = reader.GetDecimal(0);
            }

            return porc;
        }

        public static SqlDataReader ObtenerTipos()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERTIPOSUBICACION", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataTable ObtenerCabinasSinCompra(Int32 id_viaje, Int32 idTipo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_viaje;
            parametros.Add(parametro);
            parametro = new SqlParameter("@tcab_id", SqlDbType.Int, 100);
            parametro.Value = idTipo;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_CABINAS_SIN_COMPRA", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static void CrearUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametros(ubicacion);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_UBICACION", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ModificarUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosModificar(ubicacion);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_UBICACION", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametrosModificar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ubi_id", SqlDbType.Int);
            parametro.Value = ubicacion.ubi_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_tipo", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_tipo;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_precio", SqlDbType.Decimal);
            parametro.Value = ubicacion.ubi_precio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_sin_numerar", SqlDbType.Bit);
            parametro.Value = ubicacion.ubi_sin_numerar;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_asiento", SqlDbType.VarChar);

            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(ubicacion.ubi_asiento))
            {
                parametro.Value = ubicacion.ubi_asiento;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_fila", SqlDbType.VarChar);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(ubicacion.ubi_fila))
            {
                parametro.Value = ubicacion.ubi_fila;
            }
            parametros.Add(parametro);
            return parametros;

        }

        private static List<SqlParameter> PrepararParametros(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ubi_tipo", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_tipo;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_precio", SqlDbType.Decimal);
            parametro.Value = ubicacion.ubi_precio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_sin_numerar", SqlDbType.Bit);
            parametro.Value = ubicacion.ubi_sin_numerar;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_asiento", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_asiento;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_fila", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_fila;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_pub", SqlDbType.Int);
            parametro.Value = ubicacion.ubi_pub;
            parametros.Add(parametro);

            return parametros;

        }

        public static void CrearUbicacionSinNumerar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosSinNumerar(ubicacion);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_UBICACION_SIN_NUMERAR", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ModificarUbicacionSinNumerar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosSinNumerarModificar(ubicacion);

            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_UBICACION_SIN_NUMERAR", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametrosSinNumerarModificar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ubi_id", SqlDbType.Int);
            parametro.Value = ubicacion.ubi_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_tipo", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_tipo;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_precio", SqlDbType.Decimal);
            parametro.Value = ubicacion.ubi_precio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_sin_numerar", SqlDbType.Bit);
            parametro.Value = ubicacion.ubi_sin_numerar;
            parametros.Add(parametro);

            return parametros;
        }

        private static List<SqlParameter> PrepararParametrosSinNumerar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ubi_tipo", SqlDbType.VarChar);
            parametro.Value = ubicacion.ubi_tipo;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_precio", SqlDbType.Decimal);
            parametro.Value = ubicacion.ubi_precio;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_sin_numerar", SqlDbType.Bit);
            parametro.Value = ubicacion.ubi_sin_numerar;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ubi_pub", SqlDbType.Int);
            parametro.Value = ubicacion.ubi_pub;
            parametros.Add(parametro);

            return parametros;

        }
    }
}
