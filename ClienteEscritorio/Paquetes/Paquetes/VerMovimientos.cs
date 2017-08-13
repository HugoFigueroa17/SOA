using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class VerMovimientos
    {
        public string action { get; set; }
        public VerMovimientos()
        {
            action = "tMovimientos";
        }
    }
    class allMov
    {
        public string Codigo { get; set; }
        public string Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Pedido { get; set; }
        public string Estado { get; set; }
        public string Lugar { get; set; }
    }
}
