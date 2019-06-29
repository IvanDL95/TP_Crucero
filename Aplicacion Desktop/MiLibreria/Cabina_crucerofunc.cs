﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria.Modelo;
using System.Data;

namespace MiLibreria
{
    public class Cabina_crucerofunc
    {
        public static DataTable ObtenerCabinaCrucero(String cru_id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.VarChar);
            parametro.Value = cru_id;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_CABINA_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }

        public static Int32 ObtenerIDTipo(String desc)
        {
            Int32 ID = -1;
            String query = "SELECT TCAB_ID FROM TROLLS.TIPO_CABINA WHERE TCAB_TIPO = '" + desc + "'";
            ID = DataBase.queryForInt(query);

            return ID;
        }

        public static SqlDataReader ObtenerDescTipo(Int32 id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id;
            parametros.Add(parametro);
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERDESCTIPOCABINA", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        public static SqlDataReader ObtenerTipos()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENERTIPOSCABINA", DataBase.Tipos.StoredProcedure, parametros);

            return reader;
        }

        /*public static DataTable ObtenerUbicacionesSinCompra(Int32 id_publicacion, Int32 idTipo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter parametro;
            parametro = new SqlParameter("@ID", SqlDbType.Int, 100);
            parametro.Value = id_publicacion;
            parametros.Add(parametro);
            parametro = new SqlParameter("@ubi_tipo", SqlDbType.Int, 100);
            parametro.Value = idTipo;
            parametros.Add(parametro);

            DataSet ds = DataBase.ObtenerUnDataSet("TROLLS.OBTENER_UBICACIONES_SIN_COMPRA", DataBase.Tipos.StoredProcedure, parametros);

            return ds.Tables[0];
        }*/

        public static void CrearCabinaCrucero(Cabinas_Crucero cab_cru)
        {
            List<SqlParameter> parametros = PrepararParametros(cab_cru);
            DataBase.EscribirEnLaBase("TROLLS.CREAR_CABINA_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);

        }

        public static void ModificarCabinaCrucero(Cabinas_Crucero cab_cru)
        {
            List<SqlParameter> parametros = PrepararParametros(cab_cru);
            DataBase.EscribirEnLaBase("TROLLS.MODIFICAR_CABINA_CRUCERO", DataBase.Tipos.StoredProcedure, parametros);

        }

        private static List<SqlParameter> PrepararParametros(Cabinas_Crucero cab_cru)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter parametro;

            parametro = new SqlParameter("@cru_id", SqlDbType.Char);
            parametro.Value = cab_cru.cru_id;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cc_piso", SqlDbType.Int);
            parametro.Value = cab_cru.piso;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cc_cantidad", SqlDbType.Decimal);
            parametro.Value = cab_cru.cantidad;
            parametros.Add(parametro);

            parametro = new SqlParameter("@cc_tcab_id", SqlDbType.Int);
            parametro.Value = cab_cru.tcab_id;
            parametros.Add(parametro);

            return parametros;

        }
    }
}