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

namespace FrbaCrucero.Compra_Entrada
{
    public partial class CargarTarjeta : Form
    {
        UbicacionDisponible fr;
        Int32 idCliente;
        public CargarTarjeta(UbicacionDisponible fr, Int32 idCliente)
        {
            InitializeComponent();
            txtTarj.MaxLength = 19;
            this.fr = fr;
            this.idCliente = idCliente;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTarj.Text))
            {
                MessageBox.Show("Complete el número de tarjeta");
            }
            else
            {
                Client.CrearTarjeta(this.idCliente,txtTarj.Text.Trim());
                MessageBox.Show("Tarjeta creada. Ahora puede finalizar la compra");
                this.Close();
            }
  
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Necesita cargar su número de tarjeta en el sistema para realizar una compra");
            this.Close();
        }
    }
}
