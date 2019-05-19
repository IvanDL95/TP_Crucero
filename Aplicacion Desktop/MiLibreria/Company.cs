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
    public class Company
    {
        public static DataSet ListarEmpresasExistentes(String razon, String mail, String cuit)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@EMP_RAZON_SOCIAL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(razon))
            {
                parametro.Value = razon;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_MAIL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(mail))
            {
                parametro.Value = mail;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_CUIT", SqlDbType.Char, 12);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(cuit))
            {
                parametro.Value = cuit;
            }
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("RJT.LISTAR_EMPRESAS_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static Int32 ObtenerIDEmpresa(string cuit)
        {
            Int32 ID = -1;
            String query = "SELECT EMP_ID FROM RJT.EMPRESA WHERE EMP_CUIT = '" + cuit + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDDireccionEmpresa(Int32 id)
        {
            Int32 ID = -1;
            String query = "SELECT EMP_DIRECCION FROM RJT.EMPRESA WHERE EMP_ID = '" + id + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerEmpresa(Int32 id_empresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_empresa;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("RJT.OBTENER_EMPRESA", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Empresa ObtenerEmpresaDesdeUnReader(SqlDataReader reader)
        {
            Empresa empresa = new Empresa();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        empresa.RazonSocial = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        empresa.Cuit = reader.GetString(1);
                }
            }

            reader.Close();
            return empresa;
        }
        public static bool EsValidoCuitModif(string cuit, string cuit_base)
        {
            bool resultado;
            if (!String.Equals(cuit, cuit_base))
            {
                SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.EMPRESA WHERE EMP_CUIT = '" + cuit + "'");
                if (reader.HasRows)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
                reader.Close();
            }
            else
                resultado = true;
           
            return resultado;
        }

        public static bool EsValidoRazonSocialModif(string rs, string rs_base)
        {
            bool resultado;
            if (!String.Equals(rs, rs_base))
            {
                SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.EMPRESA WHERE EMP_RAZON_SOCIAL = '" + rs + "'");
                if (reader.HasRows)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
                reader.Close();
            }
            else
                resultado = true;         
            return resultado;
        }

        public static bool EsValidoCuit(string cuit)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.EMPRESA WHERE EMP_CUIT = '" + cuit + "'");
            bool resultado;
            if (reader.HasRows)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }
            reader.Close();
            return resultado;
        }

        public static bool EsValidoRazonSocial(string rs)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.EMPRESA WHERE EMP_RAZON_SOCIAL = '" + rs + "'");
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

        public static void CrearEmpresa(Empresa empresa)
        {
            List<SqlParameter> parametros = PrepararParametros(empresa);

            DataBase.EscribirEnLaBase("RJT.CREAR_EMPRESA", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametros(Empresa empresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;
            parametro = new SqlParameter("@EMP_USU_ID", SqlDbType.Int, 100);
            parametro.Value = empresa.IdUsuario;
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_RAZON_SOCIAL", SqlDbType.VarChar, 50);
            parametro.Value = empresa.RazonSocial;
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_CUIT", SqlDbType.Char, 11);
            parametro.Value = empresa.Cuit;
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_DIRECCION", SqlDbType.Int, 100);
            parametro.Value = empresa.IdDireccion;
            parametros.Add(parametro);

            return parametros;

        }

        private static List<SqlParameter> PrepararParametrosModif(Empresa empresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@EMP_ID", SqlDbType.Int, 100);
            parametro.Value = empresa.Id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_RAZON_SOCIAL", SqlDbType.VarChar, 50);
            parametro.Value = empresa.RazonSocial;
            parametros.Add(parametro);

            parametro = new SqlParameter("@EMP_CUIT", SqlDbType.Char, 11);
            parametro.Value = empresa.Cuit;
            parametros.Add(parametro);

            return parametros;

        }

        public static void ModificarEmpresa(Empresa empresa)
        {
            List<SqlParameter> parametros = PrepararParametrosModif(empresa);
            DataBase.EscribirEnLaBase("RJT.MODIFICAR_EMPRESA", DataBase.Tipos.StoredProcedure, parametros);
        }
    }
}
