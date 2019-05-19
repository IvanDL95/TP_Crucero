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

namespace FrbaCrucero.AbmEmpresa
{
    public partial class FormAMEmpresa : Form
    {
        Int32 IDEmpresa;
        FormEmpresa fr = new FormEmpresa();
        Empresa empresaModificado = new Empresa();
        Direccion direccionModificado = new Direccion();
        Empresa empresaBase = new Empresa();

        public FormAMEmpresa(Int32 IDEmpresa, FormEmpresa fr)
        {
            InitializeComponent();
            ValidacionesIniciales();
            this.fr = fr;
            this.IDEmpresa = IDEmpresa;
            if (this.IDEmpresa > 0)
            {
                //Modificar
                
                Empresa empresa = new Empresa();

                //Obtener Empresa
                SqlDataReader reader = Company.ObtenerEmpresa(IDEmpresa);

                empresa = Company.ObtenerEmpresaDesdeUnReader(reader);
                //Obtener Direccion
                Int32 IDDireccion = Company.ObtenerIDDireccionEmpresa(IDEmpresa);
                Direccion direccion = Adress.ObtenerDireccionDesdeUnReader(Adress.ObtenerDireccion(IDDireccion));
                //Llenar textos
                txt_razon_social.Text = empresa.RazonSocial.Trim();

                if (!String.IsNullOrEmpty(empresa.Cuit))
                    txt_cuit.Text = empresa.Cuit.Trim();
                this.empresaModificado.Id = this.IDEmpresa;
                this.direccionModificado.Id = IDDireccion;
                this.empresaBase = empresa;

                txt_calle.Text = direccion.Calle.Trim();
                txt_departamento.Text = direccion.Departamento.Trim();
                txt_piso.Text = direccion.Piso.Trim();
                txt_cp.Text = direccion.CodigoPostal.Trim();
                if (!String.IsNullOrEmpty(direccion.Localidad))
                    txt_localidad.Text = direccion.Localidad.Trim();
                txt_numero.Text = direccion.Numero.Trim();
                if (!String.IsNullOrEmpty(direccion.Telefono))
                    txt_tel.Text = direccion.Telefono.Trim();
                txt_mail.Text = direccion.Mail.Trim();
            }
        }

        private void ValidacionesIniciales()
        {
            txt_cuit.MaxLength = 11;
            txt_razon_social.MaxLength = 50;
            txt_calle.MaxLength = 70;
            txt_departamento.MaxLength = 2;
            txt_piso.MaxLength = 2;
            txt_cp.MaxLength = 4;
            txt_localidad.MaxLength = 50;
            txt_numero.MaxLength = 5;
            txt_tel.MaxLength = 18;
            txt_mail.MaxLength = 50;
        }

        private bool ValidarCamposVacios()
        {
            if (txt_razon_social.Text == "" || txt_cuit.Text == "" || txt_cp.Text == "" || txt_departamento.Text == "" || txt_localidad.Text == "" || txt_mail.Text == "" || txt_numero.Text == "" || txt_piso.Text == "" || txt_tel.Text == "")
                return true;
            return false;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {


            //Validar
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar mail   
            else if (!util.IsValidEmail(txt_mail.Text))
                MessageBox.Show("El Email ingresado no es válido");
            else if(Adress.ValidaDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text))
                MessageBox.Show("La dirección ingresada ya existe");
            //Validar cuil   
            else if (!util.ValidaCuit(txt_cuit.Text))
                MessageBox.Show("El CUIT ingresado no es válido");

            else if (this.IDEmpresa > 0)
            {
                //Modificar
                if (!Company.EsValidoCuitModif(txt_cuit.Text, this.empresaBase.Cuit.Trim()))
                    MessageBox.Show("El CUIT ya existe");
                else if (!Company.EsValidoRazonSocialModif(txt_razon_social.Text, this.empresaBase.RazonSocial.Trim()))
                    MessageBox.Show("La Razon Social ya existe");
                else
                {

                    this.empresaModificado.RazonSocial = txt_razon_social.Text;
                    this.empresaModificado.Cuit = txt_cuit.Text;

                    Company.ModificarEmpresa(this.empresaModificado);

                    this.direccionModificado.Calle = txt_calle.Text;
                    this.direccionModificado.CodigoPostal = txt_cp.Text;
                    this.direccionModificado.Departamento = txt_departamento.Text;
                    this.direccionModificado.Localidad = txt_localidad.Text;
                    this.direccionModificado.Mail = txt_mail.Text;
                    this.direccionModificado.Numero = txt_numero.Text;
                    this.direccionModificado.Piso = txt_piso.Text;
                    this.direccionModificado.Telefono = txt_tel.Text;

                    Adress.ModificarDireccion(this.direccionModificado);

                    MessageBox.Show("La Empresa fue modificada exitosamente");

                    this.Close();
                    this.fr.Show();

                }
            }
            else
            {
                if (!Company.EsValidoCuit(txt_cuit.Text))
                MessageBox.Show("El CUIT ya existe");
                else if (Company.EsValidoRazonSocial(txt_razon_social.Text))
                    MessageBox.Show("La Razon Social ya existe");
                else
                {
                    //Alta
                    //Crear usuario automatico
                    Usuario usuario = new Usuario(txt_cuit.Text.Trim(), txt_cuit.Text.Trim(), true, 0);
                    User.CrearUsuario(usuario);
                    int idUser = User.ObtenerIDUsuario(txt_cuit.Text.Trim());
                    //RolxUsuario Empresa
                    Role.CrearRolxUsuario(2, idUser);
                    //Crear Direccion
                    Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                    Adress.CrearDireccion(direccion);
                    int idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                    //Crear Empresa
                    Empresa empresa = new Empresa();
                    empresa.RazonSocial = txt_razon_social.Text;
                    empresa.Cuit = txt_cuit.Text;
                    empresa.IdUsuario = idUser;
                    empresa.IdDireccion = idDireccion;
                    Company.CrearEmpresa(empresa);

                    MessageBox.Show("La Empresa fue creada exitosamente");

                    this.Close();
                    this.fr.Show();
                }
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.fr.Show();
        }

    }
}
