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

namespace FrbaCrucero.Compra_Reservar
{
    public partial class CabinaDisponible : Form
    {
        DataTable cabinasCompradas;
        Int32 idCliente;
        Int32 tipoDoc;
        Int32 idViaje;
        Int32 idRecorrido;
        Int32 puertoDesde;
        Int32 puertoHasta;
        Int32 mp_id;
        bool esCompra;

        public CabinaDisponible(Compra compra, Int32 idViaje, Int32 idCliente, Int32 tipoDoc, Int32 idRecorrido, Int32 puertoDesde, Int32 puertoHasta, bool esCompra)
        {
            InitializeComponent();
            CargarComboTipoCabina();
            CargarComboMp();
            this.idViaje = idViaje;
            this.idCliente = idCliente;
            this.tipoDoc = tipoDoc;
            this.idRecorrido = idRecorrido;
            this.puertoDesde = puertoDesde;
            this.puertoHasta = puertoHasta;
            this.esCompra = esCompra;

            if (this.esCompra)
            {
                btAgregarCabina.Text = "Agregar a la compra";
                btComprarReservar.Text = "Finalizar Comprar";
            }
            else
            {
                btAgregarCabina.Text = "Agregar a la reserva";
                btComprarReservar.Text = "Finalizar Reserva";
            }

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

        private void CargarComboTipoCabina()
        {
            SqlDataReader reader = Cabina_crucerofunc.ObtenerTipos();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TipoCabina tipoCabina = new TipoCabina();
                    tipoCabina.tcab_id = Convert.ToInt32(reader.GetDecimal(0));
                    tipoCabina.tcab_tipo = reader.GetString(1);
                    tipoCabina.tcab_porc_recargo = reader.GetDecimal(2);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = tipoCabina.tcab_tipo;
                    item.Value = tipoCabina;
                    cmb_tipo.Items.Add(item);
                }
            }
            reader.Close();
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
            //Validar Tipo
            if (string.IsNullOrEmpty(cmb_tipo.Text))
                MessageBox.Show("Elija tipo de cabina");
            else
            {
                dgv_cabina.Refresh();
                dgv_cabina.Rows.Clear();


                Int32 idViaje = this.idViaje;
                Int32 idTipo = ABMCabina.ObtenerIDTipo(cmb_tipo.Text.Trim());

                DataTable cabinas = ABMCabina.ObtenerCabinasSinCompra(idViaje, idTipo);
                //Si hay ubicaciones
                if (cabinas.Rows.Count > 0)
                {
                    //cab_tcab_id,cab_piso,cab_nro,cab_via_id
                    
                    dgv_cabina.AllowUserToAddRows = true;
                    int cantCabinas = cabinas.Rows.Count;
                    //Se agragan las filas necesarias          
                    for (Int32 j = 0; j < cabinas.Rows.Count; j++)
                    {
                        DataGridViewRow rowCab = (DataGridViewRow)dgv_cabina.Rows[0].Clone();
                        dgv_cabina.Rows.Add(rowCab);
                    }

                    //Se agregan los datos en las filas
                    for (Int32 i = 0; i < cabinas.Rows.Count; i++)
                    {
                        dgv_cabina.Rows[i].Cells[0].Value = cabinas.Rows[i]["cab_tcab_id"].ToString(); ;
                        dgv_cabina.Rows[i].Cells[1].Value = cabinas.Rows[i]["cab_piso"].ToString();
                        dgv_cabina.Rows[i].Cells[2].Value = cabinas.Rows[i]["cab_nro"].ToString();  //.Replace(",", ".").Replace(".", ".");
                        //Precio = (Suma precio de tramos * Porc)/100 + Suma precio de tramos
                        dgv_cabina.Rows[i].Cells[3].Value = Math.Round((ABMCabina.ObtenerPorc(Convert.ToInt32(cabinas.Rows[i]["cab_tcab_id"])) * ABMCabina.ObtenerPrecioRecorrido(this.idRecorrido,this.puertoDesde,this.puertoHasta)/100) +ABMCabina.ObtenerPrecioRecorrido(this.idRecorrido,this.puertoDesde,this.puertoHasta),2);
                        dgv_cabina.Rows[i].Cells[4].Value = cabinas.Rows[i]["cab_via_id"].ToString();
                    }                    

                    //Marcar las filas que ya fueron seleccionadas para comprar
                    if (this.cabinasCompradas.Rows.Count > 0)
                        for (Int32 j = 0; j < this.cabinasCompradas.Rows.Count; j++)
                        {
                            for (Int32 j2 = 0; j2 < this.dgv_cabina.Rows.Count - 1; j2++)
                            {
                                if (string.Compare(dgv_cabina.Rows[j2].Cells[0].Value.ToString(), this.cabinasCompradas.Rows[j]["cab_tcab_id"].ToString()) == 0 
                                    && string.Compare(dgv_cabina.Rows[j2].Cells[1].Value.ToString(), this.cabinasCompradas.Rows[j]["cab_piso"].ToString()) == 0
                                    && string.Compare(dgv_cabina.Rows[j2].Cells[2].Value.ToString(), this.cabinasCompradas.Rows[j]["cab_nro"].ToString()) == 0
                                    && string.Compare(dgv_cabina.Rows[j2].Cells[4].Value.ToString(), this.cabinasCompradas.Rows[j]["cab_via_id"].ToString()) == 0
                                    )
                                    dgv_cabina.Rows[j2].DefaultCellStyle.BackColor = Color.Aqua;
                            }
                        }

                    dgv_cabina.AllowUserToAddRows = false;
                }
            }
        }

