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


    public partial class PantallaIncial : Form
    {
        Login login;
        InicioCliente icliente;

        public PantallaIncial(Login login, InicioCliente icliente)
        {
            InitializeComponent();
            if (login == null)
                this.login = null;
            else
                this.login = login;

            if (icliente == null)
                this.icliente = null;
            else
                this.icliente = icliente;

        }


        private void btCliente_Click(object sender, EventArgs e)
        {
            if (this.icliente == null)
            {

                InicioCliente icliente = new InicioCliente(null);
                this.Hide();
                if (!icliente.IsDisposed)
                    icliente.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                this.icliente.Show();
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
