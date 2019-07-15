using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using MiLibreria.Modelo;


namespace MiLibreria
{
    public class Role
    {
        public static void LLenarDGV(DataGridView dgv)
        {
            dgv.DataSource = DataBase.ObtenerUnDataSet("SELECT * FROM TROLLS.ROL").Tables[0];
        }

        public static void BuscarRol(DataGridView dgv, string palabra)
        {
            dgv.DataSource = DataBase.ObtenerUnDataSet("SELECT * FROM TROLLS.ROL WHERE ROL_NOMBRE LIKE '%" + palabra + "%'").Tables[0];
        }

        public static Int32 DameIdRol(String nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@nombre", nombre));
            int resultado = DataBase.queryForInt("TROLLS.OBTENER_ID_X_NOMBRE", DataBase.Tipos.StoredProcedure, parametros);

            DataBase.CerrarConexion();

            return resultado;
        }

        public static void GuardarRol(Rol unRol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@NOMBRE", SqlDbType.VarChar, 25);
            parametro.Value = unRol.nombre;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ESTADO", SqlDbType.Bit);
            parametro.Value = unRol.estado;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.GUARDAR_ROL", DataBase.Tipos.StoredProcedure, parametros);
            
        }

        public static void CrearRolxUsuario(int rol,int idUser)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@USU_ID", SqlDbType.Int, 100);
            parametro.Value = idUser;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ROL_ID", SqlDbType.Int, 100);
            parametro.Value = rol;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.CREAR_ROLXUSUARIO", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void EliminarRol(Int32 id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID", id));

            DataBase.EscribirEnLaBase("TROLLS.ELIMINAR_ROL",DataBase.Tipos.StoredProcedure,parametros);
        }

        public static void AgregarFuncionalidad(Rol unRol, Funcion funcion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ID_Rol", SqlDbType.Int, 100);
            parametro.Value = unRol.id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ID_Funcionalidad", SqlDbType.Int, 100);
            parametro.Value = funcion.Id;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.AGREGAR_FUNCIONALIDAD_A_ROL", DataBase.Tipos.StoredProcedure, parametros);
        }

        public static void QuitarFuncionalidad(Rol unRol, Funcion funcion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@ID_Rol", SqlDbType.Int, 100);
            parametro.Value = unRol.id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@ID_Funcionalidad", SqlDbType.Int, 100);
            parametro.Value = funcion.Id;
            parametros.Add(parametro);

            DataBase.EscribirEnLaBase("TROLLS.ELIMINAR_FUNCIONALIDAD_A_ROL", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ActualizarNombre(Int32 id, String nuevoNombre,Boolean habilitado)
        {
            Int32 estado;

            if(habilitado)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }

            DataBase.EscribirEnLaBase("UPDATE TROLLS.ROL SET ROL_ESTADO = " + estado.ToString() + ", ROL_NOMBRE = '" + nuevoNombre + "' WHERE ROL_ID = " + id.ToString());
        }
    }
}
