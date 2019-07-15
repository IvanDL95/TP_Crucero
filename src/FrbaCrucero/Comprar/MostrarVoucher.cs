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
    public partial class MostrarVoucher : Form
    {
       
        DataSet ds;

        public MostrarVoucher(Compra compra,Reserva reserva, int idCompra, bool esCompra)
        {
            InitializeComponent();

            if (esCompra)
            {
                //Compra
                label1.Text = "Compra";
                dgv_listado.DataSource = CompraFunc.VoucherCompra(compra,idCompra).Tables[0];
            }
            else
            {
                //Reserva
                label1.Text = "Reserva";
                dgv_listado.DataSource = CompraFunc.VoucherReserva(reserva).Tables[0];
            }

        }

        private void btAceptar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
