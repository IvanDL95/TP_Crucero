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

            if (esAdm)
            {
                MessageBox.Show("El usuario Admin no puede comprar entradas");
                this.Close();
            }
            else
            {

                DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                dtpDe.Value = fechaSistema;
                int iduser = User.ObtenerIDUsuario(user);
                this.idCliente = Client.ObtenerIDClienteUser(iduser);

                //Cantidad de publicaciones por pagina
                this.PageSize = 10;
                // fill a data table
                var t = new DataTable();
                t = RubroFunc.ObtenerRubrosList();

                // Bind the table to the list box
                lb_rubro.DisplayMember = "rub_desc";
                lb_rubro.ValueMember = "rub_id";
                lb_rubro.DataSource = t;

                ds = new DataSet();

                DataTable dtRubros = new DataTable();
                if (lb_rubro.SelectedItems.Count >= 0)
                {
                    for (int i = 0; i < lb_rubro.SelectedItems.Count; i++)
                    {
                        DataRowView drv = (DataRowView)lb_rubro.SelectedItems[i];
                        Int32 rub_id = Convert.ToInt32(drv.Row["rub_id"]);
                        DataColumn workColumn = dtRubros.Columns.Add("rub_id", typeof(Int32));
                        DataRow workRow = dtRubros.NewRow();
                        workRow["rub_id"] = rub_id;
                        dtRubros.Rows.Add(workRow);
                    }
                }

                ds = ABMPublicacion.ListarPublicacionesPublicadas(null, dtpDe.Value, dtpHasta.Value, dtRubros);

                //Set the source table.
                dtSource = ds.Tables[0];

                // Set the start and max records. 
                pageSize = this.PageSize;
                maxRec = dtSource.Rows.Count;
                PageCount = maxRec / pageSize;

                //Adjust the page number if the last page contains a partial page.
                if ((maxRec % pageSize) > 0)
                {
                    PageCount += 1;
                }

                // Initial seeings
                currentPage = 1;
                recNo = 0;

                // Display the content of the current page.
                LoadPage();
            }
        }

        private void LoadPage()
        {
            int i;
            int startRec;
            int endRec;
            DataTable dtTemp;

            //Clone the source table to create a temporary table.
            dtTemp = dtSource.Clone();

            if (currentPage == PageCount)
            {
                endRec = maxRec;
            }
            else
            {
                endRec = pageSize * currentPage;
            }
            startRec = recNo;

            if (dtSource != null)
            {
                if (dtSource.Rows.Count > 0)
                {
                    //Copy rows from the source table to fill the temporary table.
                    for (i = startRec; i < endRec; i++)
                    {
                        dtTemp.ImportRow(dtSource.Rows[i]);
                        recNo += 1;
                    }
                    dgv_publicacion.DataSource = dtTemp;

                }
                else
                {
                    currentPage = 0;
                    PageCount = 0;
                    dgv_publicacion.Refresh();
                    dgv_publicacion.DataSource = dtTemp;
                    if (ds.Tables[0].Rows.Count != 0)
                        dgv_publicacion.Columns["id"].Visible = false;
                }
            }
            else
            {
                currentPage = 0;
                PageCount = 0;
                dgv_publicacion.Refresh();
                dgv_publicacion.DataSource = dtTemp;
                if (ds.Tables[0].Rows.Count != 0)
                    dgv_publicacion.Columns["id"].Visible = false;
            }
            
            DisplayPageInfo();
        }

        private void DisplayPageInfo()
        {
            txtDisplayPageNo.Text = "Página " + currentPage.ToString() + "/ " + PageCount.ToString();
        }

        private bool CheckFillButton()
        {
            // Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            //Validar al menos 1 rubro
            if (lb_rubro.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un rubro");
            }
            else if (DateTime.Compare(dtpDe.Value, dtpHasta.Value) > 0)   
                MessageBox.Show("La fecha de no puede ser mayor a la fecha hasta");
            else
            {
                //Nuevos datos segun filtros
                DataRow workRow;
                DataTable dtRubros = new DataTable();
                DataColumn workColumn = new DataColumn();
                workColumn.DataType = System.Type.GetType("System.Int32");
                workColumn.ColumnName = "rub_id";
                dtRubros.Columns.Add(workColumn);
                if (lb_rubro.SelectedItems.Count >= 0)
                {
                    for (int i = 0; i < lb_rubro.SelectedItems.Count; i++)
                    {
                        DataRowView drv = (DataRowView)lb_rubro.SelectedItems[i];
                        Int32 rub_id = Convert.ToInt32(drv.Row["rub_id"]);
                        workRow = dtRubros.NewRow();
                        workRow["rub_id"] = rub_id;
                        dtRubros.Rows.Add(workRow);
                    }
                }
                
                ds = ABMPublicacion.ListarPublicacionesPublicadas(txt_desc.Text, dtpDe.Value, dtpHasta.Value, dtRubros);

                dtSource = ds.Tables[0];

                // Set the start and max records. 
                pageSize = this.PageSize;
                maxRec = dtSource.Rows.Count;
                PageCount = maxRec / pageSize;

                //Adjust the page number if the last page contains a partial page.
                if ((maxRec % pageSize) > 0)
                {
                    PageCount += 1;
                }

                // Initial seeings
                currentPage = 1;
                recNo = 0;

                // Display the content of the current page.
                LoadPage();
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the first page.
            if (currentPage == 1)
            {
                MessageBox.Show("Es la primera página");
                return;
            }

            currentPage = 1;
            recNo = 0;
            LoadPage();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            //If the user did not click the "Fill Grid" button, then return.
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if the user clicks the "Fill Grid" button.
            if (pageSize == 0)
            {
                MessageBox.Show("Set the Page Size, and then click the Fill Grid button!");
                return;
            }

            currentPage += 1;
            if (currentPage > PageCount)
            {
                currentPage = PageCount;
                //Check if you are already at the last page.
                if (recNo == maxRec)
                {
                    MessageBox.Show("Es la última página");
                    return;
                }
            }
            LoadPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            if (currentPage == PageCount)
            {
                recNo = pageSize * (currentPage - 2);
            }

            currentPage -= 1;
            //Check if you are already at the first page.
            if (currentPage < 1)
            {
                MessageBox.Show("Es la primera página");
                currentPage = 1;
                return;
            }
            else
            {
                recNo = pageSize * (currentPage - 1);
            }
            LoadPage();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            if (CheckFillButton() == false)
            {
                return;
            }

            //Check if you are already at the last page.
            if (recNo == maxRec)
            {
                MessageBox.Show("Es la última página");
                return;
            }
            currentPage = PageCount;
            recNo = pageSize * (currentPage - 1);
            LoadPage();
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

                //Renueva el listado
                DataRow workRow;
                DataTable dtRubros = new DataTable();
                DataColumn workColumn = new DataColumn();
                workColumn.DataType = System.Type.GetType("System.Int32");
                workColumn.ColumnName = "rub_id";
                dtRubros.Columns.Add(workColumn);
                if (lb_rubro.SelectedItems.Count >= 0)
                {
                    for (int i = 0; i < lb_rubro.SelectedItems.Count; i++)
                    {
                        DataRowView drv = (DataRowView)lb_rubro.SelectedItems[i];
                        Int32 rub_id = Convert.ToInt32(drv.Row["rub_id"]);
                        workRow = dtRubros.NewRow();
                        workRow["rub_id"] = rub_id;
                        dtRubros.Rows.Add(workRow);
                    }
                }

                ds = ABMPublicacion.ListarPublicacionesPublicadas(txt_desc.Text, dtpDe.Value, dtpHasta.Value, dtRubros);

                dtSource = ds.Tables[0];
                // Set the start and max records. 
                pageSize = this.PageSize;
                maxRec = dtSource.Rows.Count;
                PageCount = maxRec / pageSize;

                //Adjust the page number if the last page contains a partial page.
                if ((maxRec % pageSize) > 0)
                {
                    PageCount += 1;
                }

                // Initial seeings
                currentPage = 1;
                recNo = 0;

                // Display the content of the current page.
                LoadPage();

                
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
