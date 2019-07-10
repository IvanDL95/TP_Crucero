using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Direccion
    {
        public String Calle { get; set; }
        public String Numero { get; set; }
        public String Piso { get; set; }
        public String Departamento { get; set; }
        public String CodigoPostal { get; set; }
        public String Telefono { get; set; }
        public String Mail { get; set; }
        public String Localidad { get; set; }
        public Boolean Estado { get; set; }
        public Int32 Id { get; set; }

        public Direccion(String Calle, String Numero, String Telefono, String Mail)
        {
            this.Calle = Calle;
            this.Numero = Numero;
            this.Telefono = Telefono;
            this.Mail = Mail;
        }

        public Direccion()
        {
        }
    }
}
