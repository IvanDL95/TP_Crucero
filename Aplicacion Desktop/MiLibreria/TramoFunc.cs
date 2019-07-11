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
    public class TramoFunc
    {
        public static DataTable ObtenerTramos(int? rec_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
            parametro.Value = rec_id;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_TRAMOS ", DataBase.Tipos.StoredProcedure, parametros);
            return ds.Tables[0];
        }
		
		public static DataTable ObtenerTramos()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_TRAMOS ", DataBase.Tipos.StoredProcedure, parametros);
            return ds.Tables[0];
        }

        public static int ValidarTramo(Tramo tramo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@tra_desde", SqlDbType.Int, 30);
            parametro.Value = tramo.salida_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@tra_hasta", SqlDbType.Int, 30);
            parametro.Value = tramo.destino_id;
            parametros.Add(parametro);
			
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_TRAMOS", DataBase.Tipos.StoredProcedure, parametros);

			Int32 tramoId = 0;
            if (reader.HasRows)
            {
                reader.Read();
                if (!reader.IsDBNull(0))
                    tramoId = CrearTramo(tramo);
                else
                {
                    tramoId = Convert.ToInt32(reader.GetDecimal(0));
                    tramo.id = tramoId;
                    ModificarTramo(tramo);
                }
            }
			else
                tramoId = CrearTramo(tramo);

            return tramoId;
        }

		public static int CrearTramo(Tramo tramo)
		{
			List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
			
			parametro = new SqlParameter("@tra_desde", SqlDbType.Int, 30);
            parametro.Value = tramo.salida_id;
			parametros.Add(parametro);

			parametro = new SqlParameter("@tra_hasta", SqlDbType.Int, 30);
			parametro.Value = tramo.destino_id;
			parametros.Add(parametro);

            parametro = new SqlParameter("@tra_precio_base", SqlDbType.Decimal, 30);
			parametro.Value = tramo.precio;
			parametros.Add(parametro);
				
			SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.INSERTAR_TRAMO", DataBase.Tipos.StoredProcedure, parametros);

            Int32 tra_id = 0;
			if (reader.HasRows)
            {
				reader.Read();
				tra_id = Convert.ToInt32(reader.GetDecimal(0));
			}
			
			return tra_id;
		}

        public static void ModificarTramo(Tramo tramo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
            parametro.Value = tramo.id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@tra_precio_base", SqlDbType.Decimal, 30);
            parametro.Value = tramo.precio;
            parametros.Add(parametro);

            // AKTUALISAR Z  ACTUALIZAR
            DataBase.EscribirEnLaBase("TROLLS.ACTUALIZAR_TRAMO", DataBase.Tipos.StoredProcedure, parametros);
        }

    }
}
