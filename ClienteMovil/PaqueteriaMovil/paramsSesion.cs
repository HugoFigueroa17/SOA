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
    class paramsSesion
    {
        public string nombre { get; set; }
        public string action { get; set; }

        public paramsSesion()
        {
            action = "rPassword";
        }
    }

    class resultsSesion
    {
        public string password { get; set; }
    };
}