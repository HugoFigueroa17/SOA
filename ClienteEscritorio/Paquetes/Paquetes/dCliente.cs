using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class dCliente
    {
        public string action { get; set; }
        public string nombre { get; set; }

        public dCliente(string n)
        {
            action = "dCliente";
            nombre = n;
        }

        
    }

    class dClienteAll
    {
        public string action { get; set; }
        public dClienteAll()
        {
            action = "dAllClientes";
        }
    }
    class dClientM
    {
        public string message { get; set; }
    }
}
