using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class verPedidos
    {
        public string action { get; set; }

        public verPedidos()
        {
            action = "rPedido";
        }
    }
    class allPedidos
    {
        public string codigo { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public string fechaRecepcion { get; set; }
        public string fechaentrega { get; set; }
        public string lugarInicio { get; set; }
        public string lugarDestino { get; set; }
        public string Cliente { get; set; }
        public string Repartidor { get; set; }
    }
}
