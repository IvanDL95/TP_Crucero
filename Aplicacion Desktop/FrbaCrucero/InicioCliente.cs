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

namespace FrbaCrucero
{
    public partial class InicioCliente : Form
    {
        public InicioCliente()
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
            txt_nro_doc.MaxLength = 8;

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_nro_doc.Text = "";
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            dgv_listado.DataSource = Client.ListarClientesExistentesInicio(txt_nombre.Text
                                                                                , txt_apellido.Text
                                                                                , txt_nro_doc.Text).Tables[0];
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            //Ir al menu principal con el id cliente
            Int32 IDCliente = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);

            //FormMCliente form = new FormMCliente(IDCliente, this);
            this.Hide();
            //form.ShowDialog();
            this.Show();

            IniciarFormulario();
        }

    }
}
