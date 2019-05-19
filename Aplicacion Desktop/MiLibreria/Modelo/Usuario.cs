using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiLibreria.Modelo
{
    public class Usuario
    {
        public Int64 IdUsuario { get; set; }
        public String User { get; set; }
        public String Password { get; set; }
        public Boolean Estado { get; set; }
        public Int32 CantIntFallidos { get; set; }

        public Usuario(String User, String Password, Boolean Estado, Int32 CantIntFallidos)
        {
            this.User = User;
            this.Password = Password;
            this.CantIntFallidos = CantIntFallidos;
            this.Estado = Estado;
        }

        public Usuario()
        {
        }
    }
}
