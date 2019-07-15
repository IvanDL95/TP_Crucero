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
using MiLibreria.Modelo;


namespace FrbaCrucero
{
    public partial class PantallaIncial : Form
    {
        Login login;
        ContenedorPrincipal cpal;

        public PantallaIncial(Login login, ContenedorPrincipal cpal)
        {
            InitializeComponent();
            if (login == null)
                this.login = null;
            else
                this.login = login;

            if (cpal == null)
                this.cpal = null;
            else
                this.cpal = cpal;

        }


        private void btCliente_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol();
            rol.id = 2; //Cliente

            if (this.cpal == null)
            {
                ContenedorPrincipal cppal = new ContenedorPrincipal(0, null, rol.id, false, false);
                this.Hide();
                if (!cppal.IsDisposed)
                    cppal.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                this.cpal.id = 0;
                this.cpal.usuario = null;
                this.cpal.id_rol = rol.id;
                this.cpal.inicializar(0, null, rol.id, false, true);
                this.cpal.Show();
                this.Close();
            }      
        }

        private void btAdmin_Click(object sender, EventArgs e)
        {
            if (this.login == null)
            {
                Login login = new Login(null);
                this.Hide();
                if (!login.IsDisposed)
                    login.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                this.login.Show();
                this.Close();
            }
        }

    }
}
