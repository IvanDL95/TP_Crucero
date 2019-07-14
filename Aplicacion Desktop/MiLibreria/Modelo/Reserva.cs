using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Reserva
    {
        public DateTime res_fecha;
        public Int32 res_cli;
        public Int32 res_tipoDoc;
        public DataTable cabinas;
    }
}
