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
using FrbaCrucero;

namespace FrbaCrucero.AbmCliente
{
    public partial class FormAbmEmpresaLogin : Form
    {
        RegistrarUsuario frRegistroUsuario;
        public Empresa empresa;
        public FormAbmEmpresaLogin(RegistrarUsuario frRegistroUsuario)
        {
            InitializeComponent();
            this.frRegistroUsuario = frRegistroUsuario;
            this.empresa = new Empresa();
        }

        private bool ValidarCamposVacios()
        {
            if (txt_razon_social.Text == "" ||  txt_cuit.Text == "")
                return true;
            return false;
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_razon_social.MaxLength = 50;
            txt_cuit.MaxLength = 11;
        }

        private void FormAbmEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar cuil   
            else if (!util.ValidaCuit(txt_cuit.Text))
                MessageBox.Show("El CUIT ingresado no es válido");
            else if (!Company.EsValidoCuit(txt_cuit.Text))
                MessageBox.Show("El CUIT ya existe");
            else if(Company.EsValidoRazonSocial(txt_razon_social.Text))
                MessageBox.Show("La Razon Social ya existe");
            else
            {
                //Guarda los datos del cliente
                this.empresa.RazonSocial = txt_razon_social.Text;
                this.empresa.Cuit = txt_cuit.Text;
                this.empresa.Valido = true;
                this.Close();
                this.frRegistroUsuario.Show();

            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.empresa.Valido = false;
            this.Close();
            this.frRegistroUsuario.Show();
        }
    }
}
