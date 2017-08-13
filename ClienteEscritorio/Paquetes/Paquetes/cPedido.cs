using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paquetes
{
    class cPedido
    {
        public string action { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public string fechaI { get; set; }
        public string fechaE { get; set; }
        public string inicio { get; set; }
        public string destino { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }





        public cPedido(string p, string des, string f1, string f2, string ini, string dest, int user, int cliente)
        {
            action = "cPedido";
            producto = p;
            descripcion = des;
            fechaI = f1;
            fechaE = f2;
            inicio = ini;
            destino = dest;
            idUsuario = user;
            idCliente = cliente;

        }
    }

    class resultsInsertPedido
    {
        public string message { get; set; }
    }
}
