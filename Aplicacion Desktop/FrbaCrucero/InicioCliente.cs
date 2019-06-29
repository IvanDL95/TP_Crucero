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
        int id;
        string user;
        ContenedorPrincipal cpal;

        public InicioCliente(ContenedorPrincipal cpal)
        {
            InitializeComponent();

            IniciarFormulario();

            if (cpal == null)
                this.cpal = null;
            else
                this.cpal = cpal;
            
        }

        private void IniciarFormulario()
        {
            dgv_listado.DataSource = Client.ListarClientesExistentesInicio(null, null, null).Tables[0];
            //dgv_listado.Columns["id"].Visible = false;
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
            //Ir al menu principal con el id (nro_doc) cliente
            Int32 IDCliente = Convert.ToInt32(dgv_listado.CurrentRow.Cells[0].Value);

            Rol rol = new Rol();
            rol.id = 2; //Cliente

            if (this.cpal == null)
            {
                ContenedorPrincipal cppal = new ContenedorPrincipal(this.id, this.user, rol.id, false, false);
                this.Hide();
                if (!cppal.IsDisposed)
                    cppal.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                this.cpal.id = this.id;
                this.cpal.usuario = this.user;
                this.cpal.id_rol = rol.id;
                this.cpal.inicializar(this.id, this.user, rol.id, false, true);
                this.cpal.Show();
                this.Close();
            }

            IniciarFormulario();
        }

        private void bt_nuevo_Click(object sender, EventArgs e)
        {
            //Crear cliente
        }

    }
}
