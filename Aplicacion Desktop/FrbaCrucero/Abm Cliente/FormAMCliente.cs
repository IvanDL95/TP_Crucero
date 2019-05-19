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

namespace FrbaCrucero.AbmCliente
{
    public partial class FormMCliente : Form
    {
        Int32 IDCliente;
        FormCliente fr = new FormCliente();
        Cliente clienteModificado = new Cliente();
        Direccion direccionModificado = new Direccion();
        Cliente clienteBase = new Cliente();

        public FormMCliente(Int32 IDCliente, FormCliente fr)
        {
            InitializeComponent();
            ValidacionesIniciales();
            LLenarComboTipoDoc();
            this.IDCliente = IDCliente;
            this.fr = fr;

            if (this.IDCliente > 0)
            {
                //Modificar
                Cliente cliente = new Cliente();

                //Obtener Cliente
                SqlDataReader reader = Client.ObtenerCliente(IDCliente);

                cliente = Client.ObtenerClienteDesdeUnReader(reader);

                //Cliente cliente = Client.ObtenerClienteDesdeUnReader(Client.ObtenerCliente(IDCliente));
                //Obtener Direccion
                Int32 IDDireccion = Client.ObtenerIDDireccionCliente(IDCliente);
                Direccion direccion = Adress.ObtenerDireccionDesdeUnReader(Adress.ObtenerDireccion(IDDireccion));
                //Llenar textos
                txt_nombre.Text = cliente.Nombre.Trim();
                txt_apellido.Text = cliente.Apellido.Trim();
                txt_nro_doc.Text = cliente.NroDoc.Trim();
                if (!String.IsNullOrEmpty(cliente.Cuil))
                    txt_cuil.Text = cliente.Cuil.Trim();
                if (!String.IsNullOrEmpty(cliente.Tarj))
                    txt_tarj.Text = cliente.Tarj.Trim();
                fechaNac.Value = cliente.FechaNac;
                cmb_tipo_doc.SelectedIndex = cmb_tipo_doc.FindStringExact(cliente.TipoDoc.Trim());
                this.clienteModificado.Id = this.IDCliente;
                this.direccionModificado.Id = Client.ObtenerIDDireccionCliente(this.IDCliente);
                this.clienteBase = cliente;

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
            //GDT: Me aseguro que no rompa la base.
            txt_nombre.MaxLength = 30;
            txt_apellido.MaxLength = 30;
            txt_nro_doc.MaxLength = 8;
            txt_cuil.MaxLength = 11;
            txt_tarj.MaxLength = 19;

            txt_calle.MaxLength = 70;
            txt_departamento.MaxLength = 2;
            txt_piso.MaxLength = 2;
            txt_cp.MaxLength = 4;
            txt_localidad.MaxLength = 50;
            txt_numero.MaxLength = 5;
            txt_tel.MaxLength = 18;
            txt_mail.MaxLength = 50;
        }
        private void LLenarComboTipoDoc()
        {
            cmb_tipo_doc.Items.Add("DU");
            cmb_tipo_doc.Items.Add("DNI");
        }

        private bool ValidarCamposVacios()
        {
            if (txt_nombre.Text == "" || txt_apellido.Text == "" || txt_nro_doc.Text == "" || txt_cuil.Text == "" || string.IsNullOrEmpty(cmb_tipo_doc.Text) || txt_tarj.Text == "" || txt_cp.Text == "" || txt_departamento.Text == "" || txt_localidad.Text == "" || txt_mail.Text == "" || txt_numero.Text == "" || txt_piso.Text == "" || txt_tel.Text == "")
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
            else if (!util.ValidaCuit(txt_cuil.Text))
                MessageBox.Show("El CUIL ingresado no es válido");
            else if (!string.IsNullOrEmpty(txt_nro_doc.Text))
                if (txt_nro_doc.Text.Length != 8 && txt_nro_doc.Text.Length != 7 && txt_nro_doc.Text.Length != 6)
                    MessageBox.Show("El Numero de Documento debe ser de 6 a 8 dígitos");

                else if (this.IDCliente > 0)
                {
                    //Modificar
                    //Validar DNI duplicado
                    if (!Client.EsValidoDocModif(txt_nro_doc.Text, this.clienteBase.NroDoc.Trim(), cmb_tipo_doc.SelectedItem.ToString(), this.clienteBase.TipoDoc))
                        MessageBox.Show("El Tipo y Numero de Documento ya existe");
                    else if (!Client.EsValidoCuilModif(txt_cuil.Text, this.clienteBase.Cuil.Trim()))
                        MessageBox.Show("El CUIL ya existe");
                    else
                    {

                        this.clienteModificado.Apellido = txt_apellido.Text;
                        this.clienteModificado.Nombre = txt_nombre.Text;
                        this.clienteModificado.TipoDoc = cmb_tipo_doc.SelectedItem.ToString();
                        this.clienteModificado.NroDoc = txt_nro_doc.Text;
                        this.clienteModificado.Cuil = txt_cuil.Text;
                        this.clienteModificado.FechaNac = fechaNac.Value;
                        this.clienteModificado.Tarj = txt_tarj.Text;

                        Client.ModificarCliente(this.clienteModificado);

                        this.direccionModificado.Calle = txt_calle.Text;
                        this.direccionModificado.CodigoPostal = txt_cp.Text;
                        this.direccionModificado.Departamento = txt_departamento.Text;
                        this.direccionModificado.Localidad = txt_localidad.Text;
                        this.direccionModificado.Mail = txt_mail.Text;
                        this.direccionModificado.Numero = txt_numero.Text;
                        this.direccionModificado.Piso = txt_piso.Text;
                        this.direccionModificado.Telefono = txt_tel.Text;

                        Adress.ModificarDireccion(this.direccionModificado);
                        MessageBox.Show("Cliente modificado");
                        this.Close();
                        this.fr.Show();

                    }
                }
                else
                {
                    //Alta
                    if (!Client.EsValidoCuil(txt_cuil.Text))
                        MessageBox.Show("El CUIL ya existe");
                    //Validar CUIL DNI duplicado
                    else if (!Client.EsValidoDoc(txt_nro_doc.Text, cmb_tipo_doc.SelectedItem.ToString()))
                        MessageBox.Show("El Tipo y Numero de Documento ya existe");
                    else
                    {
                        //Crear Usuario automatico
                        String usuarioAlternativo = "";
                        Usuario usuario;
                        int idUser;
                        if (!User.EsValidoUserName(txt_nro_doc.Text.Trim()))
                        {
                            usuarioAlternativo = String.Concat(txt_nro_doc.Text.Trim(), txt_apellido.Text.Trim());
                            usuario = new Usuario(usuarioAlternativo, usuarioAlternativo, true, 0);
                            User.CrearUsuario(usuario);
                            idUser = User.ObtenerIDUsuario(usuarioAlternativo);
                        }
                        else
                        {
                            usuario = new Usuario(txt_nro_doc.Text.Trim(), txt_nro_doc.Text.Trim(), true, 0);
                            User.CrearUsuario(usuario);
                            idUser = User.ObtenerIDUsuario(txt_nro_doc.Text.Trim());
                        }
                        
                        //RolxUsuario Cliente
                        Role.CrearRolxUsuario(3, idUser);
                        //Crear Direccion
                        Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                        Adress.CrearDireccion(direccion);
                        int idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                        //Crear Cliente
                        Cliente cliente = new Cliente();
                        cliente.Apellido = txt_apellido.Text;
                        cliente.Nombre = txt_nombre.Text;
                        cliente.TipoDoc = cmb_tipo_doc.SelectedItem.ToString();
                        cliente.NroDoc = txt_nro_doc.Text;
                        cliente.Cuil = txt_cuil.Text;
                        cliente.FechaNac = fechaNac.Value;
                        cliente.Tarj = txt_tarj.Text;
                        cliente.IdUsuario = idUser;
                        cliente.IdDireccion = idDireccion;
                        Client.CrearCliente(cliente);
                        if (!String.IsNullOrEmpty(usuarioAlternativo))
                            MessageBox.Show(String.Format("El usuario {0} ya existia. Se creo el usuario {1}", txt_nro_doc.Text.Trim(), usuarioAlternativo));
                        MessageBox.Show("Cliente creado");
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
