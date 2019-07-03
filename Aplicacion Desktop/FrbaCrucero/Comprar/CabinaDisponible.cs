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

namespace FrbaCrucero.Compra_Entrada
{
    public partial class UbicacionDisponible : Form
    {
        DataTable ubicacionesCompradas;
        Int32 idCliente;
        Int32 idPublicacion;
        String FechaEspectaculo;
        String FechaPublicacion;

        public UbicacionDisponible(Compra compra, Int32 idPublicacion, Int32 idCliente, String FechaEspectaculo, String FechaPublicacion)
        {
            InitializeComponent();
            CargarComboTipoUbicacion();
            this.idPublicacion = idPublicacion;
            this.idCliente = idCliente;
            this.FechaEspectaculo = FechaEspectaculo;
            this.FechaPublicacion = FechaPublicacion;
            //Crea tabla ubicacionesCompradas
            this.ubicacionesCompradas = new DataTable("ubicacionesCompradas");
            DataColumn workCol = this.ubicacionesCompradas.Columns.Add("ubi_id", typeof(Int32));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            this.ubicacionesCompradas.Columns.Add("ubi_pub", typeof(Int32));
            this.ubicacionesCompradas.Columns.Add("ubi_precio", typeof(Decimal));
            dgv_ubicacion.AllowUserToAddRows = false;

        }

        private void CargarComboTipoUbicacion()
        {
            SqlDataReader reader = ABMUbicacion.ObtenerTipos();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TipoUbicacion tipoUbicacion = new TipoUbicacion();
                    tipoUbicacion.tu_id = Convert.ToInt32(reader.GetDecimal(0));
                    tipoUbicacion.tu_desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = tipoUbicacion.tu_desc;
                    item.Value = tipoUbicacion;
                    cmb_tipo.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void btUbicDisponibles_Click(object sender, EventArgs e)
        {
            //Validar Tipo
            if (string.IsNullOrEmpty(cmb_tipo.Text))
                MessageBox.Show("Elija tipo ubicacion");
            else
            {
                dgv_ubicacion.Refresh();
                dgv_ubicacion.Rows.Clear();


                Int32 idPublicacion = this.idPublicacion;
                Int32 idTipo = ABMUbicacion.ObtenerIDTipo(cmb_tipo.Text.Trim());

                DataTable ubicaciones = ABMUbicacion.ObtenerUbicacionesSinCompra(idPublicacion, idTipo);
                //Si hay ubicaciones
                if (ubicaciones.Rows.Count > 0)
                {
                    dgv_ubicacion.AllowUserToAddRows = true;
                    int cantUbicaciones = ubicaciones.Rows.Count;
                    //Se agragan las filas necesarias          
                    for (Int32 j = 0; j < ubicaciones.Rows.Count; j++)
                    {
                        DataGridViewRow rowUbic = (DataGridViewRow)dgv_ubicacion.Rows[0].Clone();
                        dgv_ubicacion.Rows.Add(rowUbic);
                    }

                    //Ubicacion sin numerar?
                    if (!Convert.ToBoolean(ubicaciones.Rows[0]["ubi_sin_numerar"]))
                    {
                        //colFila.Visible = true;
                        //colAsiento.Visible = true;

                        //Se agregan los datos en las filas
                        for (Int32 i = 0; i < ubicaciones.Rows.Count; i++)
                        {
                            dgv_ubicacion.Rows[i].Cells[0].Value = ubicaciones.Rows[i]["ubi_id"].ToString();
                            dgv_ubicacion.Rows[i].Cells[1].Value = ubicaciones.Rows[i]["ubi_fila"].ToString();
                            dgv_ubicacion.Rows[i].Cells[2].Value = ubicaciones.Rows[i]["ubi_asiento"].ToString();
                            dgv_ubicacion.Rows[i].Cells[3].Value = ubicaciones.Rows[i]["ubi_precio"].ToString().Replace(",", ".").Replace(".", ".");
                            dgv_ubicacion.Rows[i].Cells[4].Value = ABMUbicacion.ObtenerDescTipo(Convert.ToInt32(ubicaciones.Rows[i]["ubi_tipo"]));
                            dgv_ubicacion.Rows[i].Cells[5].Value = ubicaciones.Rows[i]["ubi_pub"].ToString();
                        }
                    }
                    else //Sin numerar
                    {

                        //colFila.Visible = false;
                        //colAsiento.Visible = false;

                        for (Int32 i = 0; i < ubicaciones.Rows.Count; i++)
                        {
                            dgv_ubicacion.Rows[i].Cells[0].Value = ubicaciones.Rows[i]["ubi_id"].ToString();
                            dgv_ubicacion.Rows[i].Cells[3].Value = ubicaciones.Rows[i]["ubi_precio"].ToString().Replace(",", ".").Replace(".", ".");
                            dgv_ubicacion.Rows[i].Cells[4].Value = ABMUbicacion.ObtenerDescTipo(Convert.ToInt32(ubicaciones.Rows[i]["ubi_tipo"]));
                            dgv_ubicacion.Rows[i].Cells[5].Value = ubicaciones.Rows[i]["ubi_pub"].ToString();
                        }
                    }

                    //Marcar las filas que ya fueron seleccionadas para comprar
                    if (this.ubicacionesCompradas.Rows.Count > 0)
                        for (Int32 j = 0; j < this.ubicacionesCompradas.Rows.Count; j++)
                        {
                            for (Int32 j2 = 0; j2 < this.dgv_ubicacion.Rows.Count - 1; j2++)
                            {
                                if (string.Compare(dgv_ubicacion.Rows[j2].Cells[0].Value.ToString(), this.ubicacionesCompradas.Rows[j]["ubi_id"].ToString()) == 0)
                                    dgv_ubicacion.Rows[j2].DefaultCellStyle.BackColor = Color.Aqua;
                            }
                        }

                    dgv_ubicacion.AllowUserToAddRows = false;
                }
            }
        }

        private void btAgregarUbicacion_Click(object sender, EventArgs e)
        {
            if (dgv_ubicacion.CurrentRow == null)
                MessageBox.Show("No hay ubicación seleccionada");
            else{
                dgv_ubicacion.CurrentRow.DefaultCellStyle.BackColor = Color.Aqua;

                DataRow row = this.ubicacionesCompradas.NewRow();
                DataGridViewRow dataRow = dgv_ubicacion.Rows[(dgv_ubicacion.CurrentRow.Index)];
                row["ubi_id"] = dataRow.Cells["id"].Value.ToString();
                row["ubi_pub"] = dataRow.Cells["ubi_pub"].Value.ToString();
                row["ubi_precio"] = Convert.ToDecimal(dataRow.Cells["colPrecio"].Value, CultureInfo.InvariantCulture);

                try
                {
                    this.ubicacionesCompradas.Rows.Add(row);
                }
                catch (ConstraintException)
                {
                    MessageBox.Show("La ubicación ya fue agregada para la compra");
                }
            }

        }

        private bool ValidaFechaEspectaculoPublicacion()
        {
            String fechaEspectaculostr = FechaEspectaculo;
            String fechaPublicacionstr = FechaPublicacion;
            if (comparaFechaHoraSistema(fechaEspectaculostr, fechaPublicacionstr))
                return true;
            
            return false;
        }

        private bool comparaFechaHoraSistema(String fechaEspectaculostr, String fechaPublicacionstr)
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaEspectaculo;
            DateTime fechaPublicacion;
            //Regulariza las fechas
            if (fechaEspectaculostr.Contains("0:00:00"))
            {
                string[] words = fechaEspectaculostr.Split(' ');
                fechaEspectaculostr = string.Concat(words[0], " ", "00:00");
            }

            if (fechaPublicacionstr.Contains("0:00:00"))
            {
                string[] words = fechaPublicacionstr.Split(' ');
                fechaPublicacionstr = string.Concat(words[0], " ", "00:00");
            }

            String format = "g";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fechaEspectaculo = DateTime.ParseExact(fechaEspectaculostr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaEspectaculostr), "Error");
                return true;
            }
            if (DateTime.Compare(fechaSistema, fechaEspectaculo) > 0)
            {
                MessageBox.Show(String.Format("Fecha y hora Espectaculo {0} menor a Fecha de Sistema {1}", fechaEspectaculostr, fechaSistema.ToString()));
                return true;
            }

