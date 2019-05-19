using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class TipoUbicacion
    {
        public Int32 tu_id;
        public string tu_desc;

        public override string ToString()
        {
            return tu_desc;
        }
    }


}
