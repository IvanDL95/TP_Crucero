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
    public partial class FormAbmClienteLogin : Form
    {
        RegistrarUsuario frRegistroUsuario;
        public Cliente cliente;
        public FormAbmClienteLogin(RegistrarUsuario frRegistroUsuario)
        {
            InitializeComponent();
            this.frRegistroUsuario = frRegistroUsuario;
            this.cliente = new Cliente();
            ValidacionesIniciales();
            LLenarComboTipoDoc();
        }

        private bool ValidarCamposVacios()
        {
            if (txt_nombre.Text == "" || txt_apellido.Text == "" || txt_nro_doc.Text == "" || txt_cuil.Text == "" || string.IsNullOrEmpty(cmb_tipo_doc.Text) || txt_tarj.Text == "")
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegexUtilities util = new RegexUtilities();
            //Validar campos vacios
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar cuil   
            else if (!util.ValidaCuit(txt_cuil.Text))
                MessageBox.Show("El CUIL ingresado no es válido");
            //Validar CUIL DNI duplicado
            else if (!Client.EsValidoDoc(txt_nro_doc.Text,cmb_tipo_doc.SelectedItem.ToString()))
                MessageBox.Show("El Tipo y Numero de Documento ya existe");
            //DNI 8 digitos
            else if (!string.IsNullOrEmpty(txt_nro_doc.Text))
                if (txt_nro_doc.Text.Length != 8 && txt_nro_doc.Text.Length != 7 && txt_nro_doc.Text.Length != 6)
                    MessageBox.Show("El Numero de Documento debe ser de 6 a 8 dígitos");
            else if (!Client.EsValidoCuil(txt_cuil.Text))
                MessageBox.Show("El CUIL ya existe");
            else{
            //Guarda los datos del cliente
            this.cliente.Apellido = txt_apellido.Text;
            this.cliente.Nombre = txt_nombre.Text;
            this.cliente.NroDoc = txt_nro_doc.Text;
            this.cliente.FechaNac = fechaNac.Value;
            this.Close();
            this.frRegistroUsuario.Show();

            }
        }
        private void ValidacionesIniciales()
        {
            txt_nombre.MaxLength = 30;
            txt_apellido.MaxLength = 30;
            txt_nro_doc.MaxLength = 8;
            txt_cuil.MaxLength = 11;
            txt_tarj.MaxLength = 19;
        }
        private void LLenarComboTipoDoc()
        {
            cmb_tipo_doc.Items.Add("DU");
            cmb_tipo_doc.Items.Add("DNI");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.frRegistroUsuario.Show();
        }
    }
}
