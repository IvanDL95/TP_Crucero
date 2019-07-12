using MiLibreria;
using MiLibreria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Generar_viaje
{
    public partial class FormGenerarViaje : Form
    {
        public FormGenerarViaje()
        {
            InitializeComponent();
            dgv_listado2.DataSource = ViajeFunc.ListarRecorrido("", "").Tables[0];

        }


        private void btGenerar_Viaje_Click(object sender, EventArgs e)
        {
           Regex datePattern = new Regex("^[0-9]{2}([/][0-9]{2}([/][0-9]{4}))?$");
            Regex hourPattern = new Regex("^[0-9]{2}([:][0-9]{2}([:][0-9]{2}))?$");
            if (!datePattern.IsMatch(this.txt_fsal.Text))
            {
                MessageBox.Show("Formato de Fecha Salida incorrecto: \"DD/MM/AAAA\"");
            }else
            if (!datePattern.IsMatch(this.txt_flleg.Text))
            {
                MessageBox.Show("Formato de Fecha Llegada incorrecto: \"DD/MM/AAAA\"");
            }else            
            if (!hourPattern.IsMatch(txt_hsal.Text))
            {
                MessageBox.Show("Formato de Hora Salida incorrecto: \"HH:MM:SS\"");
            }else
            if (!hourPattern.IsMatch(txt_hlleg.Text))
            {
                MessageBox.Show("Formato de Hora Salida incorrecto: \"HH:MM:SS\"");
            }else if (validarFechaSalida())
                if (validarFechaLlegada())
                {
                    DateTime fechaHoraSalida = DateTime.Now;
                    DateTime fechaHoraLlegada = DateTime.Now;
                    String fechaHoraLlegadastr = String.Concat(txt_flleg.Text, " ", txt_hlleg.Text);
                    String fechaHoraSalidastr = String.Concat(txt_fsal.Text, " ", txt_hsal.Text);
                    String format = "G";
                    CultureInfo provider = new CultureInfo("fr-FR");                    
                    fechaHoraSalida = DateTime.ParseExact(fechaHoraSalidastr, format, provider);
                    fechaHoraLlegada = DateTime.ParseExact(fechaHoraLlegadastr, format, provider);

                    Viaje viaje = new Viaje();
                    viaje.cru_id=Convert.ToString(dgv_listado.CurrentRow.Cells[0].Value);
                    viaje.rec_id = Convert.ToInt32(dgv_listado2.CurrentRow.Cells[0].Value);
                    viaje.fecha_salida = fechaHoraSalida;
                    viaje.fecha_llegada = fechaHoraLlegada;
                    ViajeFunc.CrearViaje(viaje);
                    int via_id = ViajeFunc.ObtenerIDViaje(viaje);
                    ViajeFunc.CrearCabinasViaje(via_id, viaje.cru_id);
                    MessageBox.Show("Viaje creado");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*private void ValidacionesIniciales()
        {
            txt_fsal.MaxLength = 70;
            txt_hsal.MaxLength = 2;
            txt_piso.MaxLength = 2;
            txt_cp.MaxLength = 4;
            txt_hlleg.MaxLength = 50;
            txt_numero.MaxLength = 5;
            txt_tel.MaxLength = 18;
            txt_flleg.MaxLength = 50;
            txt_desc.MaxLength = 400;
        }*/

        /*private void dgv_fecha_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_fecha.Rows[e.RowIndex].ErrorText = string.Empty;
        }*/


        private void dgv_ubicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

      

        private bool validarFechaSalida()
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaHora = DateTime.Now;
            String fechaHoraSalidastr = String.Concat(txt_fsal.Text, " ", txt_hsal.Text);
            String format = "G";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fechaHora = DateTime.ParseExact(fechaHoraSalidastr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora salida invalida: {0}", fechaHoraSalidastr), "Error");
                return false;
            }
            if (DateTime.Compare(fechaSistema, fechaHora) > 0)
            {
                MessageBox.Show(String.Format("Fecha y hora salida {0} menor a Fecha de Sistema {1}", fechaHoraSalidastr, fechaSistema.ToString()));
                return false;
            }
            return true;
        }

        private bool validarFechaLlegada()
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaHoraSalida = DateTime.Now;
            DateTime fechaHoraLlegada = DateTime.Now;
            String fechaHoraLlegadastr = String.Concat(txt_flleg.Text, " ", txt_hlleg.Text);
            String format = "G";
            CultureInfo provider = new CultureInfo("fr-FR");
            String fechaHoraSalidastr = String.Concat(txt_fsal.Text, " ", txt_hsal.Text);
            try
            {
                fechaHoraSalida = DateTime.ParseExact(fechaHoraSalidastr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora salida invalida: {0}", fechaHoraSalidastr), "Error");
                return false;
            }
            try
            {
                fechaHoraLlegada = DateTime.ParseExact(fechaHoraLlegadastr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora llegada invalida: {0}", fechaHoraLlegadastr), "Error");
                return false;
            }
            if (DateTime.Compare(fechaHoraSalida,fechaHoraLlegada) >= 0)
            {
                MessageBox.Show(String.Format("Fecha y hora salida {0} mayor o igual a Fecha y hora llegada {1}", fechaHoraSalidastr, fechaHoraLlegadastr));
                return false;
            }
            return true;
        }


       /*private bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(cmb_rubro.Text) || string.IsNullOrEmpty(cmb_grado.Text) || txt_desc.Text == "" || txt_cp.Text == "" || txt_hsal.Text == "" || txt_hlleg.Text == "" || txt_flleg.Text == "" || txt_numero.Text == "" || txt_piso.Text == "" || txt_tel.Text == "")
                return true;
            return false;
        }*/


        private void btBuscar_Click(object sender, EventArgs e)
        {
            Regex datePattern = new Regex("^[0-9]{2}([/][0-9]{2}([/][0-9]{4}))?$");
            Regex hourPattern = new Regex("^[0-9]{2}([:][0-9]{2}([:][0-9]{2}))?$");
            if (!datePattern.IsMatch(this.txt_fsal.Text))
            {
                MessageBox.Show("Formato de Fecha Salida incorrecto: \"DD/MM/AAAA\"");
            }else
            if (!datePattern.IsMatch(this.txt_flleg.Text))
            {
                MessageBox.Show("Formato de Fecha Llegada incorrecto: \"DD/MM/AAAA\"");
            }else            
            if (!hourPattern.IsMatch(txt_hsal.Text))
            {
                MessageBox.Show("Formato de Hora Salida incorrecto: \"HH:MM:SS\"");
            }else
            if (!hourPattern.IsMatch(txt_hlleg.Text))
            {
                MessageBox.Show("Formato de Hora Salida incorrecto: \"HH:MM:SS\"");
            }else if (validarFechaSalida())
                if (validarFechaLlegada())
                {
                    //Lista cruceros validos
                    DateTime fechaHoraSalida = DateTime.Now;
                    DateTime fechaHoraLlegada = DateTime.Now;
                    String fechaHoraLlegadastr = String.Concat(txt_flleg.Text, " ", txt_hlleg.Text);
                    String fechaHoraSalidastr = String.Concat(txt_fsal.Text, " ", txt_hsal.Text);
                    String format = "G";
                    CultureInfo provider = new CultureInfo("fr-FR");                    
                    fechaHoraSalida = DateTime.ParseExact(fechaHoraSalidastr, format, provider);
                    fechaHoraLlegada = DateTime.ParseExact(fechaHoraLlegadastr, format, provider);

                    dgv_listado.DataSource = CruceroFunc.ListarCrucerosViaje(fechaHoraSalida,fechaHoraLlegada).Tables[0];

                }
        }

        private void btBuscarRecorrido_Click(object sender, EventArgs e)
        {
            dgv_listado2.DataSource = ViajeFunc.ListarRecorrido(txt_puerto_desde.Text.Trim(), txt_puerto_hasta.Text.Trim()).Tables[0];
        }
    }

}
