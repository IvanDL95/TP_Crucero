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

        public Direccion(String Calle, String Numero, String Piso, String Departamento, String CodigoPostal, String Telefono, String Mail, String Localidad)
        {
            this.Calle = Calle;
            this.Numero = Numero;
            this.Piso = Piso;
            this.Departamento = Departamento;
            this.CodigoPostal = CodigoPostal;
            this.Telefono = Telefono;
            this.Mail = Mail;
            this.Localidad = Localidad;
        }

        public Direccion()
        {
        }
    }
}
