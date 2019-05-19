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
using System.Globalization;

namespace FrbaCrucero.Abm_Grado
{
    public partial class AMGrado : Form
    {
        string Accion;
        Grado grado;
        public AMGrado(string Accion, Grado grado)
        {
            InitializeComponent();
            ValidacionesIniciales();
            this.Accion = Accion;
            if (String.Compare(Accion, "Modificacion") == 0)
            {
                this.grado = grado;
                //Cargar campos
                
                txt_comision.Text = grado.gra_comision.ToString();
                txt_descripcion.Text = grado.gra_desc.ToString();
                txt_peso.Text = grado.gra_peso.ToString();
            }
        }

        private void ValidacionesIniciales()
        {
            txt_comision.MaxLength = 2;
            txt_descripcion.MaxLength = 30;
            txt_peso.MaxLength = 2;
        }
        private bool ValidarCamposVacios()
        {
            if (txt_comision.Text == "" || txt_descripcion.Text == "" || txt_peso.Text == "")
                return true;
            return false;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            else if (String.Compare(Accion, "Modificacion") == 0)
            {
                //Modificacion
                Grado grado = new Grado();
                grado.gra_id = this.grado.gra_id;
                grado.gra_comision = Convert.ToInt32(txt_comision.Text);
                grado.gra_desc = txt_descripcion.Text.Trim();
                grado.gra_peso = Convert.ToInt32(txt_peso.Text);
                GradoFunc.ModificarGrado(grado);
                MessageBox.Show("Grado Modificado exitosamente");
                this.Close();
            }
            else
            {
                //Alta
                Grado grado = new Grado();
                grado.gra_comision = Convert.ToInt32(txt_comision.Text);
                grado.gra_desc = txt_descripcion.Text.Trim();
                grado.gra_peso = Convert.ToInt32(txt_peso.Text);
                GradoFunc.AltaGrado(grado);
                MessageBox.Show("Grado dado de Alta exitosamente");
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
