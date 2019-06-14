﻿using System;
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
    public class User
    {
        public static int Autenticar(string usuario, string password)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Usuario", usuario));
            parametros.Add(new SqlParameter("@Password", password));
            int resultado = DataBase.queryForInt("RJT.BUSCAR_USUARIO", DataBase.Tipos.StoredProcedure, parametros);

            return resultado;

        }

        public static DataSet ListarUsuariosExistentes()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            DataSet ds = DataBase.ObtenerUnDataSet("RJT.LISTAR_USUARIOS_EXISTENTES", DataBase.Tipos.StoredProcedure, parametros);
            return ds;
        }

        public static void RegistrarIntentoFallido(string user)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Usuario", user));
            DataBase.EscribirEnLaBase("RJT.REG_INTENTO_FALLIDO",DataBase.Tipos.StoredProcedure,parametros);
        }

        public static int CantidadDeRoles(string user)
        {   
            int id = ObtenerIDUsuario(user);
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID_USU",id));
            return DataBase.queryForInt("RJT.OBTENER_CANT_ROLES", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static int ObtenerIDUsuario(string user)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Usuario", user));

            int id = DataBase.queryForInt("RJT.OBTENER_ID_USUARIO", DataBase.Tipos.StoredProcedure, parametros);

            return id;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            List<SqlParameter> parametros = PrepararParametros(usuario);

            DataBase.EscribirEnLaBase("RJT.CREAR_USUARIO", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void CambiarPass(int idUser, string txt_pass)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@USU_ID", SqlDbType.Int, 100);
            parametro.Value = idUser;
            parametros.Add(parametro);


            parametro = new SqlParameter("@USU_PASSWORD", SqlDbType.VarChar, 255);
            parametro.Value = txt_pass;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("RJT.MODIFICAR_CLAVE", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametros(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@USU_USUARIO", SqlDbType.VarChar, 30);
            parametro.Value = usuario.User;
            parametros.Add(parametro);


            parametro = new SqlParameter("@USU_PASSWORD", SqlDbType.VarChar, 255);
            parametro.Value = usuario.Password;
            parametros.Add(parametro);

            parametro = new SqlParameter("@USU_CANT_INT_FALLIDOS", SqlDbType.Int, 100);
            parametro.Value = 0;
            parametros.Add(parametro);

            parametro = new SqlParameter("@USU_ESTADO", SqlDbType.Bit, 1);
            parametro.Value = 1;
            parametros.Add(parametro);

            return parametros;

        }

        public static bool EsValidoUserName(string username)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.USUARIO WHERE USU_USUARIO = '" + username + "'");
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

        public static bool EsUsuarioCliente(Int32 id)
        {
            SqlDataReader reader = DataBase.ObtenerUnDataReader("SELECT 1 FROM RJT.USUARIO u join RJT.ROL_USUARIO rxu ON u.USU_ID = rxu.USU_ID where rxu.rol_id=3 and u.USU_ID = '" + id + "'");
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

    }
}