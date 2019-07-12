using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using MiLibreria;
using System.Data;

namespace MiLibreria
{
    public class PuertoFunc
    {
        public static SqlDataReader ObtenerPuerto()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERPUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataTable ObtenerPuertoList()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENERPUERTO", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static DataTable ObtenerPuerto(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@pue_id", SqlDbType.Int, 30);
            parametro.Value = id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pue_nombre", SqlDbType.VarChar, 100);
            parametro.Value = DBNull.Value;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_PUERTO_DESDE_PARAMETRO", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static DataTable ObtenerPuerto(String nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@pue_id", SqlDbType.Int, 30);
            parametro.Value = DBNull.Value;
            parametros.Add(parametro);

            parametro = new SqlParameter("@pue_nombre", SqlDbType.VarChar, 100);
            parametro.Value = nombre;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_PUERTO_DESDE_PARAMETRO", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static SqlDataReader ObtenerTramos(Puerto puerto, int flag)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
            parametro.Value = 0;
            parametros.Add(parametro);

            if (flag == 0)
            {
                parametro = new SqlParameter("@tra_desde", SqlDbType.Int, 30);
                parametro.Value = puerto.id;
                parametros.Add(parametro);

                parametro = new SqlParameter("@tra_hasta", SqlDbType.Int, 30);
                parametro.Value = 0;
                parametros.Add(parametro);
            }
            else
            {
                parametro = new SqlParameter("@tra_desde", SqlDbType.Int, 30);
                parametro.Value = 0;
                parametros.Add(parametro);

                parametro = new SqlParameter("@tra_hasta", SqlDbType.Int, 30);
                parametro.Value = puerto.id;
                parametros.Add(parametro);
            }


            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_TRAMO_ID", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static Puerto ObtenerPuertoDesdeUnReader(SqlDataReader reader)
        {
            Puerto puerto = new Puerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    if (!reader.IsDBNull(1))
                        puerto.nombre = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        puerto.estado = reader.GetBoolean(2);
                }
            }
            reader.Close();
            return puerto;
        }
    }
}
