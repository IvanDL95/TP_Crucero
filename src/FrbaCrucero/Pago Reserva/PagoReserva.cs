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
using FrbaCrucero.Compra_Reservar;

namespace FrbaCrucero.Pago_Reserva
{
    public partial class PagoReserva : Form
    {
        DataTable cabinasCompradas;

        public PagoReserva ()
        {
            InitializeComponent();
            CargarComboMp();
            //Crea tabla ubicacionesCompradas
            this.cabinasCompradas = new DataTable("cabinasCompradas");
            DataColumn workCol = this.cabinasCompradas.Columns.Add("cab_via_id", typeof(Int32));
            workCol.AllowDBNull = false;
            this.cabinasCompradas.Columns.Add("cab_precio", typeof(Decimal));
            DataColumn workCol2 = this.cabinasCompradas.Columns.Add("cab_nro", typeof(Int32));
            workCol2.AllowDBNull = false;
            DataColumn workCol3 = this.cabinasCompradas.Columns.Add("cab_piso", typeof(Int32));
            workCol3.AllowDBNull = false;
            DataColumn workCol4 = this.cabinasCompradas.Columns.Add("cab_tcab_id", typeof(Int32));
            workCol4.AllowDBNull = false;
            this.cabinasCompradas.Columns.Add("pue_id_hasta", typeof(Int32));

            Constraint constraint = new UniqueConstraint("constraint1",
            new DataColumn[] {this.cabinasCompradas.Columns["cab_via_id"],
            this.cabinasCompradas.Columns["cab_nro"],
            this.cabinasCompradas.Columns["cab_piso"],
            this.cabinasCompradas.Columns["cab_tcab_id"]}, false);
            this.cabinasCompradas.Constraints.Add(constraint);

            
            
            dgv_cabina.AllowUserToAddRows = false;
        }


        private void CargarComboMp()
        {
            SqlDataReader reader = CompraFunc.ObtenerMp();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    MedioPago mp = new MedioPago();
                    mp.mp_id = Convert.ToInt32(reader.GetDecimal(0));
                    mp.mp_desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = mp.mp_desc;
                    item.Value = mp;
                    cmb_mp.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void btCabDisponibles_Click(object sender, EventArgs e)
        {
            dgv_cabina.Refresh();
                //dgv_cabina.Rows.Clear();

                if (txt_reserva.Text == "")
                    MessageBox.Show("Ingrese Reserva");
                else
                {
                    dgv_cabina.AllowUserToAddRows = true;
                    dgv_cabina.DataSource = CompraFunc.VerificarReserva(Convert.ToInt32(txt_reserva.Text.Trim())).Tables[0];
                }

            dgv_cabina.AllowUserToAddRows = false;
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            if (dgv_cabina.Rows.Count > 0)
            {

                DataRow row = this.cabinasCompradas.NewRow();
                DataGridViewRow dataRow = dgv_cabina.Rows[(dgv_cabina.CurrentRow.Index)];
                int idViaje = ABMCabina.ObtenerIDViaje(Convert.ToInt32(txt_reserva.Text.Trim()));
                int idTipo = ABMCabina.ObtenerIDTipo(dataRow.Cells["TipoCabina"].Value.ToString());

                row["cab_via_id"] = idViaje;
                row["cab_precio"] = dataRow.Cells["Precio"].Value.ToString();
                row["cab_nro"] = dataRow.Cells["Numero"].Value.ToString();
                row["cab_piso"] = dataRow.Cells["Piso"].Value.ToString();
                row["cab_tcab_id"] = idTipo;
                row["pue_id_hasta"] = ABMCabina.ObtenerIDPuerto(dataRow.Cells["PuertoHasta"].Value.ToString());
                this.cabinasCompradas.Rows.Add(row);

                dgv_cabina.Enabled = false;
                btCabDisponibles.Enabled = false;
                btComprarReservar.Enabled = false;

                //Medio de pago                
                lb_mp.Visible = true;
                lb_selec.Visible = true;
                bt_mp.Visible = true;
                cmb_mp.Visible = true;
            }else
                MessageBox.Show("Ingrese una reserva valida");

        }


        private void bt_mp_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(cmb_mp.Text))
                MessageBox.Show("Elija medio de pago");
            else
            {
                //Credito
                if (CompraFunc.ObtenerIDMp(cmb_mp.Text)==2)
                {
                    lb_cuota.Visible = true;
                    bt_cuota.Visible = true;
                    cmb_cuota.Visible = true;
                    bt_mp.Enabled = false;
                    cmb_mp.Enabled = false;
                }
                else
                {
                    //Compra
                    DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                    Compra compra = new Compra();
                    compra.com_fecha = fechaSistema;
                    DataGridViewRow dataRow = dgv_cabina.Rows[(dgv_cabina.CurrentRow.Index)];
                    compra.com_cli = Convert.ToInt32(dataRow.Cells["Documento"].Value.ToString());
                    compra.com_tipoDoc = Convert.ToInt32(Client.ObtenerIDTipoDoc(dataRow.Cells["TipoDoc"].Value.ToString()));
                    compra.cabinas = this.cabinasCompradas;
                    compra.com_mp = CompraFunc.ObtenerIDMp(cmb_mp.Text);
                    SqlDataReader reader = CompraFunc.CrearCompra(compra);

                    Int32 idCompra =0;

                    if (reader.Read())
                    {
                        idCompra = Convert.ToInt32(reader.GetDecimal(0));
                    }
                    
                    CompraFunc.ComprarReserva(Convert.ToInt32(txt_reserva.Text.Trim()));
                    MessageBox.Show("Compra realizada");
                    MostrarVoucher mv = new MostrarVoucher(compra, null, idCompra, true);
                    this.Hide();
                    mv.ShowDialog();
                    this.Close();

                }
            }

        }

        private void bt_cuota_Click(object sender, EventArgs e)
        {             
            
            if (string.IsNullOrEmpty(cmb_cuota.Text))
                MessageBox.Show("Elija cantidad de cuotas");
            else
            {

                //Compra
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                Compra compra = new Compra();
                compra.com_fecha = fechaSistema;
                DataGridViewRow dataRow = dgv_cabina.Rows[(dgv_cabina.CurrentRow.Index)];
                compra.com_cli = Convert.ToInt32(dataRow.Cells["Documento"].Value.ToString());
                compra.com_tipoDoc = Convert.ToInt32(Client.ObtenerIDTipoDoc(dataRow.Cells["TipoDoc"].Value.ToString()));
                compra.cabinas = this.cabinasCompradas;
                compra.com_mp = CompraFunc.ObtenerIDMp(cmb_mp.Text);
                compra.com_detalle = String.Concat("N° Cuotas: ", cmb_cuota.Text);
                SqlDataReader reader = CompraFunc.CrearCompra(compra);

                Int32 idCompra = 0;

                if (reader.Read())
                {
                    idCompra = Convert.ToInt32(reader.GetDecimal(0));
                }
                CompraFunc.ComprarReserva(Convert.ToInt32(txt_reserva.Text.Trim()));
                MessageBox.Show("Compra realizada");
                MostrarVoucher mv = new MostrarVoucher(compra,null, idCompra, true);
                this.Hide();
                mv.ShowDialog();
                this.Close();
            }
        }

    }
}
