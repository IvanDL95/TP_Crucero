using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Tramo
    {
        public Int32 id { get; set; }
        public String salida { get; set; }
        public Int32 salida_id { get; set; }
        public String destino { get; set; }
        public Int32 destino_id { get; set; }
        public decimal precio { get; set; }
    }
}
