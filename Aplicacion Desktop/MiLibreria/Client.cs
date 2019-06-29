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
        public static DataSet ListarClientesExistentes(String nombre, String apellido, String mail, String nroDoc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(nombre))
            {
                parametro.Value = nombre;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(apellido))
            {
                parametro.Value = apellido;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@DIR_MAIL", SqlDbType.VarChar, 50);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(mail))
            {
                parametro.Value = mail;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NRO_DOC", SqlDbType.Char, 10);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(nroDoc))
            {
                parametro.Value = nroDoc;
            }
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_CLIENTES_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static DataSet ListarClientesExistentesInicio(String nombre, String apellido, String nroDoc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(nombre))
            {
                parametro.Value = nombre;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(apellido))
            {
                parametro.Value = apellido;
            }
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NRO_DOC", SqlDbType.Char, 10);
            parametro.Value = DBNull.Value;
            if (!String.IsNullOrEmpty(nroDoc))
            {
                parametro.Value = nroDoc;
            }
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.LISTAR_CLIENTES_EXISTENTES_INICIO", DataBase.Tipos.StoredProcedure, parametros);

            return ds;
        }

        public static Int32 ObtenerIDCliente(Int32 doc)
        {
            Int32 ID = -1;
            String query = "SELECT CLI_ID FROM TROLLS.CLIENTE WHERE CLI_NRO_DOC = '" + doc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDClienteUser(Int32 idUser)
        {
            Int32 ID = -1;
            String query = "SELECT CLI_ID FROM TROLLS.CLIENTE WHERE CLI_USU_ID = '" + idUser + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static Int32 ObtenerIDDireccionCliente(Int32 id)
        {
            Int32 ID = -1;
            String query = "SELECT CLI_DIRECCION FROM TROLLS.CLIENTE WHERE CLI_ID = '" + id + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerPuntosCliente(Int32 id_cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_cliente;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_PUNTOS_CLIENTE", DataBase.Tipos.StoredProcedure, parametros);
            return reader;
        }

        public static SqlDataReader ObtenerCliente(Int32 id_cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_cliente;
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
                    if (!reader.IsDBNull(3))
                        cliente.NroDoc = reader.GetString(3);
                    if (!reader.IsDBNull(6))
                    cliente.FechaNac = reader.GetDateTime(6);
                }
            }

            reader.Close();
            return cliente;
        }

        public static bool ValidaTarjeta(Int32 idCliente)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_TARJ is not null and CLI_ID = '" + idCliente + "'");
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
        public static bool EsValidoCuil(string cuil)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM TROLLS.CLIENTE WHERE CLI_CUIL = '" + cuil + "'");
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

        public static void CrearTarjeta(Int32 idCliente,String txtTarj){
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@cli_id", SqlDbType.Int, 100);
            parametro.Value = idCliente;
            parametros.Add(parametro);
            parametro = new SqlParameter("@cli_tarj", SqlDbType.Char, 19);
            parametro.Value = txtTarj;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_TARJETA", DataBase.Tipos.StoredProcedure, parametros);
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


            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Nombre;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Apellido;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NRO_DOC", SqlDbType.Char, 10);
            parametro.Value = cliente.NroDoc;
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

            parametro = new SqlParameter("@CLI_USU_ID", SqlDbType.Int, 100);
            parametro.Value = cliente.IdUsuario;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NOMBRE", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Nombre;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_APELLIDO", SqlDbType.VarChar, 30);
            parametro.Value = cliente.Apellido;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_NRO_DOC", SqlDbType.Char, 10);
            parametro.Value = cliente.NroDoc;
            parametros.Add(parametro);

            parametro = new SqlParameter("@CLI_FECHA_NAC", SqlDbType.DateTime, 100);
            parametro.Value = cliente.FechaNac;
            parametros.Add(parametro);
            //Fecha creacion

            parametro = new SqlParameter("@CLI_DIRECCION", SqlDbType.Int, 100);
            parametro.Value = cliente.IdDireccion;
            parametros.Add(parametro);

            return parametros;

        }
    }
}
