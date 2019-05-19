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

namespace FrbaCrucero.Listados
{
    public partial class FormListadoEstadistico : Form
    {
        DataSet ds;
        public FormListadoEstadistico()
        {
            InitializeComponent();
            txt_anio.MaxLength = 4;
        }

        private bool ValidarCamposVacios()
        {
            if (txt_anio.Text == "" || string.IsNullOrEmpty(cmbTrimestre.Text) || string.IsNullOrEmpty(cmbListado.Text))
                return true;
            return false;
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            else if (txt_anio.Text.Length < 4)
                MessageBox.Show("El año debe tener 4 dígitos");
            else
            {
                ds = ListadoFunc.Listado(Convert.ToInt32(txt_anio.Text), cmbTrimestre.SelectedIndex+1, cmbListado.SelectedIndex+1);
                dgv_listado.DataSource = ds.Tables[0];

                if((cmbListado.SelectedIndex+1)==3){
                    dgv_listado.Columns["cli_id"].Visible = false;
                    dgv_listado.Columns["cli_usu_id"].Visible = false;
                }

            }
        }
    }
}
