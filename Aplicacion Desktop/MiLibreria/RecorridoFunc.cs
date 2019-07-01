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
    public class RecorridoFunc
    {
        public static SqlDataReader ObtenerRubros()
        {
            return null;
        }
        //public static SqlDataReader ObtenerRecorrido()
        public static SqlDataReader ObtenerRecorrido(int id_recorrido)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.VarChar, 30);
            parametro.Value = id_recorrido;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static DataTable ObtenerTramos()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_TRAMOS", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static DataSet ListarRecorridosExistentes(int? rec_id, int? rec_pue_desde, int? rec_pue_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@rec_id", SqlDbType.VarChar, 30);
            if (!rec_id.HasValue || rec_id == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_desde", SqlDbType.VarChar, 50);
            if (!rec_id.HasValue || rec_id == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_hasta", SqlDbType.Int, 100);
            if (!rec_id.HasValue || rec_id == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_id;
            parametros.Add(parametro);

            /*if (!String.IsNullOrEmpty(rec_pue_hasta))
                parametro.Value = rec_pue_hasta;
            */
            return DataBase.ObtenerUnDataSet("TROLLS.LISTAR_RECORRIDOS", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static Recorrido ObtenerRecorridoDesdeUnReader(SqlDataReader reader)
        {
            Recorrido recorrido = new Recorrido();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        recorrido.rec_id = Convert.ToInt32(reader.GetDecimal(0));
                    if (!reader.IsDBNull(1))
                        recorrido.rec_pue_id_desde = Convert.ToInt32(reader.GetDecimal(1));
                    if (!reader.IsDBNull(2))
                        recorrido.rec_pue_id_hasta = Convert.ToInt32(reader.GetDecimal(2));
                    if (!reader.IsDBNull(3))
                        recorrido.rec_estado = reader.GetBoolean(3);
                }
            }
            reader.Close();
            return recorrido;
        }


        public static void DarDeBajaUnRecorrido(int? rec_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter("@rec_id", SqlDbType.VarChar, 30);
            parametros.Add(parametro);

            DataBase.ObtenerUnDataSet("TROLLS.BAJA_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);
        }

    }
}
