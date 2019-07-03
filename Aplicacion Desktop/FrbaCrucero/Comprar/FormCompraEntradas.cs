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



namespace FrbaCrucero.Compra_Entrada
{
    public partial class FormCompraEntradas : Form
    {
        DataSet ds;
        DataTable dtSource;
        int PageCount;
        int maxRec;
        int pageSize;
        int currentPage;
        int recNo;
        int PageSize;
        int idCliente;

        public FormCompraEntradas(bool esAdm, String user) 
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
                    puerto.desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.desc;
                    item.Value = puerto;
                    cmb_pue_desde.Items.Add(item);
                    cmb_pue_hasta.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void bt_buscar_Click(object sender, EventArgs e)
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


            dgv_publicacion.DataSource = ViajeFunc.ListarViaje(puertoDesde.id, puertoHasta.id,dtpDe.Value,dtpHasta.Value).Tables[0];
        }     

        private void btUbicDisponibles_Click(object sender, EventArgs e)
        {          
            if(ValidaFechaEspectaculoPublicacion()){
            }
            else{
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                Compra compra = new Compra();
                compra.com_fecha = fechaSistema;
                compra.com_cli = this.idCliente;

                Int32 idPublicacion = Convert.ToInt32(dgv_publicacion.CurrentRow.Cells["id"].Value);
                UbicacionDisponible fr = new UbicacionDisponible(compra, idPublicacion, this.idCliente,Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaEspectaculo"].Value),
                    Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaPublicacion"].Value));
                this.Hide();
                fr.ShowDialog();


                //ds = ABMPublicacion.ListarPublicacionesPublicadas(txt_desc.Text, dtpDe.Value, dtpHasta.Value, dtRubros);
                
                this.Show();       
            }
            
        }       

        private bool ValidaFechaEspectaculoPublicacion()
        {
            String fechaEspectaculostr = Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaEspectaculo"].Value);
            String fechaPublicacionstr = Convert.ToString(dgv_publicacion.CurrentRow.Cells["FechaPublicacion"].Value);
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

            else if (fechaEspectaculostr.Contains(" 0:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "00:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 1:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "01:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 2:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "02:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 3:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "03:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 4:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "04:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 5:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "05:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 6:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "06:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 7:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "07:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 8:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "08:", hora[1]);
            }
            else if (fechaEspectaculostr.Contains(" 9:"))
            {
                string[] partes = fechaEspectaculostr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaEspectaculostr = string.Concat(partes[0], " ", "09:", hora[1]);
            } 

            if (fechaPublicacionstr.Contains("0:00:00"))
            {
                string[] words = fechaPublicacionstr.Split(' ');
                fechaPublicacionstr = string.Concat(words[0], " ", "00:00");
            }
            else if (fechaPublicacionstr.Contains(" 0:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "00:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 1:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "01:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 2:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "02:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 3:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "03:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 4:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "04:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 5:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "05:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 6:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "06:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 7:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "07:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 8:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "08:", hora[1]);
            }
            else if (fechaPublicacionstr.Contains(" 9:"))
            {
                string[] partes = fechaPublicacionstr.Split(' ');
                string[] hora = partes[1].Split(':');
                fechaPublicacionstr = string.Concat(partes[0], " ", "09:", hora[1]);
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
