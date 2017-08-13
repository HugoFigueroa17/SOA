using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class cCliente
    {
        public string action { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }

        public cCliente(string name, string tel, string dir, string em)
        {
            action = "cCliente";
            nombre = name;
            telefono = tel;
            direccion = dir;
            email = em;
        }
    }
    class resultsInsertClient
    {
        public string message { get; set; }
    }
}
