using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Viaje
    {
        public Int32 id { get; set; }
        public String cru_id { get; set; }
        public String rec_id { get; set; }    
        public DateTime fecha_salida { get; set; }
        public DateTime fecha_llegada { get; set; }
    }
}
