using FrbaCrucero.AbmCliente;
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

namespace FrbaCrucero
{
    public partial class RegistrarUsuario : Form
    {
        FormAbmClienteLogin frCliente;
        FormAbmEmpresaLogin frEmpresa;
        public RegistrarUsuario()
        {
            InitializeComponent();
            ValidacionesIniciales();
            btCrear.Enabled = false;
            txt_pass.PasswordChar = '*';
            frCliente = new FormAbmClienteLogin(this);
            frEmpresa = new FormAbmEmpresaLogin(this);
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_calle.MaxLength = 70;
            txt_departamento.MaxLength = 2;
            txt_piso.MaxLength = 2;
            txt_cp.MaxLength = 4;
            txt_localidad.MaxLength = 50;
            txt_numero.MaxLength = 5;
            txt_pass.MaxLength = 255;
            txt_tel.MaxLength = 18;
            txt_usuario.MaxLength = 30;
            txt_mail.MaxLength = 50;
        }

        private bool ValidarCamposVacios()
        {
            if (txt_usuario.Text == "" || txt_pass.Text == "" || txt_cp.Text == "" || txt_departamento.Text == "" || txt_localidad.Text == "" || txt_mail.Text == "" || txt_numero.Text == "" || txt_piso.Text == "" || txt_tel.Text == "") 
                return true;
            return false;
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Crear
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar mail   
            else if (!util.IsValidEmail(txt_mail.Text))
                MessageBox.Show("El Email ingresado no es válido");
            else if(Adress.ValidaDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text))
                MessageBox.Show("La dirección ingresada ya existe");
            //Validar usuario duplicado
            else if (!User.EsValidoUserName(txt_usuario.Text))
                MessageBox.Show("El Usuario ya existe");
            else if (cmb_tipo.SelectedItem == null)
                MessageBox.Show("Debe completar el tipo de Usuario");
            else if (cmb_tipo.SelectedItem.ToString() == "Cliente")
            {
                //Crear Usuario
                Usuario usuario = new Usuario(txt_usuario.Text.Trim(), txt_pass.Text.Trim(), true, 0);
                User.CrearUsuario(usuario);
                int idUser = User.ObtenerIDUsuario(txt_usuario.Text);
                //RolxUsuario Cliente
                Role.CrearRolxUsuario(3, idUser);
                //Crear Direccion
                Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                Adress.CrearDireccion(direccion);
                int idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                //Crear Cliente
                frCliente.cliente.IdUsuario = idUser;
                frCliente.cliente.IdDireccion = idDireccion;
                Client.CrearCliente(frCliente.cliente);

            }
            else if (cmb_tipo.SelectedItem.ToString() == "Empresa")
            {
                //Crear Usuario
                Usuario usuario = new Usuario(txt_usuario.Text.Trim(), txt_pass.Text.Trim(), true, 0);
                User.CrearUsuario(usuario);
                int idUser = User.ObtenerIDUsuario(txt_usuario.Text);
                //RolxUsuario Empresa
                Role.CrearRolxUsuario(2, idUser);
                //Crear Direccion
                Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                Adress.CrearDireccion(direccion);
                int idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                //Crear Empresa
                frEmpresa.empresa.IdUsuario = idUser;
                frEmpresa.empresa.IdDireccion = idDireccion;
                Company.CrearEmpresa(frEmpresa.empresa);
            }
            this.Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar mail   
            else if (!util.IsValidEmail(txt_mail.Text))
                MessageBox.Show("El Email ingresado no es válido");
            //Validar usuario duplicado
            else if (!User.EsValidoUserName(txt_usuario.Text))
                MessageBox.Show("El Usuario ya existe");
            else if (cmb_tipo.SelectedItem == null)
                MessageBox.Show("Debe completar el tipo de Usuario");
            else if (cmb_tipo.SelectedItem.ToString() == "Cliente")
            {
                this.Hide();
                frCliente.ShowDialog();
                this.Show();
            }
            else if (cmb_tipo.SelectedItem.ToString() == "Empresa")
            {
                this.Hide();
                frEmpresa.ShowDialog();
                this.Show();
                if (frEmpresa.empresa.Valido)
                    btCrear.Enabled = true;
                else
                    btCrear.Enabled = false;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
