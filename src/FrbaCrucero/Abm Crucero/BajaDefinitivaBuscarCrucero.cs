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
using System.Configuration;
using FrbaCrucero.ABMCrucero;

namespace FrbaCrucero.ABMCrucero
{
    public partial class BajaDefinitivaBuscarCrucero : Form
    {
        string id;
        public string id_reemplazo;
        DateTime fechaSistema = DataBase.ObtenerFechaSistema();
        public BajaDefinitivaBuscarCrucero (string id)
        {
            InitializeComponent();
            this.id = id;
            IniciarFormulario();           
        }

        public void IniciarFormulario(){

            dgv_listado.DataSource = CruceroFunc.ListarCrucerosReemplazo(this.id,this.fechaSistema).Tables[0];    
            //Si está vacia, mensaje que no hay cruceros disponibles y cerrar
            if (dgv_listado.Rows.Count == 0)
            {
                MessageBox.Show("No existen cruceros disponibles para reemplazar.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reemplazar por crucero elegido
            String id = Convert.ToString(dgv_listado.CurrentRow.Cells[0].Value);
            //Se crea reemplazo
            CruceroFunc.ActualizarViajeReemplazo(this.id, id, this.fechaSistema);
            CruceroFunc.CruceroBajaDefinitiva(this.id, this.fechaSistema);
            MessageBox.Show("El crucero ha sido dado de baja de definitiva correctamente.");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
