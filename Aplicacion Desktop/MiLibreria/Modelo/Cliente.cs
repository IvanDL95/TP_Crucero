using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Cliente
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public Int32 NroDoc { get; set; }
        public DateTime FechaNac { get; set; }
        public Int32 IdDireccion { get; set; }
        public Int32 IdUsuario { get; set; }
        public Boolean Estado { get; set; }
    }
}
