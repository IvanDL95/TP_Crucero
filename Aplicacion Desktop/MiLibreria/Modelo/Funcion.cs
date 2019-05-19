using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Funcion
    {
        Int32 id;
        String nombre;
        Boolean visible;

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

        public Boolean Visible
        {
            get { return visible; }
            set { visible = value; }
        }

    }
}
