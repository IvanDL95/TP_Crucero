using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Crucero
    {
        /*
        public Int32  { get; set; }
        public String  { get; set; }        
        public DateTime  { get; set; }
        public Boolean  { get; set; }
         */
        public String id { get; set; }
        public String mod { get; set; }
        public Int32 fab_id { get; set; }
        public Int32 tser_id { get; set; }
        public DateTime fecha_alta { get; set; }
        public Boolean baja_fuera_servicio { get; set; }
        public Boolean baja_vida_util { get; set; }
        public DateTime fecha_fuera_servicio { get; set; }
        public DateTime fecha_reinicio_servicio { get; set; }
        public DateTime fecha_baja_definitiva { get; set; }            
    }
}
