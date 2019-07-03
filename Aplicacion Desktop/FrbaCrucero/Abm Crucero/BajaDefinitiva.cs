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
    public partial class FormBajaDefinitivaCrucero : Form
    {
        string id;
        public string id_reemplazo;
        DateTime fechaSistema = DataBase.ObtenerFechaSistema();
        public FormBajaDefinitivaCrucero(string id)
        {
            InitializeComponent();
            this.id = id;
            IniciarFormulario();           
        }

        public void IniciarFormulario(){

            txt_id.MaxLength = 30;             
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        //Baja
            if (rbCancelar.Checked)
            {
                CruceroFunc.CruceroBajaDefinitiva(this.id, this.fechaSistema);
                //Cancelar viajes desde fecha de sistema en adelante
                if (CruceroFunc.ValidarViajesPendientes(this.id, this.fechaSistema))
                    CruceroFunc.CancelarViajesBajaDefinitiva(this.id, this.fechaSistema, "Baja definitiva de crucero " + this.id.ToString());
                else
                    MessageBox.Show("No existen viajes pendientes para cancelar.");
                MessageBox.Show("El crucero ha sido dado de baja de definitiva correctamente.");              
            }
            else if (rbBuscarReemplazo.Checked)
            {
                if (CruceroFunc.ValidarViajesPendientes(this.id, this.fechaSistema))
                {
                    //Buscar reemplazo
                    BajaDefinitivaBuscarCrucero form = new BajaDefinitivaBuscarCrucero(this.id);
                    this.Hide();
                    form.ShowDialog();
                    this.Show();
                }
                else
                {
                    CruceroFunc.CruceroBajaDefinitiva(this.id, this.fechaSistema);                    
                    MessageBox.Show("No existen viajes pendientes para reemplazar por otro crucero.");
                    MessageBox.Show("El crucero ha sido dado de baja de definitiva correctamente.");
                }
            }
            else
            {
                //Alta reemplazo automatica como copia
                //Verificar ID repetido
                if (!CruceroFunc.EsValidoIdCrucero(this.txt_id.Text.Trim()))
                {
                    MessageBox.Show("La identificación ya existe");
                }
                else
                {
                    CruceroFunc.CruceroBajaDefinitiva(this.id, this.fechaSistema);
                    if (CruceroFunc.ValidarViajesPendientes(this.id, this.fechaSistema))
                    {
                        Crucero crucero = new Crucero();
                        SqlDataReader reader = CruceroFunc.ObtenerCrucero(this.id);
                        crucero = CruceroFunc.ObtenerCruceroDesdeUnReader(reader);
                        crucero.id = txt_id.Text.Trim();
                        //Se crea reemplazo
                        CruceroFunc.CrearCrucero(crucero);
                        Cabina_crucerofunc.CrearCabinaReemplazo(this.id, txt_id.Text.Trim());
                        CruceroFunc.ActualizarViajeReemplazo(this.id, txt_id.Text.Trim(), this.fechaSistema);
                        MessageBox.Show("El crucero ha sido dado de baja de definitiva correctamente.");
                    }
                    else
                        MessageBox.Show("No existen viajes pendientes para reemplazar por otro crucero.");                                      
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
