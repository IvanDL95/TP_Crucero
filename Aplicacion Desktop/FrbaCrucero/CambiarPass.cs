using MiLibreria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    public partial class CambiarPass : Form
    {
        Int32 IdUsuario;
        string user;
        Boolean primerInicio;
        public CambiarPass(string user, Boolean primerInicio)
        {
            InitializeComponent();
            this.primerInicio = primerInicio;
            txt_pass.PasswordChar = '*';
            txt_pass2.PasswordChar = '*';
            ValidacionesIniciales();
            this.user = user;
            this.IdUsuario = User.ObtenerIDUsuario(this.user);

            if (primerInicio)
                this.ControlBox = false;
        }

        private void ValidacionesIniciales()
        {
            txt_pass.MaxLength = 100;
            txt_pass2.MaxLength = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (primerInicio)
            {
                MessageBox.Show("Debe modificar su password inicial ya que no podrá volver a loguearse.");
            }
            else
            {
                this.Close();
            }
        }

        private bool ValidarCamposVacios()
        {
            if (txt_pass.Text == "" || txt_pass2.Text == "")
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            else if(String.Compare(txt_pass.Text,txt_pass2.Text)!=0)
                MessageBox.Show("La password no coincide");
            else{
                User.CambiarPass(this.IdUsuario, txt_pass.Text.Trim());
                MessageBox.Show("Se modificó la password correctamente");
                this.Close();
            }
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {

        }
    }
}
