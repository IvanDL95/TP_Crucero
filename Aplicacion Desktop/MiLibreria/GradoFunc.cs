using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MiLibreria
{
    public class GradoFunc
    {
        public static SqlDataReader ObtenerGrados()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERGRADOS", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static DataSet ListarGradosExistentes()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_GRADOS_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);
            return ds;
        }

        public static SqlDataReader ObtenerGrado(Int32 id_grado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_grado;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_GRADO", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Grado ObtenerGradoDesdeUnReader(SqlDataReader reader)
        {
            Grado grado = new Grado();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        grado.gra_id = Convert.ToInt32(reader.GetDecimal(0));
                    if (!reader.IsDBNull(1))
                        grado.gra_desc = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        grado.gra_comision = Convert.ToInt32(reader.GetDecimal(2));
                    if (!reader.IsDBNull(3))
                        grado.gra_peso = reader.GetInt32(3);
                }
            }

            reader.Close();
            return grado;
        }

        public static void AltaGrado(Grado grado)
        {
            List<SqlParameter> parametros = PrepararParametros(grado);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_GRADO", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametros(Grado grado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@GRA_PESO", SqlDbType.Int, 100);
            parametro.Value = grado.gra_peso;
            parametros.Add(parametro);

            parametro = new SqlParameter("@GRA_DESC", SqlDbType.VarChar, 30);
            parametro.Value = grado.gra_desc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@GRA_COMISION", SqlDbType.Int, 100);
            parametro.Value = grado.gra_comision;
            parametros.Add(parametro);

            return parametros;

        }

        public static void ModificarGrado(Grado grado)
        {
            List<SqlParameter> parametros = PrepararParametros(grado);

            SqlParameter parametro;

            parametro = new SqlParameter("@GRA_ID", SqlDbType.Int, 100);
            parametro.Value = grado.gra_id;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_GRADO", DataBase.Tipos.StoredProcedure, parametros);

        }

    }
}
