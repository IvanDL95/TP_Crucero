using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Empresa
    {
        public String RazonSocial { get; set; }
        public String Cuit { get; set; }
        public Boolean Valido { get; set; }
        public Int32 IdDireccion { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 Id { get; set; }

        /*public Empresa(String RazonSocial, String Cuit, Int32 IdDireccion, Int32 IdUsuario, Boolean Valido)
        {
            this.RazonSocial = RazonSocial;
            this.Cuit = Cuit;
            this.Valido = Valido;
            this.IdDireccion = IdDireccion;
            this.IdUsuario = IdUsuario;
        }*/
    }
}
