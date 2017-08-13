using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class cLogin
    {
        public string action { get; set; }
        public string nombre { get; set; }

        public cLogin(string name)
        {
            action = "rPassword";
            this.nombre = name;
        }  
    }
    class validateLogin
    {
        public string password { get; set; }
    }
}
