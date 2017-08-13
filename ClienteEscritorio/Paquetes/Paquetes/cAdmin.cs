using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class cAdmin
    {
        public string action { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string user { get; set; }

        public cAdmin(string name, string pw, string usuario)
        {
            action = "cAdministrador";
            nombre = name;
            password = pw;
            user = usuario;
        }
    }
    class resultsInsertAdmin
    {
        public string message { get; set; }
    }
}
