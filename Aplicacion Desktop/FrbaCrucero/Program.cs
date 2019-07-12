using FrbaCrucero.ABMCrucero;
using FrbaCrucero.Compra_Reservar;
using FrbaCrucero.Generar_viaje;
using FrbaCrucero.Pago_Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new PantallaIncial(null, null));
            Application.Run(new PagoReserva());

        }
        
    }
}
