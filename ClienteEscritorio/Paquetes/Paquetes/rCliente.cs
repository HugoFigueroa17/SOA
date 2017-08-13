using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class rCliente
    {
        public string action { get; set; }
        public rCliente()
        {
            action = "rCliente";
        }

    }
    class allClientes
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string email { get; set; }

    }
    class allClientesId
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string email { get; set; }

    }
}
