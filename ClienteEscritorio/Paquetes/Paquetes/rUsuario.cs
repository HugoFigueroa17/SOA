using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class rUsuario
    {
        public string action { get; set; }
        public rUsuario()
        {
            action = "rAdministrador";
        }
    }

    class allUsers
    {
        public string user  { get; set;}
        public string Nombre { get; set;}
       
    }

    class allUserId
    {
        public int idAdmin { get; set; }
        public string user { get; set; }
        public string Nombre { get; set; }

    }
}
