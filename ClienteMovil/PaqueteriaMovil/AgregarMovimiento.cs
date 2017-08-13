using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PaqueteriaMovil
{
    class AgregarMovimiento
    {
        public string fecha { get; set; }
        public string observaciones { get; set; }
        public int idPedido { get; set; }
        public string status { get; set; }
        public string lug_Actual { get; set; }
        public string action { get; set; }

        public AgregarMovimiento(/*string f, string o, int p, string s, string l*/)
        {
            action = "cMovimiento";
            //this.fecha = f;
            //this.observaciones = o;
            //this.idPedido = p;
            //this.status = f;
            //this.lug_Actual = f;
        }
    }
}