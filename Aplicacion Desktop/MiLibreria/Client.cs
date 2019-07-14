using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;
using MiLibreria.Modelo;
using System.Data;

namespace MiLibreria
{
    public class Client
    {

        public static Int32 ExisteDoc(Int32 doc, Int32 tipoDoc)
        {
            Int32 ID = -1;
            String query = "SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_ID = '" + doc + "' AND CLI_TDOC_ID = '" + tipoDoc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDCliente(Int32 doc, Int32 tipoDoc)
        {
            Int32 ID = -1;
            String query = "SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_ID = '" + doc + "' AND CLI_TDOC_ID = '" + tipoDoc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDTipoDoc(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT TDOC_ID FROM TROLLS.TIPO_DOC WHERE TDOC_DESC = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDDireccionCliente(Int32 id, Int32 tipoDoc)
        {
            Int32 ID = -1;
            String query = "SELECT CLI_DIRECCION FROM TROLLS.CLIENTE WHERE CLI_ID = '" + id + "' AND CLI_TDOC_ID = '" + tipoDoc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerCliente(Int32 id_cliente, Int32 tipoDoc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_cliente;
            parametros.Add(parametro);
            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Int, 100);
            parametro.Value = tipoDoc;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_CLIENTE", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static Cliente ObtenerClienteDesdeUnReader(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    cliente.Apellido = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                    cliente.Nombre = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    cliente.FechaNac = reader.GetDateTime(2);
                    if (!reader.IsDBNull(3))
                    cliente.IdDireccion = Convert.ToInt32(reader.GetDecimal(3));
                }
            }

            reader.Close();
            return cliente;
        }

        public static bool EsValidoDoc(string nro_doc, string tipo)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_NRO_DOC = '" + nro_doc + "' AND CLI_TIPO_DOC = '" + tipo + "'");
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


        public static bool EsValidoDocModif(string nro_doc,string nro_doc_base)
        {
            bool resultado;
            if (!(String.Equals(nro_doc, nro_doc_base)))
            {
                SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_NRO_DOC = '" + nro_doc + "'");
                
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


        public static void ModificarCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = PrepararParametrosModificar(cliente);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_CLIENTE", DataBase.Tipos.StoredProcedure, parametros);
        }

        private static List<SqlParameter> PrepararParametrosModificar(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@CLI_ID", SqlDbType.Char, 10);
            parametro.Value = cliente.NroDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Char, 10);
            parametro.Value = cliente.TipoDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Nombre;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Apellido;
            parametros.Add(parametro);         

            parametro = new SqlParameter("@CLI_FECHA_NAC", SqlDbType.DateTime, 100);
            parametro.Value = cliente.FechaNac;
            parametros.Add(parametro);

            return parametros;

        }

        public static void CrearCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = PrepararParametros(cliente);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_CLIENTE", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametros(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@CLI_ID", SqlDbType.Int, 100);
            parametro.Value = cliente.NroDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cli_tdoc_id", SqlDbType.Char, 10);
            parametro.Value = cliente.TipoDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Nombre;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Apellido;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_FECHA_NAC", SqlDbType.DateTime, 100);
            parametro.Value = cliente.FechaNac;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_DIRECCION", SqlDbType.Int, 100);
            parametro.Value = cliente.IdDireccion;
            parametros.Add(parametro);

            return parametros;

        }
    }
}
