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
using System.Configuration;

namespace FrbaCrucero.AbmCliente
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();

            IniciarFormulario();
            
        }

        private void IniciarFormulario()
        {
            dgv_listado.DataSource = Client.ListarClientesExistentes(null, null, null, null).Tables[0];
            dgv_listado.Columns["id"].Visible = false;
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_nombre.MaxLength = 30;
            txt_apellido.MaxLength = 30;
            txt_mail.MaxLength = 50;
            txt_nro_doc.MaxLength = 8;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_mail.Text = "";
            txt_nro_doc.Text = "";
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            dgv_listado.DataSource = Client.ListarClientesExistentes(txt_nombre.Text
                                                                                , txt_apellido.Text
                                                                                , txt_mail.Text
                                                                                , txt_nro_doc.Text).Tables[0];
        }

        private bool ConfirmarBaja()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea eliminar al cliente seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void btHabilitar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgv_listado.CurrentRow.Cells[6].Value))
                MessageBox.Show("El Cliente ya está habilitado");
            else
            {
                Int32 IDCliente = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                DataBase.EscribirEnLaBase("UPDATE RJT.CLIENTE SET CLI_ESTADO = 1 WHERE CLI_ID = " + IDCliente.ToString());
                DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 1 WHERE USU_ID = (select cli_usu_id from RJT.CLIENTE where CLI_ID = " + IDCliente.ToString() + ")");
                MessageBox.Show("El Cliente ha sido hbilitado correctamente.");
                IniciarFormulario();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            FormMCliente form = new FormMCliente(-1, this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            IniciarFormulario();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Int32 IDCliente = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);

            FormMCliente form = new FormMCliente(IDCliente, this);
            this.Hide();
            form.ShowDialog();
            this.Show();

            IniciarFormulario();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

            if (!Convert.ToBoolean(dgv_listado.CurrentRow.Cells[6].Value))
                MessageBox.Show("El Cliente ya está eliminado");
            else
            {

                if (ConfirmarBaja())
                {
                    Int32 IDCliente = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                    DataBase.EscribirEnLaBase("UPDATE RJT.CLIENTE SET CLI_ESTADO = 0 WHERE CLI_ID = " + IDCliente.ToString());
                    DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 0 WHERE USU_ID = (select cli_usu_id from RJT.CLIENTE where CLI_ID = " + IDCliente.ToString() + ")");
                    MessageBox.Show("El Cliente ha sido dado de baja correctamente.");
                    IniciarFormulario();
                }
            }
        }

    }
}
