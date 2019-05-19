using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Compra
    {
        public Int32 com_id;
        public DateTime com_fecha;
        public Int32 com_cli;
        public Int32 com_mp;
        public Int32 com_cant;
        public DataTable ubicaciones;
    }
}
