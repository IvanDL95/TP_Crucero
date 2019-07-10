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
using System.Configuration;
using System.Data.SqlClient;


namespace FrbaCrucero
{


    public partial class Login : Form
    {

        class Rol
        {
            public int id_rol;
            public string str_rol;

            public override string ToString()
            {
                return str_rol;
            }
        }

        int id;
        string user;
        ContenedorPrincipal cpal;

        public Login(ContenedorPrincipal cpal)
        {
            InitializeComponent();
            if (cpal == null)
                this.cpal = null;
            else
                this.cpal = cpal;
        }

        public void LimpiarCampos()
        {
            this.txt_user.Text = "";
            this.txt_pass.Text = "";
        }

        public void HabilitarSeleccionRol(bool estado)
        {
            txt_user.Enabled = estado;
            txt_pass.Enabled = estado;
            lbl_user.Enabled = estado;
            lbl_pass.Enabled = estado;
            cmb_rol.Visible = !estado;
            lbl_rol.Visible = !estado;
            btn_elegir_rol.Visible = !estado;
        }

        public string ValidarCampos()
        {
            if (txt_user.Text.Length == 0)
            {
                return "Ingrese el Usuario";
            }

            if (txt_pass.Text.Length == 0)
            {
                return "Ingrese el Password";
            }

            return string.Empty;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            string cadenaValidacion = ValidarCampos();
            if (cadenaValidacion != string.Empty)
            {
                MessageBox.Show(cadenaValidacion);
                return;
            }

            this.user = txt_user.Text.Trim();
            string pass = txt_pass.Text.Trim();
            int cantidadRoles;

            int resultado = User.Autenticar(user, pass);

            switch (resultado)
            {

                case 0: MessageBox.Show("Usuario Inexistente");
                    LimpiarCampos();
                    txt_user.Focus();
                    break;

                case 1: MessageBox.Show("Login incorrecto");
                    User.RegistrarIntentoFallido(user);
                    LimpiarCampos();
                    txt_user.Focus();
                    break;

                case 2: MessageBox.Show("Usuario Bloqueado. Por favor contáctese con el Administrador");
                    this.Close();
                    break;

                case 3: HabilitarSeleccionRol(false);

                    cantidadRoles = User.CantidadDeRoles(user);

                    if (cantidadRoles == 0)
                    {
                        MessageBox.Show("No dispone de roles activos.");
                        this.Close();
                        return;
                    }else if (cantidadRoles == 1){                        
                        Rol rol = new Rol();
                        rol.id_rol = ObtenerRol(user);

                        //Activa primer inicio
                        Boolean primerInicio=false;
                        if (String.Compare(user, pass) == 0)
                            primerInicio = true;

                        if (this.cpal == null)
                        {

                            ContenedorPrincipal cppal = new ContenedorPrincipal(this.id, this.user, rol.id_rol, primerInicio, false);
                            this.Hide();
                            if (!cppal.IsDisposed)
                                cppal.ShowDialog();                            
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                            this.cpal.id = this.id;
                            this.cpal.usuario = this.user;
                            this.cpal.id_rol = rol.id_rol;
                            this.cpal.inicializar(this.id, this.user, rol.id_rol, primerInicio,true);
                            this.cpal.Show();
                            this.Close();
                        }

                    }
                    else if (cantidadRoles > 1)
                    {
                        btn_iniciar.Enabled = false;
                        HabilitarSeleccionRol(false);
                        this.id = LLenarCombo(user);
                    }

                    btn_elegir_rol.Click += new EventHandler(this.btn_elegir_rol_Click);

                    break;

                default: break;
            }
        }

        private int ObtenerRol(string user)
        {
            int id = User.ObtenerIDUsuario(user);

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_ROLES_ACTIVOS", DataBase.Tipos.StoredProcedure, parametros);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader.GetDecimal(1));
                }
            }

            reader.Close();
            return id;

        }

        private int LLenarCombo(string user)
        {
            int id = User.ObtenerIDUsuario(user);

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID", id));
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_ROLES_ACTIVOS", DataBase.Tipos.StoredProcedure, parametros);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rol rol = new Rol();
                    rol.id_rol = Convert.ToInt32(reader.GetDecimal(1));
                    rol.str_rol = reader.GetString(0);
                    cmb_rol.Items.Add(rol);
                }
            }

            reader.Close();
            return id;

        }

        private void btn_elegir_rol_Click(object sender, EventArgs e)
        {
            // Aca hay que ver como entrar al contenedor ppal viendo solo 
            //llamar al contenedor ppal con id como parametro
            Rol rol = new Rol();
            rol = (Rol)cmb_rol.SelectedItem;
            if (this.cpal == null)
            {
                ContenedorPrincipal cppal = new ContenedorPrincipal(this.id, this.user, rol.id_rol,false,false);
                this.Hide();
                cppal.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                this.cpal.id = this.id;
                this.cpal.usuario = this.user;
                this.cpal.id_rol = rol.id_rol;
                this.cpal.inicializar(this.id, this.user, rol.id_rol,false,true);
                this.cpal.Show();
                this.Close();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            //RegistrarUsuario fr = new RegistrarUsuario();
            this.Hide();
            //fr.ShowDialog();
            this.Show();
        }

    }
}
