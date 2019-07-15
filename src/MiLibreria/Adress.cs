using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiLibreria.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace MiLibreria
{
    public class Adress
    {
        public static void CrearDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = PrepararParametros(direccion);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_DIRECCION", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static int ObtenerIDDireccion(string calle, string num, string tel, string mail)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@DIR_CALLE", calle));
            parametros.Add(new SqlParameter("@DIR_NUM", num));
            parametros.Add(new SqlParameter("@DIR_TELEFONO", tel));
            SqlParameter parametro;
            parametro = new SqlParameter("@DIR_MAIL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(mail))
            {
                parametro.Value = mail;
            }
            parametros.Add(parametro);

            int id = DataBase.queryForInt("TROLLS.OBTENER_ID_DIRECCION", DataBase.Tipos.StoredProcedure, parametros);

            return id;
        }

        public static int ObtenerIDDireccion(string calle, string num, string tel)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@DIR_CALLE", calle));
            parametros.Add(new SqlParameter("@DIR_NUM", num));
            parametros.Add(new SqlParameter("@DIR_TELEFONO", tel));

            int id = DataBase.queryForInt("TROLLS.OBTENER_ID_DIRECCION_SIN_MAIL", DataBase.Tipos.StoredProcedure, parametros);

            return id;
        }

        public static bool ValidaDireccion(string calle, string num, string tel, string mail)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader(String.Concat("SELECT 1 FROM TROLLS.DIRECCION WHERE DIR_CALLE = '",calle,"' AND DIR_NUM = '",num,"' AND DIR_TELEFONO = '",tel,"' AND DIR_MAIL = '",mail,"'"));
            bool resultado;
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

        public static SqlDataReader ObtenerDireccion(int id_dir)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID", id_dir));
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_DIRECCION", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Direccion ObtenerDireccionDesdeUnReader(SqlDataReader reader)
        {
            Direccion direccion = new Direccion();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        direccion.Calle = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        direccion.Numero = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        direccion.Telefono = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        direccion.Mail = reader.GetString(3);
                }
            }

            reader.Close();
            return direccion;
        }

        private static List<SqlParameter> PrepararParametros(Direccion direccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@DIR_CALLE", SqlDbType.VarChar, 70);
            parametro.Value = direccion.Calle;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_NUM", SqlDbType.Char, 5);
            parametro.Value = direccion.Numero;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_TELEFONO", SqlDbType.VarChar, 18);
            parametro.Value = direccion.Telefono;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_MAIL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(direccion.Mail))
            {
                parametro.Value = direccion.Mail;
            }
            parametros.Add(parametro);

            return parametros;

        }

        private static List<SqlParameter> PrepararParametrosModif(Direccion direccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@DIR_ID", SqlDbType.Int, 100);
            parametro.Value = direccion.Id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_CALLE", SqlDbType.VarChar, 70);
            parametro.Value = direccion.Calle;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_NUM", SqlDbType.Char, 5);
            parametro.Value = direccion.Numero;
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_TELEFONO", SqlDbType.VarChar, 18);
            parametro.Value = direccion.Telefono;
            parametros.Add(parametro);


            parametro = new SqlParameter("@DIR_MAIL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(direccion.Mail))
            {
                parametro.Value = direccion.Mail;
            }
            parametros.Add(parametro);

            return parametros;

        }

        public static void ModificarDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = PrepararParametrosModif(direccion);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_DIRECCION", DataBase.Tipos.StoredProcedure, parametros);
        }
    }
}