        private void btAgregarCabina_Click(object sender, EventArgs e)
        {
            if (dgv_cabina.CurrentRow == null)
                MessageBox.Show("No hay cabina seleccionada");
            else{

                dgv_cabina.CurrentRow.DefaultCellStyle.BackColor = Color.Aqua;
                DataRow row = this.cabinasCompradas.NewRow();
                DataGridViewRow dataRow = dgv_cabina.Rows[(dgv_cabina.CurrentRow.Index)];
                row["cab_via_id"] = dataRow.Cells["cab_via_id"].Value.ToString();
                row["cab_precio"] = Convert.ToDecimal(dataRow.Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                row["cab_nro"] = dataRow.Cells["colNumero"].Value.ToString();
                row["cab_piso"] = dataRow.Cells["colPiso"].Value.ToString();
                row["cab_tcab_id"] = dataRow.Cells["colTipoCabina"].Value.ToString();
                row["pue_id_hasta"] = this.puertoHasta;
                try
                {
                    this.cabinasCompradas.Rows.Add(row);
                }
                catch (ConstraintException)
                {
                    MessageBox.Show("La cabina ya fue agregada para la compra");
                }
                
            }

        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            if (this.cabinasCompradas.Rows.Count == 0)
            {
                MessageBox.Show("No hay cabinas agregadas para la compra");
            }

            if (esCompra)
            {
                dgv_cabina.Enabled = false;
                btAgregarCabina.Enabled = false;
                btCabDisponibles.Enabled = false;
                cmb_tipo.Enabled = false;
                btComprarReservar.Enabled = false;

                //Medio de pago                
                lb_mp.Visible = true;
                lb_selec.Visible = true;
                bt_mp.Visible = true;
                cmb_mp.Visible = true;    
            }
            else
            {
                //Reserva
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                Reserva reserva = new Reserva();
                reserva.res_fecha = fechaSistema;
                reserva.res_cli = this.idCliente;
                reserva.res_tipoDoc = this.tipoDoc;
                reserva.cabinas = cabinasCompradas;
                CompraFunc.CrearReserva(reserva);
                MessageBox.Show("Reserva realizada");

                MostrarVoucher mv = new MostrarVoucher(null, reserva, 0, this.esCompra);
                this.Hide();
                mv.ShowDialog();
                this.Close();

            }
            
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
                    compra.com_cli = this.idCliente;
                    compra.com_tipoDoc = this.tipoDoc;
                    compra.cabinas = cabinasCompradas;
                    compra.com_mp = CompraFunc.ObtenerIDMp(cmb_mp.Text);
                    SqlDataReader reader = CompraFunc.CrearCompra(compra);

                    Int32 idCompra =0;

                    if (reader.Read())
                    {
                        idCompra = Convert.ToInt32(reader.GetDecimal(0));
                    }
                    
                    MessageBox.Show("Compra realizada");
                    MostrarVoucher mv = new MostrarVoucher(compra, null, idCompra, this.esCompra);
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
                compra.com_cli = this.idCliente;
                compra.com_tipoDoc = this.tipoDoc;
                compra.cabinas = cabinasCompradas;
                compra.com_mp = CompraFunc.ObtenerIDMp(cmb_mp.Text);
                compra.com_detalle = String.Concat("N° Cuotas: ", cmb_cuota.Text);
                SqlDataReader reader = CompraFunc.CrearCompra(compra);

                Int32 idCompra = 0;

                if (reader.Read())
                {
                    idCompra = Convert.ToInt32(reader.GetDecimal(0));
                }

                MessageBox.Show("Compra realizada");
                MostrarVoucher mv = new MostrarVoucher(compra,null, idCompra, this.esCompra);
                this.Hide();
                mv.ShowDialog();
                this.Close();
            }
        }

    }
}
