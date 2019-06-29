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
    public class ABMPublicacion
    {
        public static DataSet ListarPublicacionesExistentes(Int32 pub_usu, String pub_estado1, String pub_estado2)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@PUB_USU", SqlDbType.Int, 100);
            parametro.Value = pub_usu;
            parametros.Add(parametro);

            parametro = new SqlParameter("@PUB_ESTADO1", SqlDbType.VarChar, 10);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(pub_estado1))
            {
                parametro.Value = pub_estado1;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@PUB_ESTADO2", SqlDbType.VarChar, 10);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(pub_estado2))
            {
                parametro.Value = pub_estado2;
            }
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_PUBLICACIONES_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
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

        public static Int32 ObtenerIDDireccionPublicacion(Int32 id)
        {
            Int32 ID = -1;
            String query = "SELECT PUB_DIR FROM TROLLS.PUBLICACION WHERE PUB_ID = '" + id + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerPublicacion(Int32 id_publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Publicacion ObtenerPublicacionDesdeUnReader(SqlDataReader reader)
        {
            Publicacion publicacion = new Publicacion();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        publicacion.pub_id = Convert.ToInt32(reader.GetDecimal(0));
                    if (!reader.IsDBNull(1))
                        publicacion.pub_estado = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        publicacion.pub_desc = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        publicacion.pub_fecha_pub = reader.GetDateTime(3);
                    if (!reader.IsDBNull(4))
                        publicacion.pub_fecha_espec = reader.GetDateTime(4);
                    if (!reader.IsDBNull(5))
                        publicacion.pub_rubro = Convert.ToInt32(reader.GetDecimal(5));
                    if (!reader.IsDBNull(6))
                        publicacion.pub_dir = Convert.ToInt32(reader.GetDecimal(6));
                    if (!reader.IsDBNull(7))
                        publicacion.pub_grado = Convert.ToInt32(reader.GetDecimal(7));
                    if (!reader.IsDBNull(8))
                        publicacion.pub_usu = Convert.ToInt32(reader.GetDecimal(8));
                }
            }

            reader.Close();
            return publicacion;
        }

        public static bool EsValidoFechaPublicacionAlta(string desc, DateTime fechaHora)
        {
            bool resultado;
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@pub_desc", SqlDbType.VarChar, 400);
            parametro.Value = desc;
            parametros.Add(parametro);
            parametro = new SqlParameter("@pub_fecha_espec", SqlDbType.DateTime);
            parametro.Value = fechaHora;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.VALIDAR_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);

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

        public static bool EsValidoFechaPublicacion(Publicacion publicacionBase, string desc, DateTime fechaHora)
        {
            bool resultado;
            if (publicacionBase != null)           
                if (String.Equals(desc, publicacionBase.pub_desc) && (DateTime.Compare(publicacionBase.pub_fecha_espec, fechaHora) == 0))
                    return false;
             
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    SqlParameter parametro;
                    parametro = new SqlParameter("@pub_desc", SqlDbType.VarChar, 400);
                    parametro.Value = desc;
                    parametros.Add(parametro);
                    parametro = new SqlParameter("@pub_fecha_espec", SqlDbType.DateTime);
                    parametro.Value = fechaHora;
                    parametros.Add(parametro);

                    SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.VALIDAR_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);

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

        public static void CrearPublicacion(Publicacion publicacion)
        {
            List<SqlParameter> parametros = PrepararParametros(publicacion);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void ModificarPublicacion(Publicacion publicacion)
        {
            List<SqlParameter> parametros = PrepararParametrosModificar(publicacion);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void ModificarEstadoPublicacion(int id_publicacion, string pub_estado, DateTime fechaPub)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@pub_id", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);
            parametro = new SqlParameter("@pub_estado", SqlDbType.VarChar, 10);
            parametro.Value = pub_estado;
            parametros.Add(parametro);
            parametro = new SqlParameter("@pub_fecha_pub", SqlDbType.DateTime);
            if (string.Compare(pub_estado, "Publicada") == 0)
            {
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                parametro.Value = fechaSistema;
            }
            else
                parametro.Value = fechaPub;
            parametros.Add(parametro);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_ESTADO_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametrosModificar(Publicacion publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@pub_id", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_estado", SqlDbType.VarChar, 10);
            parametro.Value = publicacion.pub_estado;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_desc", SqlDbType.VarChar, 400);
            parametro.Value = publicacion.pub_desc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_pub", SqlDbType.DateTime, 100);
            if (string.Compare(publicacion.pub_estado,"Borrador")==0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = publicacion.pub_fecha_pub;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_espec", SqlDbType.DateTime, 100);
            parametro.Value = publicacion.pub_fecha_espec;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_rubro", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_rubro;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_gra", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_grado;
            parametros.Add(parametro);

            return parametros;

        }

        private static List<SqlParameter> PrepararParametros(Publicacion publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@pub_estado", SqlDbType.VarChar, 10);
            parametro.Value = publicacion.pub_estado;
            parametros.Add(parametro);
            
            parametro = new SqlParameter("@pub_desc", SqlDbType.VarChar, 400);
            parametro.Value = publicacion.pub_desc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_pub", SqlDbType.DateTime, 100);
            if (string.Compare(publicacion.pub_estado, "Borrador") == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = publicacion.pub_fecha_pub;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_fecha_espec", SqlDbType.DateTime, 100);
            parametro.Value = publicacion.pub_fecha_espec;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_rubro", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_rubro;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_dir", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_dir;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_gra", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_grado;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pub_usu", SqlDbType.Int, 100);
            parametro.Value = publicacion.pub_usu;
            parametros.Add(parametro);

            return parametros;

        }

        public static int ObtenerIDPublicacion(Publicacion publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pub_desc", publicacion.pub_desc));
            parametros.Add(new SqlParameter("@pub_dir", publicacion.pub_dir));
            parametros.Add(new SqlParameter("@pub_usu", publicacion.pub_usu));
            parametros.Add(new SqlParameter("@pub_fecha_espec", publicacion.pub_fecha_espec));

            int id = DataBase.queryForInt("TROLLS.OBTENER_ID_PUBLICACION", DataBase.Tipos.StoredProcedure, parametros);

            return id;
        }
    }
}
