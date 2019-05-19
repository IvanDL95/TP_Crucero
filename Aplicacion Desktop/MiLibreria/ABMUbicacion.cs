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
    public class ABMUbicacion
    {
        public static DataTable ObtenerUbicaciones(Int32 id_publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("RJT.OBTENER_UBICACIONES", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static Int32 ObtenerIDTipo(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT TU_ID FROM RJT.TIPOUBICACION WHERE TU_DESC = '" + desc + "'";
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
            SqlDataReader reader = DataBase.ObtenerUnDataReader("RJT.OBTENERDESCTIPOUBICACION", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static SqlDataReader ObtenerTipos()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("RJT.OBTENERTIPOSUBICACION", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataTable ObtenerUbicacionesSinCompra(Int32 id_publicacion, Int32 idTipo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);
            parametro = new SqlParameter("@ubi_tipo", SqlDbType.Int, 100);
            parametro.Value = idTipo;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("RJT.OBTENER_UBICACIONES_SIN_COMPRA", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static void CrearUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametros(ubicacion);
            DataBase.EscribirEnLaBase("RJT.CREAR_UBICACION", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ModificarUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosModificar(ubicacion);
            DataBase.EscribirEnLaBase("RJT.MODIFICAR_UBICACION", DataBase.Tipos.StoredProcedure, parametros);

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

            DataBase.EscribirEnLaBase("RJT.CREAR_UBICACION_SIN_NUMERAR", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ModificarUbicacionSinNumerar(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosSinNumerarModificar(ubicacion);

            DataBase.EscribirEnLaBase("RJT.MODIFICAR_UBICACION_SIN_NUMERAR", DataBase.Tipos.StoredProcedure, parametros);

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
