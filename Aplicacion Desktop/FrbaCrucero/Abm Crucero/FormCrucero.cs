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
using FrbaCrucero.ABMCrucero;

namespace FrbaCrucero.AbmCrucero
{
    public partial class FormCrucero : Form
    {
        public FormCrucero()
        {
            InitializeComponent();

            IniciarFormulario();

            
        }

        private void CargarComboServicio()
        {
            SqlDataReader reader = TipoServicioFunc.ObtenerTipoServicio();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Tipo_Servicio tipo = new Tipo_Servicio();
                    tipo.id = Convert.ToInt32(reader.GetDecimal(0));
                    tipo.desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = tipo.desc;
                    item.Value = tipo;
                    cmb_servicio.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void CargarComboFabricante()
        {
            SqlDataReader reader = FabricanteFunc.ObtenerFabricante();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Fabricante fabricante = new Fabricante();
                    fabricante.id = Convert.ToInt32(reader.GetDecimal(0));
                    fabricante.desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = fabricante.desc;
                    item.Value = fabricante;
                    cmb_fabricante.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void IniciarFormulario()
        {
            dgv_listado.DataSource = CruceroFunc.ListarCrucerosExistentes(null, null, null, null).Tables[0];
            CargarComboServicio();
            CargarComboFabricante();

            //dgv_listado.Columns["id"].Visible = false;
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_id.MaxLength = 30;       
            txt_modelo.MaxLength = 50;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_modelo.Text = "";
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            Tipo_Servicio tipo = new Tipo_Servicio();
            Fabricante fab = new Fabricante();
            ComboboxItem item = new ComboboxItem();
            if (cmb_servicio.SelectedItem != null)
            {
                item = (ComboboxItem)cmb_servicio.SelectedItem;
                tipo = (Tipo_Servicio)item.Value;
            }
            if (cmb_fabricante.SelectedItem != null)
            {
                item = (ComboboxItem)cmb_fabricante.SelectedItem;
                fab = (Fabricante)item.Value;
            }


            dgv_listado.DataSource = CruceroFunc.ListarCrucerosExistentes(tipo.id
                                                                                , fab.id
                                                                                , txt_modelo.Text
                                                                                , txt_id.Text).Tables[0];
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
                DataBase.EscribirEnLaBase("UPDATE TROLLS.EMPRESA SET EMP_ESTADO = 1 WHERE EMP_ID = " + IDEmpresa.ToString());
                DataBase.EscribirEnLaBase("UPDATE TROLLS.USUARIO SET USU_ESTADO = 1 WHERE USU_ID = (select emp_usu_id from TROLLS.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                MessageBox.Show("La Empresa ha sido habilitada correctamente.");
                IniciarFormulario();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            FormAmCrucero form = new FormAmCrucero("",this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            IniciarFormulario();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            String id = Convert.ToString(dgv_listado.CurrentRow.Cells[0].Value);

            FormAmCrucero form = new FormAmCrucero(id, this);
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
                    DataBase.EscribirEnLaBase("UPDATE TROLLS.EMPRESA SET EMP_ESTADO = 0 WHERE EMP_ID = " + IDEmpresa.ToString());
                    DataBase.EscribirEnLaBase("UPDATE TROLLS.USUARIO SET USU_ESTADO = 0 WHERE USU_ID = (select emp_usu_id from TROLLS.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                    MessageBox.Show("La Empresa ha sido dado de baja correctamente.");
                    IniciarFormulario();
                }
            }
        }

    }
}
