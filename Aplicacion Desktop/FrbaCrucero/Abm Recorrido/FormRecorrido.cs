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
using FrbaCrucero.ABMRecorrido;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class FormRecorrido : Form
    {
        public FormRecorrido()
        {
            InitializeComponent();

            IniciarFormulario();

            
        }

        private void CargarComboPuertoSalida()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    cmb_puertoSalida.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void CargarComboPuertoDestino()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    cmb_puertoDestino.Items.Add(item);
                }
                reader.Close();
            }
        }

        private void IniciarFormulario()
        {
            dgv_listado.DataSource = RecorridoFunc.ListarRecorridosExistentes(null, null, null).Tables[0];

            CargarComboPuertoSalida();
            CargarComboPuertoDestino();
            //dgv_listado.Columns["id"].Visible = false;
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_id.MaxLength = 30;
            //txt_modelo.MaxLength = 50;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            //txt_modelo.Text = "";
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            //Tipo_Servicio tipo = new Tipo_Servicio();
            Puerto pue_desde = new Puerto();
            Puerto pue_hasta = new Puerto();
            ComboboxItem item = new ComboboxItem();
            if (cmb_puertoDestino.SelectedItem != null)
            {
                item = (ComboboxItem)cmb_puertoDestino.SelectedItem;
                pue_desde = (Puerto)item.Value;
            }
            if (cmb_puertoSalida.SelectedItem != null)
            {
                item = (ComboboxItem)cmb_puertoSalida.SelectedItem;
                pue_hasta = (Puerto)item.Value;
            }

            int idd;
            if (!String.IsNullOrEmpty(txt_id.Text))
                idd = Int32.Parse(txt_id.Text);
            else
                idd = 0;

            dgv_listado.DataSource = RecorridoFunc.ListarRecorridosExistentes(idd
                                                                                , pue_desde.id
                                                                                , pue_hasta.id).Tables[0];
        }

        private bool ConfirmarBaja()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea eliminar el Recorrido seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void btHabilitar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgv_listado.CurrentRow.Cells[4].Value))
                MessageBox.Show("El recorrido ya está habilitado");
            else
            {
                Int32 IDRecorrido = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                DataBase.EscribirEnLaBase("UPDATE TROLLS.RECORRIDO SET REC_ESTADO = 1 WHERE REC_ID = " + IDRecorrido.ToString());
                //DataBase.EscribirEnLaBase("UPDATE TROLLS.USUARIO SET USU_ESTADO = 1 WHERE USU_ID = (select emp_usu_id from TROLLS.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                MessageBox.Show("El Recorrido ha sido habilitado correctamente.");
                IniciarFormulario();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            FormAmRecorrido form = new FormAmRecorrido(0,this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            IniciarFormulario();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);

            FormAmRecorrido form = new FormAmRecorrido(id, this);
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
                    Int32 IDRecorrido = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);
                    RecorridoFunc.DarDeBajaUnRecorrido(IDRecorrido);
                    //DataBase.EscribirEnLaBase("UPDATE TROLLS.EMPRESA SET REC_ESTADO = 0 WHERE REC_ID = " + IDRecorrido.ToString());
                    //DataBase.EscribirEnLaBase("UPDATE TROLLS.USUARIO SET USU_ESTADO = 0 WHERE USU_ID = (select emp_usu_id from TROLLS.EMPRESA where EMP_ID = " + IDEmpresa.ToString() + ")");
                    MessageBox.Show("El Recorrido ha sido dado de baja correctamente.");
                    IniciarFormulario();
                }
            }
        }

        private void FormRecorrido_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_puertoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_puertoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