            try
            {
                fechaPublicacion = DateTime.ParseExact(fechaPublicacionstr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaPublicacionstr), "Error");
                return true;
            }
            if (DateTime.Compare(fechaSistema, fechaPublicacion) < 0)
            {
                MessageBox.Show(String.Format("Fecha y hora Publicacion {0} mayor a Fecha de Sistema {1}", fechaPublicacionstr, fechaSistema.ToString()));
                return true;
            }

            return false;
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            if (this.ubicacionesCompradas.Rows.Count == 0)
            {
                MessageBox.Show("No hay ubicaciones agregadas para la compra");
            }

            else if (Client.ValidaTarjeta(this.idCliente))
            {
                //Validar si cliente tiene tarjeta (sino form nuevo para agregar tarjeta)
                if (ConfirmarCrearTarjeta())
                {
                    //FormTarjeta
                    CargarTarjeta fr = new CargarTarjeta(this,this.idCliente);
                    this.Hide();
                    fr.ShowDialog();
                    this.Show();                    
                }
                else
                {
                    MessageBox.Show("La compra no se pudo realizar");
                    this.Close();

                }              
            }
            else
            {

                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                Compra compra = new Compra();
                compra.com_fecha = fechaSistema;
                compra.com_cli = this.idCliente;
                compra.ubicaciones = ubicacionesCompradas;
                CompraFunc.CrearCompra(compra);

                MessageBox.Show("Compra realizada");
                this.Close();
            }
                
            
        }

        private bool ConfirmarCrearTarjeta()
        {
            DialogResult result = MessageBox.Show("¿Desea crear tarjeta ahora?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

    }
}
