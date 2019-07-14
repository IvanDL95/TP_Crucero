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

        public static Int32 ObtenerIDTipo(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT TCAB_ID FROM TROLLS.TIPO_CABINA WHERE TCAB_TIPO = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDPuerto(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT PUE_ID FROM TROLLS.PUERTO WHERE PUE_NOMBRE = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDViaje(int res_id)
        {
            Int32 ID = -1;
            String query = "SELECT RES_VIA_ID FROM TROLLS.RESERVA WHERE RES_ID = '" + res_id.ToString() + "'";
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

        public static int ObtenerIdCabina(Int32 cab_piso, Int32 cab_nro, Int32 cab_tcab_id, Int32 via_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@cab_piso", SqlDbType.Int, 100);
            parametro.Value = cab_piso;
            parametros.Add(parametro);
            parametro = new SqlParameter("@cab_numero", SqlDbType.Int, 100);
            parametro.Value = cab_nro;
            parametros.Add(parametro);
            parametro = new SqlParameter("@cab_tcab_id", SqlDbType.Int, 100);
            parametro.Value = cab_tcab_id;
            parametros.Add(parametro);
            parametro = new SqlParameter("@via_id", SqlDbType.Int, 100);
            parametro.Value = via_id;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERIDCABINA", DataBase.Tipos.StoredProcedure, parametros);

            int id = 0;
            if (reader.Read())
            {
                id = Convert.ToInt32(reader.GetDecimal(0));
            }

            return id;
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
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.LISTAR_RECORRIDOS", DataBase.Tipos.StoredProcedure, parametros);

            decimal precio=0;
            if (reader.Read())
            {
                precio = reader.GetDecimal(3);
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

    }
}
