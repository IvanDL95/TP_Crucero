using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace MiLibreria
{
    public class DataBase
    {
        public static string fechasistema = ConfigurationManager.AppSettings["FechaSistema"];

        public static SqlConnection conexion = new SqlConnection();
        public static string cadenaDeConexion = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;

        public static SqlConnection ObtenerConexion()
        {
            if(conexion.State == ConnectionState.Closed)
            {
                conexion.ConnectionString = cadenaDeConexion;
                conexion.Open();
            }

            return conexion;
        }

        public static DateTime ObtenerFechaSistema()
        {
            try
            {
                DateTime fecha = DateTime.Parse(fechasistema.ToString());
                string fechaString = Convert.ToString(ConfigurationManager.AppSettings["FechaSistema"]);
                fecha = Convert.ToDateTime(fechaString);

                return fecha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public enum Tipos
        {
            StoredProcedure,
            TableDirect,
            Text
        }

        public static SqlDataReader ObtenerUnDataReader(string query, Tipos tipo, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;

            foreach(SqlParameter p in parametros)
            {
                comando.Parameters.Add(p);
            }

            switch(tipo)
            {
                case Tipos.StoredProcedure: comando.CommandType = CommandType.StoredProcedure; break;
                case Tipos.TableDirect: comando.CommandType = CommandType.TableDirect; break;
                case Tipos.Text: comando.CommandType = CommandType.Text; break;
                default : break;
            }

            comando.Connection = ObtenerConexion();

            SqlDataReader reader = comando.ExecuteReader();

            return reader;
        }

        public static DataSet ObtenerUnDataSet(string query, Tipos tipo, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;

            foreach (SqlParameter p in parametros)
            {
                comando.Parameters.Add(p);
            }

            switch (tipo)
            {
                case Tipos.StoredProcedure: comando.CommandType = CommandType.StoredProcedure; break;
                case Tipos.TableDirect: comando.CommandType = CommandType.TableDirect; break;
                case Tipos.Text: comando.CommandType = CommandType.Text; break;
                default: break;  
            }

            comando.Connection = ObtenerConexion();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);

            return ds;
        }

        public static SqlDataReader ObtenerUnDataReader(string query)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            return ObtenerUnDataReader(query, Tipos.Text, parametros);
        }

        public static DataSet ObtenerUnDataSet(string query)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            return ObtenerUnDataSet(query, Tipos.Text, parametros);
        }

        public static int queryForInt(string query, Tipos tipo, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;

            foreach (SqlParameter p in parametros)
            {
                comando.Parameters.Add(p);
            }

            switch (tipo)
            {
                case Tipos.StoredProcedure: comando.CommandType = CommandType.StoredProcedure; break;
                case Tipos.TableDirect: comando.CommandType = CommandType.TableDirect; break;
                case Tipos.Text: comando.CommandType = CommandType.Text; break;
                default : break;  
            }

            comando.Connection = ObtenerConexion();

            int resultado = Convert.ToInt32(comando.ExecuteScalar());

            return resultado;
        }

        public static int queryForInt(string query)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            return queryForInt(query, Tipos.Text, parametros);
        }

        public static void EscribirEnLaBase(string query, Tipos tipo, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;

            foreach(SqlParameter p in parametros)
            {
                comando.Parameters.Add(p);
            }

            switch(tipo)
            {
                case Tipos.Text : comando.CommandType = CommandType.Text; break;
                case Tipos.StoredProcedure : comando.CommandType = CommandType.StoredProcedure; break;
                default: break;
            }

            comando.Connection = ObtenerConexion();
            comando.ExecuteReader().Close();
            comando.Parameters.Clear();
        }

        public static void EscribirEnLaBase(string query)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            EscribirEnLaBase(query,Tipos.Text,parametros);
        }

    }


}
