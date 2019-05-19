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

namespace FrbaCrucero.Historial_Cliente
{
    public partial class FormHistorialCliente : Form
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

        public FormHistorialCliente(bool esAdm, String user) 
        {
            InitializeComponent();

            if (esAdm)
            {
                MessageBox.Show("El usuario Admin no puede ejecutar el Historial");
                this.Close();
            }

            int iduser = User.ObtenerIDUsuario(user);
            this.idCliente = Client.ObtenerIDClienteUser(iduser);

            //Cantidad de publicaciones por pagina
            this.PageSize = 10;

            ds = new DataSet();

            ds = CompraFunc.ListarComprasRealizadas(this.idCliente);

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
                    dgv_compras.DataSource = dtTemp;

                }
                else
                {
                    currentPage = 0;
                    PageCount = 0;
                    dgv_compras.Refresh();
                    dgv_compras.DataSource = dtTemp;
                }
            }
            else
            {
                currentPage = 0;
                PageCount = 0;
                dgv_compras.Refresh();
                dgv_compras.DataSource = dtTemp;
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
    }
}
