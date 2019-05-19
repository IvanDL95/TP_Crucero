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
using System.Globalization;

namespace FrbaCrucero.Canjear_Puntos
{
    public partial class FormCanjearPuntos : Form
    {
        Int32 idCliente;

        public FormCanjearPuntos(String user, bool esAdm)
        {
            InitializeComponent();

            if (esAdm)
            {
                MessageBox.Show("El usuario Admin no puede canjear puntos");
                this.Close();
            }
            else
            {

                int iduser = User.ObtenerIDUsuario(user);
                this.idCliente = Client.ObtenerIDClienteUser(iduser);

                //Puntos
                SqlDataReader reader = Client.ObtenerPuntosCliente(this.idCliente);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            lbPuntos.Text = reader.GetInt32(0).ToString();
                        if (!reader.IsDBNull(1))
                            lbVencimiento.Text = reader.GetDateTime(1).ToString();
                        else
                            lbVencimiento.Text = " ";
                    }
                }

                //Premios
                DataSet ds = PremioFunc.ListarPremiosExistentes();

                //Set the source table.
                dgv_premios.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count != 0)
                    dgv_premios.Columns["id"].Visible = false;
            }
        }

        private bool ValidarVencimiento(String fechaVencimientostr)
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaVencimiento;
            //Regulariza las fechas
            if (fechaVencimientostr.Contains("0:00:00"))
            {
                string[] words = fechaVencimientostr.Split(' ');
                fechaVencimientostr = string.Concat(words[0], " ", "00:00");
            }
            String format = "g";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fechaVencimiento = DateTime.ParseExact(fechaVencimientostr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaVencimientostr), "Error");
                return true;
            }
            if (DateTime.Compare(fechaSistema, fechaVencimiento) > 0)
            {
                MessageBox.Show(String.Format("Puntos vencidos. Fecha vencimiento {0} menor a Fecha de Sistema {1}", fechaVencimientostr, fechaSistema.ToString()));
                return true;
            }
            return false;
        }  

        private void btCanjear_Click(object sender, EventArgs e)
        {
            //No tiene puntos
            if(Convert.ToInt32(lbPuntos.Text)==0)
                MessageBox.Show("No tiene puntos disponibles para canjear");
            //Validar fecha vencimiento
            else if (ValidarVencimiento(lbVencimiento.Text)){

            //Alcanza cantidad disponible
            }
            else if (Convert.ToInt32(lbPuntos.Text) < Convert.ToInt32(dgv_premios.CurrentRow.Cells[2].Value))
            {
                MessageBox.Show("Los puntos disponibles no alcanzan para canjear el premio");
            }else{
                //Canje
                PremioFunc.CanjearPuntos(this.idCliente, Convert.ToInt32(dgv_premios.CurrentRow.Cells[0].Value));
                MessageBox.Show("Premio canjeado");

                //Renovar puntos y vencimiento
                SqlDataReader reader = Client.ObtenerPuntosCliente(this.idCliente);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            lbPuntos.Text = reader.GetInt32(0).ToString();
                        if (!reader.IsDBNull(1))
                            lbVencimiento.Text = reader.GetDateTime(1).ToString();
                        else
                            lbVencimiento.Text = " ";
                    }
                }
            }
            


        }
    }
}
