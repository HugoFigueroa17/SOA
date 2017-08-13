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
    [Activity(Label = "Agregado")]
    public class Agregado : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Agregado);

            // Create your application here
            Button btnAgregar = FindViewById<Button>(Resource.Id.btnAgregarMovimiento);
            Button btnSesion = FindViewById<Button>(Resource.Id.btnSesion);

            btnAgregar.Click += delegate
            {
                StartActivity(typeof(Movimiento));
            };

            btnSesion.Click += delegate
            {
                StartActivity(typeof(Sesion));
            };
        }
    }
}