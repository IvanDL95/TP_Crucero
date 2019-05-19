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

namespace FrbaCrucero.Generar_Rendicion_Comisiones
{
    public partial class FormGenerarRendicion : Form
    {
        DataTable comprasRendidas;
        public FormGenerarRendicion(ContenedorPrincipal fr)
        {
            InitializeComponent();
            //Crea tabla comprasRendidas
            this.comprasRendidas = new DataTable("comprasRendidas");
            DataColumn workCol = this.comprasRendidas.Columns.Add("com_id", typeof(Int32));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            this.comprasRendidas.Columns.Add("orden", typeof(Int32));

            DataSet ds;
            ds = CompraFunc.ListarComprasRendir();

            dgv_listado.DataSource = ds.Tables[0];

            if (dgv_listado.Rows.Count == 0)
            {
                MessageBox.Show("No hay compras para rendir");
                this.Close();

            }

            if (ds.Tables[0].Rows.Count != 0)
            dgv_listado.Columns["id"].Visible = false;
            

        }

        private void btRendir_Click(object sender, EventArgs e)
        {
            if (this.comprasRendidas.Rows.Count == 0)
            {
                MessageBox.Show("No hay compras agregadas para la rendición");
            }         
            else
            {
                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                CompraFunc.RendirCompra(comprasRendidas, fechaSistema);

                MessageBox.Show("Rendición realizada");
                this.Close();
            }
        }

        private bool comparaFecha(String fecha1str, String fecha2str)
        {
            DateTime fecha1;
            DateTime fecha2;
            //Regulariza las fechas
            if (fecha1str.Contains("0:00:00"))
            {
                string[] words = fecha1str.Split(' ');
                fecha1str = string.Concat(words[0], " ", "00:00");
            }

            if (fecha2str.Contains("0:00:00"))
            {
                string[] words = fecha2str.Split(' ');
                fecha2str = string.Concat(words[0], " ", "00:00");
            }

            String format = "g";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fecha1 = DateTime.ParseExact(fecha1str, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fecha1str), "Error");
                return true;
            }

            try
            {
                fecha2 = DateTime.ParseExact(fecha2str, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fecha2str), "Error");
                return true;
            }
            if (DateTime.Compare(fecha1, fecha2) > 0)
            {
                return true;
            }

            return false;
        }

        public bool ValidaTabla(int indice)
        {
            if (this.comprasRendidas.Rows.Count == 0)
                return true;
            else
            {
                for (int i = 0; i < this.comprasRendidas.Rows.Count; i++)
                {
                    if (indice == Convert.ToInt32(this.comprasRendidas.Rows[i]["Orden"]))
                        return false;
                }
            }
            return true;
        }
            

        public bool ValidaSeleccionarDesdePrimera()
        {
            String fechaCompraActualstr = Convert.ToString(dgv_listado.Rows[(dgv_listado.CurrentRow.Index)].Cells["FechaCompra"].Value);

            for (int i = 0; i < this.dgv_listado.Rows.Count - 1; i++)
            {
                if (i != dgv_listado.CurrentRow.Index && ValidaTabla(i))
                {
                    String fechaCompraComparastr = Convert.ToString(dgv_listado.Rows[i].Cells["FechaCompra"].Value);
                    if (comparaFecha(fechaCompraActualstr, fechaCompraComparastr))
                    {
                        MessageBox.Show("Las compras se rinden desde la más antigua");
                        return true;
                    }                                    
                }
            }
            return false;
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            if (dgv_listado.Rows.Count == 0)
                MessageBox.Show("No hay ubicación seleccionada");
            else if (ValidaSeleccionarDesdePrimera())
            {
            }
            else
            {
                dgv_listado.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;

                DataRow row = this.comprasRendidas.NewRow();
                DataGridViewRow dataRow = dgv_listado.Rows[(dgv_listado.CurrentRow.Index)];
                row["com_id"] = dataRow.Cells["id"].Value.ToString();
                row["orden"] = dgv_listado.CurrentRow.Index;
                try
                {
                    this.comprasRendidas.Rows.Add(row);
                }
                catch (ConstraintException)
                {
                    MessageBox.Show("La compra ya fue agregada para la rendición");
                }
            }
        }
    }
}
