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
        public static SqlDataReader ObtenerRecorrido(int? id_recorrido)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
            if (!id_recorrido.HasValue || id_recorrido == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = id_recorrido;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static int CrearRecorrido(Recorrido recorrido)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@rec_pue_desde", SqlDbType.Int, 30);
            parametro.Value = recorrido.rec_pue_id_desde;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_hasta", SqlDbType.Int, 30);
            parametro.Value = recorrido.rec_pue_id_hasta;
            parametros.Add(parametro);

            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.CREAR_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);

            int id = 0;
            if (reader.HasRows)
            {
                reader.Read();
                id = Convert.ToInt32(reader.GetDecimal(0));
            }

            return id;
        }

        public static DataSet ListarRecorridosExistentes(int? rec_id, int? rec_pue_desde, int? rec_pue_hasta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
            if (!rec_id.HasValue || rec_id == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_desde", SqlDbType.Int, 50);
            if (!rec_pue_desde.HasValue || rec_pue_desde == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_pue_desde;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_hasta", SqlDbType.Int, 100);
            if (!rec_pue_hasta.HasValue || rec_pue_hasta == 0)
                parametro.Value = DBNull.Value;
            else
                parametro.Value = rec_pue_hasta;
            parametros.Add(parametro);

            /*if (!String.IsNullOrEmpty(rec_pue_hasta))
                parametro.Value = rec_pue_hasta;
            */
            DataSet ds =  DataBase.ObtenerUnDataSet("TROLLS.LISTAR_RECORRIDOS", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }
		
        public static void ModificarRecorrido(Recorrido recorrido)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;

            parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
            parametro.Value = recorrido.rec_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_desde", SqlDbType.Int, 30);
            parametro.Value = recorrido.rec_pue_id_desde;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_pue_hasta", SqlDbType.Int, 30);
            parametro.Value = recorrido.rec_pue_id_hasta;
            parametros.Add(parametro);

            parametro = new SqlParameter("@rec_estado", SqlDbType.Bit, 2);
            parametro.Value = 1;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void DarDeBajaUnRecorrido(int? rec_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
            parametro.Value = rec_id;
            parametros.Add(parametro);

            /*
            parametro = new SqlParameter("@motivo", SqlDbType.VarChar, 50);
            parametro.Value = "Se dio de baja el recorrido";
            parametros.Add(parametro);
            */

            DataBase.EscribirEnLaBase("TROLLS.BAJA_RECORRIDO", DataBase.Tipos.StoredProcedure, parametros);
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

        public static void InsertarRecorridoTramo(int rec_id, List<Tramo> tramosList)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            Int32 tramosListLenght = tramosList.Count;

            for (int i = 0; i < tramosListLenght; i++)
            {
                parametros.Clear();

                parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
                parametro.Value = rec_id;
                parametros.Add(parametro);

                parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
                parametro.Value = tramosList.ElementAt(i).id;
                parametros.Add(parametro);

                DataBase.EscribirEnLaBase("TROLLS.INSERTAR_RECORRIDO_X_TRAMO", DataBase.Tipos.StoredProcedure, parametros);
            }
        }

        public static void ModificarRecorridoTramo(int rec_id, List<Tramo> tramosList)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
			List<SqlParameter> parametros2 = new List<SqlParameter>();

            SqlParameter parametro;

            Int32 tramosListLenght = tramosList.Count;

            for (int i = 0; i < tramosListLenght; i++)
            {
                parametros.Clear();

                parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
                parametro.Value = rec_id;
                parametros.Add(parametro);
                parametros2.Add(parametro);

                parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
                parametro.Value = tramosList.ElementAt(i).id;
                parametros.Add(parametro);
                parametros2.Add(parametro);

                parametro = new SqlParameter("@estado", SqlDbType.Bit, 2);
                parametro.Value = 1;
                parametros2.Add(parametro);

                SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_RECORRIDO_X_TRAMO", DataBase.Tipos.StoredProcedure, parametros);

                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        parametros.Clear();
                        
                        parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
                        parametro.Value = rec_id;
                        parametros.Add(parametro);

                        parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
                        parametro.Value = tramosList.ElementAt(i).id;
                        parametros.Add(parametro);

                        DataBase.EscribirEnLaBase("TROLLS.INSERTAR_RECORRIDO_X_TRAMO", DataBase.Tipos.StoredProcedure, parametros);
                    }
                        
                    else
                        DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_RECORRIDO_TRAMO", DataBase.Tipos.StoredProcedure, parametros2);
                }
                else
                {
                    parametros.Clear();

                    parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
                    parametro.Value = rec_id;
                    parametros.Add(parametro);

                    parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
                    parametro.Value = tramosList.ElementAt(i).id;
                    parametros.Add(parametro);

                    DataBase.EscribirEnLaBase("TROLLS.INSERTAR_RECORRIDO_X_TRAMO", DataBase.Tipos.StoredProcedure, parametros);
                }
            }
        }

        public static void BorrarRecorridoTramo(int rec_id, Queue<Tramo> listaTramos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            Int32 tramosListLenght = listaTramos.Count;

            for (int i = 0; i < tramosListLenght; i++)
            {
                parametros.Clear();

                parametro = new SqlParameter("@rec_id", SqlDbType.Int, 30);
                parametro.Value = rec_id;
                parametros.Add(parametro);

                parametro = new SqlParameter("@tra_id", SqlDbType.Int, 30);
                parametro.Value = listaTramos.Dequeue();
                parametros.Add(parametro);

                parametro = new SqlParameter("@estado", SqlDbType.Bit, 2);
                parametro.Value = 0;
                parametros.Add(parametro);

                DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_RECORRIDO_TRAMO", DataBase.Tipos.StoredProcedure, parametros);
            }
        }

    }
}
