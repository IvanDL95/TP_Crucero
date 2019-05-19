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
        public String TipoDoc { get; set; }
        public String NroDoc { get; set; }
        public String Cuil { get; set; }
        public String Mail { get; set; }
        public String Tarj { get; set; }
        public DateTime FechaNac { get; set; }
        public String Sexo { get; set; }
        public Boolean Valido { get; set; }
        public Int32 IdDireccion { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 Id { get; set; }
        public Boolean Estado { get; set; }
    }
}
