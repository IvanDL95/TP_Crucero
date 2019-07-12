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
using MiLibreria.Modelo;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace FrbaCrucero.Compra_Reservar
{
    public partial class CargarCliente : Form
    {
        Int32 IDCliente;
        Cliente clienteModificado = new Cliente();
        Direccion direccionModificado = new Direccion();
        Cliente clienteBase = new Cliente();
        bool esModificacion = false;
        FormCompraReservar fr;
        public CargarCliente(FormCompraReservar fr)
        {
            InitializeComponent();
            txt_nro_doc.MaxLength = 8;
            this.fr = fr;
        }

        private bool ConfirmarModificar()
        {
            DialogResult result = MessageBox.Show("¿Desea modificar los datos del cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nro_doc.Text))
            {
                MessageBox.Show("Complete el número de documento");
            }
            else
            {
                if (txt_nro_doc.Text.Trim().Length >= 7 )
                {                            

                    if (Client.ExisteDoc(Convert.ToInt32(txt_nro_doc.Text.Trim()))>0)
                    //Traer cliente
                    {
                        //Validar si tiene un viaje 
                        if(CompraFunc.ValidarClienteViaje(this.fr.FechaDesde, this.fr.FechaHasta, Convert.ToInt32(txt_nro_doc.Text.Trim()), this.fr.puertoDesde, this.fr.puertoHasta))
                        {

                            this.esModificacion = true;

                            //Confirmar modificar
                            if (ConfirmarModificar())
                            {
                                btBuscar.Visible = false;
                                btCancelarBuscar.Visible = false;
                                label3.Visible = true;
                                label3.Text = "Ingrese los datos a modificar del cliente:";
                                txt_nro_doc.Enabled = false;
                                txt_apellido.Enabled = true;
                                txt_calle.Enabled = true;
                                txt_mail.Enabled = true;
                                txt_nombre.Enabled = true;
                                txt_numero.Enabled = true;
                                txt_tel.Enabled = true;
                                btAceptar.Enabled = true;
                                btCancelar.Enabled = true;
                                fechaNac.Enabled = true;

                                Int32 IDCliente = Convert.ToInt32(txt_nro_doc.Text.Trim());
                                this.IDCliente = IDCliente;
                                //Modificar
                                Cliente cliente = new Cliente();

                                //Obtener Cliente
                                SqlDataReader reader = Client.ObtenerCliente(IDCliente);

                                cliente = Client.ObtenerClienteDesdeUnReader(reader);

                                //Obtener Direccion
                                Int32 IDDireccion = cliente.IdDireccion;
                                Direccion direccion = Adress.ObtenerDireccionDesdeUnReader(Adress.ObtenerDireccion(IDDireccion));
                                //Llenar textos
                                txt_nombre.Text = cliente.Nombre.Trim();
                                txt_apellido.Text = cliente.Apellido.Trim();
                                fechaNac.Value = cliente.FechaNac;
                                this.clienteModificado.NroDoc = this.IDCliente;
                                this.direccionModificado.Id = IDDireccion;
                                this.clienteBase = cliente;
                                txt_calle.Text = direccion.Calle.Trim();
                                txt_numero.Text = direccion.Numero.Trim();
                                if (!String.IsNullOrEmpty(direccion.Telefono))
                                    txt_tel.Text = direccion.Telefono.Trim();
                                if (!String.IsNullOrEmpty(direccion.Mail))
                                    txt_mail.Text = direccion.Mail.Trim();
                            }
                            else
                            {
                                this.fr.idCliente = Convert.ToInt32(txt_nro_doc.Text.Trim());
                                MessageBox.Show("Se continua con la operación sin modificar los datos");
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Un cliente no puede viajar a más de un destino a la vez");
                            this.Close();
                        }

                    }
                    else
                    {
                        //Cargar Doc (Nuevo cliente)
                        btBuscar.Visible = false;
                        btCancelarBuscar.Visible = false;
                        label3.Visible = true;
                        txt_nro_doc.Enabled = false;
                        txt_apellido.Enabled = true;
                        txt_calle.Enabled = true;
                        txt_mail.Enabled = true;
                        txt_nombre.Enabled = true;
                        txt_numero.Enabled = true;
                        txt_tel.Enabled = true;
                        btAceptar.Enabled = true;
                        btCancelar.Enabled = true;
                        fechaNac.Enabled = true; 
                    }

                }else
                    MessageBox.Show("El número de documento debe ser de 8 dígitos");
            }
  
        }

        private void ValidacionesIniciales()
        {
            //GDT: Me aseguro que no rompa la base.
            txt_nombre.MaxLength = 30;
            txt_apellido.MaxLength = 30;
            txt_nro_doc.MaxLength = 8;

            txt_calle.MaxLength = 70;
            txt_numero.MaxLength = 5;
            txt_tel.MaxLength = 18;
            txt_mail.MaxLength = 50;
        }

        private bool ValidarCamposVacios()
        {
            if (txt_nombre.Text == "" || txt_apellido.Text == "" || txt_nro_doc.Text == "" || txt_numero.Text == "" || txt_tel.Text == "")
                return true;
            return false;
        }

        private void btAceptar_Click_1(object sender, EventArgs e)
        {
            //Validar
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar mail   
            else 
                if (!string.IsNullOrEmpty(txt_mail.Text)){
                    if (!util.IsValidEmail(txt_mail.Text))
                      MessageBox.Show("El Email ingresado no es válido");
                }
            if(esModificacion){

                    //Modificar


                        this.clienteModificado.Apellido = txt_apellido.Text;
                        this.clienteModificado.Nombre = txt_nombre.Text;
                        this.clienteModificado.FechaNac = fechaNac.Value;

                        Client.ModificarCliente(this.clienteModificado);

                        this.direccionModificado.Calle = txt_calle.Text;
                        this.direccionModificado.Mail = txt_mail.Text;
                        this.direccionModificado.Numero = txt_numero.Text;
                        this.direccionModificado.Telefono = txt_tel.Text;

                        Adress.ModificarDireccion(this.direccionModificado);
                        MessageBox.Show("Cliente modificado");
                        this.fr.idCliente = this.clienteModificado.NroDoc;
                        this.Close();
            }
                    
            
                else
                {
                        //Crear Usuario automatico
                        String usuarioAlternativo = "";
                        Usuario usuario;
                        int idUser;
                        usuarioAlternativo = txt_nro_doc.Text.Trim();
                        usuario = new Usuario(usuarioAlternativo, usuarioAlternativo, true, 0);
                        User.CrearUsuario(usuario);
                        idUser = User.ObtenerIDUsuario(usuarioAlternativo);                        

                        //RolxUsuario Cliente
                        Role.CrearRolxUsuario(2, idUser);
                        //Crear Direccion
                        int idDireccion;
                        if (!string.IsNullOrEmpty(txt_mail.Text))
                            idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_tel.Text, txt_mail.Text);
                        else
                            idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_tel.Text);

                        if (idDireccion == 0)
                        {
                            Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_tel.Text, txt_mail.Text);
                            Adress.CrearDireccion(direccion);
                            if (!string.IsNullOrEmpty(txt_mail.Text))
                                idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_tel.Text, txt_mail.Text);
                            else
                                idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_tel.Text);
                        }
                        
                        //Crear Cliente
                        Cliente cliente = new Cliente();
                        cliente.Apellido = txt_apellido.Text;
                        cliente.Nombre = txt_nombre.Text;
                        cliente.NroDoc = Convert.ToInt32(txt_nro_doc.Text.Trim());
                        cliente.FechaNac = fechaNac.Value;
                        cliente.IdUsuario = idUser;
                        cliente.IdDireccion = idDireccion;
                        Client.CrearCliente(cliente);
                        MessageBox.Show("Cliente creado");
                        this.fr.idCliente = Convert.ToInt32(txt_nro_doc.Text.Trim());
                        this.Close();
                    }
                }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Necesita aceptar la creación o modificación de los datos del cliente para realizar una compra o reserva");
            this.fr.idCliente = 0;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Necesita cargar su número de documento para realizar una compra o reserva");
            this.fr.idCliente = 0;
            this.Close();
        }

        
    }
}
