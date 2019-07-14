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
using FrbaCrucero.ABMCrucero;
using System.Text.RegularExpressions;



namespace FrbaCrucero.Compra_Reservar
{
    public partial class FormCompraReservar : Form
    {
        public int idCliente;
        public int tipoDoc;
        public DateTime FechaDesde;
        public DateTime FechaHasta;
        public int puertoDesde;
        public int puertoHasta;

        public FormCompraReservar() 
        {
            InitializeComponent();
            CargarComboPuerto();


                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                dtpDe.Value = fechaSistema;

            
        }

        private void CargarComboPuerto()
        {
            SqlDataReader reader = ViajeFunc.ObtenerPuerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    cmb_pue_desde.Items.Add(item);
                    cmb_pue_hasta.Items.Add(item);
                }
            }
            reader.Close();
        }

        public DateTime ChangeTime(DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(cmb_pue_desde.Text) || string.IsNullOrEmpty(cmb_pue_hasta.Text))
                    return true;
            return false;
        }

        private void bt_buscar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposVacios())
                MessageBox.Show("Seleccionar puerto desde y hasta");
            else
            {

                ComboboxItem item = new ComboboxItem();
                Puerto puertoDesde = new Puerto();
                Puerto puertoHasta = new Puerto();
                if (cmb_pue_desde.SelectedItem != null)
                {
                    item = (ComboboxItem)cmb_pue_desde.SelectedItem;
                    puertoDesde = (Puerto)item.Value;
                }
                if (cmb_pue_hasta.SelectedItem != null)
                {
                    item = (ComboboxItem)cmb_pue_hasta.SelectedItem;
                    puertoHasta = (Puerto)item.Value;
                }

                DateTime fechaDesde = DateTime.Now;
                fechaDesde = dtpDe.Value;
                fechaDesde = ChangeTime(fechaDesde, 0, 0, 0, 0);

                DateTime fechaHasta = DateTime.Now;
                fechaHasta = dtpHasta.Value;
                fechaHasta = ChangeTime(fechaHasta, 23, 59, 59, 0);

                dgv_viaje.DataSource = ViajeFunc.ListarViaje(puertoDesde.id, puertoHasta.id, fechaDesde, fechaHasta).Tables[0];
            }
        }     

        private void btCargarCliente_Click(object sender, EventArgs e)
        {
            if (dgv_viaje.Rows.Count == 0)
                MessageBox.Show("No se encuentran viajes disponibles");
            else
            {
                this.FechaDesde = dtpDe.Value;
                this.FechaHasta = dtpHasta.Value;               
                
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                Compra compra = new Compra();
                compra.com_fecha = fechaSistema;
                compra.com_cli = this.idCliente;

                Int32 idViaje = Convert.ToInt32(dgv_viaje.CurrentRow.Cells["via_id"].Value);
                Int32 idRecorrido = Convert.ToInt32(dgv_viaje.CurrentRow.Cells["via_rec_id"].Value);

                ComboboxItem item = new ComboboxItem();
                Puerto puertoDesde = new Puerto();
                Puerto puertoHasta = new Puerto();
                if (cmb_pue_desde.SelectedItem != null)
                {
                    item = (ComboboxItem)cmb_pue_desde.SelectedItem;
                    puertoDesde = (Puerto)item.Value;
                }
                if (cmb_pue_hasta.SelectedItem != null)
                {
                    item = (ComboboxItem)cmb_pue_hasta.SelectedItem;
                    puertoHasta = (Puerto)item.Value;
                }

                this.puertoDesde = puertoDesde.id;
                this.puertoHasta = puertoHasta.id;

                CargarCliente frCargarCliente = new CargarCliente(this);
                this.Hide();
                frCargarCliente.ShowDialog();
                this.Show();

                if (this.idCliente != 0)
                {

                    //Seleccion Cabinas
                    CabinaDisponible frCabinaDisponible = new CabinaDisponible(compra, idViaje, this.idCliente,this.tipoDoc, idRecorrido, puertoDesde.id, puertoHasta.id,rb_compra.Checked);
                    this.Hide();
                    frCabinaDisponible.ShowDialog();
                    this.Show();
                }

            }
            
        }       

        /*private bool ValidaFechaEspectaculoPublicacion()
        {
            String fechaEspectaculostr = Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaEspectaculo"].Value);
            String fechaPublicacionstr = Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaPublicacion"].Value);
            if (comparaFechaHoraSistema(fechaEspectaculostr, fechaPublicacionstr))
                return true;
            
            return false;
        }
      */

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            if (DateTime.Compare(fechaSistema, dtpDe.Value) > 0)
            {
                MessageBox.Show(String.Format("El mínimo valor que puede ingresarse en Fecha de: es la Fecha Sistema {0}", fechaSistema.ToString()));
                dtpDe.Value = fechaSistema;
            }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            if (DateTime.Compare(fechaSistema, dtpHasta.Value) > 0)
            {
                MessageBox.Show(String.Format("El mínimo valor que puede ingresarse en Fecha hasta: es la Fecha Sistema {0}", fechaSistema.ToString()));
                dtpHasta.Value = fechaSistema;
            }
        }

        


    }
}
