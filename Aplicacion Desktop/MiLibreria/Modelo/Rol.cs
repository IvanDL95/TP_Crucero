using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Rol
    {
        Int32 id;
        String nombre;
        Boolean estado;

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

    }
}
