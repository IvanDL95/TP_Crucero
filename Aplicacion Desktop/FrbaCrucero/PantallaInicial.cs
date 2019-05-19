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

        ContenedorPrincipal cpal;
        InicioCliente icliente;

        public PantallaIncial(ContenedorPrincipal cpal)
        {
            InitializeComponent();
            if (cpal == null)
                this.cpal = null;
            else
                this.cpal = cpal;
        }


        private void btCliente_Click(object sender, EventArgs e)
        {

        }

        private void btAdmin_Click(object sender, EventArgs e)
        {

        }

    }
}
