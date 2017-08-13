using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class rClienteN
    {
        public string action { get; set; }
        public string nombre { get; set; }

        public rClienteN(string n)
        {
            action = "rClienteXname";
            nombre = n;
        }
    }

    class allClienteId
    {
        //public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string email { get; set; }

    }
}
