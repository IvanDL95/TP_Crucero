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

namespace FrbaCrucero.AbmEmpresa
{
    public partial class FormEmpresa : Form
    {
        public FormEmpresa()
        {
            InitializeComponent();

            IniciarFormulario();
            
        }

        private void IniciarFormulario()
        {
            dgv_listado.DataSource = Company.ListarEmpresasExistentes(null, null, null).Tables[0];
            dgv_listado.Columns["id"].Visible = false;
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_razon.MaxLength = 30;
            txt_mail.MaxLength = 50;
            txt_cuit.MaxLength = 8;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_razon.Text = "";
            txt_mail.Text = "";
            txt_cuit.Text = "";
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            dgv_listado.DataSource = Company.ListarEmpresasExistentes(txt_razon.Text
                                                                                , txt_mail.Text
                                                                                , txt_cuit.Text).Tables[0];
        }

        private bool ConfirmarBaja()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea eliminar a la Empresa seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void btHabilitar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgv_listado.CurrentRow.Cells[4].Value))
                MessageBox.Show("La empresa ya está habilitada");
            else
            {
                Int32 IDEmpresa = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                DataBase.EscribirEnLaBase("UPDATE RJT.EMPRESA SET EMP_ESTADO = 1 WHERE EMP_ID = " + IDEmpresa.ToString());
                DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 1 WHERE USU_ID = (select emp_usu_id from RJT.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                MessageBox.Show("La Empresa ha sido habilitada correctamente.");
                IniciarFormulario();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            FormAMEmpresa form = new FormAMEmpresa(-1, this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            IniciarFormulario();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Int32 IDEmpresa = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);

            FormAMEmpresa form = new FormAMEmpresa(IDEmpresa, this);
            this.Hide();
            form.ShowDialog();
            this.Show();

            IniciarFormulario();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(dgv_listado.CurrentRow.Cells[4].Value))
                MessageBox.Show("La empresa ya está eliminada");
            else
            {
                if (ConfirmarBaja())
                {
                    Int32 IDEmpresa = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                    DataBase.EscribirEnLaBase("UPDATE RJT.EMPRESA SET EMP_ESTADO = 0 WHERE EMP_ID = " + IDEmpresa.ToString());
                    DataBase.EscribirEnLaBase("UPDATE RJT.USUARIO SET USU_ESTADO = 0 WHERE USU_ID = (select emp_usu_id from RJT.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                    MessageBox.Show("La Empresa ha sido dado de baja correctamente.");
                    IniciarFormulario();
                }
            }
        }

    }
}
