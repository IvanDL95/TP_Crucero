using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria.Modelo;
using MiLibreria;
using System.Data.SqlClient;

namespace FrbaCrucero
{
    public partial class ABMUsuario : Form
    {
        public ABMUsuario()
        {
            InitializeComponent();
            DataSet ds = User.ListarUsuariosExistentes();
            //Set the source table.
            dgv_listado.DataSource = ds.Tables[0];
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            RegistrarUsuario fr = new RegistrarUsuario();
            this.Hide();
            fr.ShowDialog();
            this.Show();
            DataSet ds = User.ListarUsuariosExistentes();
            //Set the source table.
            dgv_listado.DataSource = ds.Tables[0];
        }

        private void btHabilitar_Click(object sender, EventArgs e)
        {
            Int32 ID = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value);            
            if (Convert.ToBoolean(dgv_listado.CurrentRow.Cells[2].Value))
                MessageBox.Show("El Usuario ya está habilitado");
            else
            {                
                DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 1, USU_CANT_INT_FALLIDOS = 0 WHERE USU_ID = " + ID.ToString());
                if (User.EsUsuarioCliente(ID))
                {
                    //Es Cliente
                    DataBase.EscribirEnLaBase("UPDATE RJT.CLIENTE SET CLI_ESTADO = 1 WHERE CLI_USU_ID = (select usu_id from RJT.USUARIO where USU_ID = " + ID.ToString() + ")");
                }
                else
                {
                    //Es empresa
                    DataBase.EscribirEnLaBase("UPDATE RJT.EMPRESA SET EMP_ESTADO = 1 WHERE EMP_USU_ID = (select usu_id from RJT.USUARIO where USU_ID = " + ID.ToString() + ")");
                }
                MessageBox.Show("El Usuario ha sido habilitado correctamente.");
                DataSet ds = User.ListarUsuariosExistentes();
                //Set the source table.
                dgv_listado.DataSource = ds.Tables[0];
            }
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            Int32 ID = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value); 
            if (ID == 1)
                MessageBox.Show("El Usuario Admin no se puede eliminar");
            else if (!Convert.ToBoolean(dgv_listado.CurrentRow.Cells[2].Value))
                MessageBox.Show("El Usuario ya está eliminado");
            else
            {
                if (ConfirmarBaja())
                {
                    DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 0 WHERE USU_ID = " + ID.ToString());
                    if (User.EsUsuarioCliente(ID))
                    {
                        //Es Cliente
                        DataBase.EscribirEnLaBase("UPDATE RJT.CLIENTE SET CLI_ESTADO = 0 WHERE CLI_USU_ID = (select usu_id from RJT.USUARIO where USU_ID = " + ID.ToString() + ")");
                    }
                    else
                    {
                        //Es empresa
                        DataBase.EscribirEnLaBase("UPDATE RJT.EMPRESA SET EMP_ESTADO = 0 WHERE EMP_USU_ID = (select usu_id from RJT.USUARIO where USU_ID = " + ID.ToString() + ")");
                    }
                    MessageBox.Show("El Usuario ha sido eliminado correctamente.");
                    DataSet ds = User.ListarUsuariosExistentes();
                    //Set the source table.
                    dgv_listado.DataSource = ds.Tables[0];
                }
            }
        }

        private bool ConfirmarBaja()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea eliminar al usuario seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
