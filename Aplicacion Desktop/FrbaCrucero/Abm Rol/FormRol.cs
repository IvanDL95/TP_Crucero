using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;
using MiLibreria.Modelo;

namespace FrbaCrucero.AbmRol
{
    public partial class FormRol : Form
    {

        public FormRol()
        {
            InitializeComponent();
            txt_nombre_agregar.MaxLength = 25;
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
            HabilitarCampos(true);
            Role.LLenarDGV(dg_rol);
            groupBox2.Enabled = false;
        }

        private void LimpiarCampos()
        {
            this.txt_nombre.Text = "";
            this.txt_nombre_agregar.Text = "";
        }

        private void HabilitarCampos(bool estado)
        {
            this.txt_nombre.Enabled = estado;
            this.btn_buscar.Enabled = estado;
            this.dg_rol.Enabled = estado;
          
        }

        private string ValidarCampos()
        {
            if (this.txt_nombre.Text.Length == 0) return "Debe completar el nombre";
            return string.Empty;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_nombre.Text.Trim()))
            {
                string palabra = txt_nombre.Text.Trim();
                Role.BuscarRol(dg_rol,palabra);

            }
            else
            {
                MessageBox.Show("No ha ingresado un rol a buscar.");
            }
        }

        private void btn_reestablecer_Click(object sender, EventArgs e)
        {
            Role.LLenarDGV(dg_rol);
            txt_nombre.Text = "";
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_nombre_agregar.Text.Trim()))
            {
                Rol rol = new Rol();
                
                rol.Nombre = txt_nombre_agregar.Text.Trim();
                if(chk_habilitado.Checked)
                rol.Estado = true;
                else
                    rol.Estado = false;

                Role.GuardarRol(rol);

                Int32 id = Role.DameIdRol(txt_nombre_agregar.Text.Trim());
                rol.Id = id;

                if(MessageBox.Show("¿Desea agregarle funcionalidades ahora?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    FormAMRol form = new FormAMRol(rol, true, rol.Estado);
                    form.ShowDialog();
                    this.Show();
                    txt_nombre_agregar.Text = "";
                    txt_nombre.Text = "";
                    Role.LLenarDGV(dg_rol);
                }
                else
                {
                    MessageBox.Show("Se ha guardado el rol correctamente");
                    txt_nombre_agregar.Text = "";
                    chk_habilitado.Checked = false;
                    groupBox2.Enabled = false;
                    txt_nombre_agregar.Text = "";
                    txt_nombre.Text = "";
                    Role.LLenarDGV(dg_rol);
                }

            }
            else
            {
                MessageBox.Show("Debe indicar el nombre del nuevo rol.");
            }

            Role.LLenarDGV(dg_rol);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_habilitado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(dg_rol.CurrentRow.Cells["Rol_id"].Value);
            String nombre = Convert.ToString(dg_rol.CurrentRow.Cells["rol_NOMBRE"].Value);

            Boolean habilitado = Convert.ToBoolean(dg_rol.CurrentRow.Cells[2].Value);

            Rol rol = new Rol();
            rol.Id = id;
            rol.Nombre = nombre;

            this.Hide();
            FormAMRol form = new FormAMRol(rol, false, habilitado);
            form.ShowDialog();
            this.Show();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32(dg_rol.CurrentRow.Cells["Rol_id"].Value);

            if (MessageBox.Show("¿Realmente desea eliminar el rol seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Role.EliminarRol(id);
                Role.LLenarDGV(dg_rol);
            }
        }
 
    }

}
