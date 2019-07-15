using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class TipoCabina
    {
        public Int32 tcab_id;
        public decimal tcab_porc_recargo;
        public string tcab_tipo;

        public override string ToString()
        {
            return tcab_tipo;
        }
    }


}
