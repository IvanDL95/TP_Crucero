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
    public partial class FormBajaServicioCrucero : Form
    {
        string id;
        DateTime fechaSistema = DataBase.ObtenerFechaSistema();
        public FormBajaServicioCrucero(string id)
        {
            InitializeComponent();
            this.id = id;
            IniciarFormulario();           
        }

        public void IniciarFormulario(){
        
            //Hora de sistema default            
            dateTimePicker1.Value = this.fechaSistema;
            textBox1.MaxLength = 2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Baja
            //Comparar con hora de sistema
            if (dateTimePicker1.Value.CompareTo(this.fechaSistema) >= 0)
            {
                if (rbCancelar.Checked)
                {
                    CruceroFunc.CruceroBajaServicio(this.id, this.fechaSistema, dateTimePicker1.Value);
                    //Cancelar viajes desde fecha de sistema en adelante
                    if (CruceroFunc.ValidarViajesPendientes(this.id, this.fechaSistema))
                        CruceroFunc.CancelarViajes(this.id, "Baja de servicio de crucero " + this.id.ToString(), this.fechaSistema,dateTimePicker1.Value);
                    else
                        MessageBox.Show("No existen viajes pendientes para cancelar.");

                    MessageBox.Show("El crucero ha sido dado de baja de servicio correctamente.");
                }
                else
                {
                    //Posponer
                    //Fecha elegida - Fecha sistema <= Cantidad dias
                    if(dateTimePicker1.Value.CompareTo(this.fechaSistema) >= Convert.ToInt32(textBox1.Text.Trim())){
                        CruceroFunc.CruceroBajaServicio(this.id, this.fechaSistema, dateTimePicker1.Value);
                        if (CruceroFunc.ValidarViajesPendientes(this.id, this.fechaSistema))
                            CruceroFunc.ReprogramarViajes(this.id, this.fechaSistema, Convert.ToInt32(textBox1.Text.Trim()), dateTimePicker1.Value);
                        else
                            MessageBox.Show("No existen viajes pendientes para reprogramar.");
                        MessageBox.Show("El crucero ha sido dado de baja de servicio correctamente.");
                    }else
                        MessageBox.Show("La cantidad de dias elegida para posponer los viajes debe ser mayor o igual a la diferencia entre la fecha elegida y la fecha del sistema");
                }
                
            }else
                MessageBox.Show("La fecha elegida debe ser mayor o igual a la fecha del sistema");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
