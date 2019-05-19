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

namespace FrbaCrucero.Editar_Publicacion
{
    public partial class FormListarPublicacion : Form
    {
        int idUsuario;
        public FormListarPublicacion(string usuario, bool esAdm)
        {
            InitializeComponent();

            if (esAdm)
            {
                MessageBox.Show("El usuario Admin no puede editar publicaciones");
                this.Close();
            }
            else
            {

                this.idUsuario = User.ObtenerIDUsuario(usuario);
                IniciarFormulario();
            }
            
        }

        private void IniciarFormulario()
        {
           dgv_listado.DataSource = ABMPublicacion.ListarPublicacionesExistentes(this.idUsuario,"Borrador", "Publicada").Tables[0];
           dgv_listado.Columns["id"].Visible = false;
           dgv_listado.Columns["FechaPublicacion"].Visible = false;           
        }

        private void ValidacionesIniciales()
        {
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 idPublicacion = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value); ;
            FormEditarPublicacion form = new FormEditarPublicacion(idPublicacion, this);
            this.Hide();
            form.ShowDialog();
            this.Show();

            IniciarFormulario();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Int32 idPublicacion = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value);
            string estado = dgv_listado.CurrentRow.Cells["Estado"].Value.ToString();
            if (string.Compare(estado, "Publicada") == 0)
            {
                MessageBox.Show("La publicación se encuentra Publicada. No se puede modificar");
            }
            else if (string.Compare(estado, "Borrador") == 0)
            {
                FormEditarPublicacion form = new FormEditarPublicacion(idPublicacion, this);
                this.Hide();
                form.ShowDialog();
                this.Show();

                IniciarFormulario();
            }
        }

        private void btPublicar_Click(object sender, EventArgs e)
        {
            Int32 idPublicacion = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value);
            string estado = dgv_listado.CurrentRow.Cells["Estado"].Value.ToString();
            if (string.Compare(estado, "Publicada") == 0)
            {
                MessageBox.Show("La publicación ya se encuentra Publicada");
            }
            else if (string.Compare(estado, "Borrador") == 0)
            {
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                if (DateTime.Compare(fechaSistema, Convert.ToDateTime(dgv_listado.CurrentRow.Cells["FechaEspectaculo"].Value)) > 0)
                {
                    MessageBox.Show(String.Format("Fecha Espectaculo {0} menor a Fecha de Sistema {1}. Modifique la Fecha para publicar", Convert.ToDateTime(dgv_listado.CurrentRow.Cells["FechaEspectaculo"].Value).ToString(), fechaSistema.ToString()));
                }
                else
                {
                    ABMPublicacion.ModificarEstadoPublicacion(idPublicacion, "Publicada", fechaSistema);
                    IniciarFormulario();
                }
            }
        }

        private void btFinalizar_Click(object sender, EventArgs e)
        {
            Int32 idPublicacion = Convert.ToInt32(dgv_listado.CurrentRow.Cells["id"].Value);
           string estado = dgv_listado.CurrentRow.Cells["Estado"].Value.ToString();
            if (string.Compare(estado, "Borrador") == 0)
            {
                MessageBox.Show("La publicación se encuentra Borrador");
            }
            else if (string.Compare(estado, "Publicada") == 0)
            {
                if (ConfirmarFinalizar())
                {
                    DateTime fechaPub = Convert.ToDateTime(dgv_listado.CurrentRow.Cells["FechaPublicacion"].Value);
                    ABMPublicacion.ModificarEstadoPublicacion(idPublicacion, "Finalizada",fechaPub);
                    MessageBox.Show("La publicación ha sido finalizada.");
                    IniciarFormulario();
                }
            }
            
        }

        private bool ConfirmarFinalizar()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea finalizar la publicación seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

    }
}
