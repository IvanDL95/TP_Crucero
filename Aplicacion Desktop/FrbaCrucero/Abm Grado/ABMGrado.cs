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

namespace FrbaCrucero.Abm_Grado
{
    public partial class ABMGrado : Form
    {
        public ABMGrado()
        {
            InitializeComponent();
            DataSet ds = GradoFunc.ListarGradosExistentes();

            //Set the source table.
            dgv_grado.DataSource = ds.Tables[0];
            dgv_grado.Columns["id"].Visible = false;

        }



        private void btNuevo_Click(object sender, EventArgs e)
        {
            AMGrado fr = new AMGrado("Alta",null);
            this.Hide();
            fr.ShowDialog();
            this.Show();
            DataSet ds = GradoFunc.ListarGradosExistentes();
            //Set the source table.
            dgv_grado.DataSource = ds.Tables[0];
            dgv_grado.Columns["id"].Visible = false;
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Grado grado = new Grado();
            SqlDataReader reader = GradoFunc.ObtenerGrado(Convert.ToInt32(dgv_grado.CurrentRow.Cells["id"].Value));
            grado = GradoFunc.ObtenerGradoDesdeUnReader(reader);
            AMGrado fr = new AMGrado("Modificacion", grado);
            this.Hide();
            fr.ShowDialog();
            this.Show();
            DataSet ds = GradoFunc.ListarGradosExistentes();
            //Set the source table.
            dgv_grado.DataSource = ds.Tables[0];
            dgv_grado.Columns["id"].Visible = false;
            
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {           
            if (ConfirmarBaja())
            {
                Int32 ID = Convert.ToInt32(dgv_grado.CurrentRow.Cells["id"].Value);
                DataBase.EscribirEnLaBase("UPDATE RJT.GRADOPUBLICACION SET GRA_ESTADO = 0 WHERE GRA_ID = " + ID.ToString());
                MessageBox.Show("El Grado de publicacion ha sido dado de baja correctamente.");
                DataSet ds = GradoFunc.ListarGradosExistentes();
                //Set the source table.
                dgv_grado.DataSource = ds.Tables[0];
                dgv_grado.Columns["id"].Visible = false;
            }
        }

        private bool ConfirmarBaja()
        {
            DialogResult result = MessageBox.Show("¿Realmente desea eliminar al grado seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
