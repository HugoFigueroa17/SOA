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
using Newtonsoft.Json;

namespace PaqueteriaMovil
{
    [Activity(Label = "Sesion")]
    public class Sesion : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Sesion);

            // Create your application here
            Button btnSesion = FindViewById<Button>(Resource.Id.btnSesion);
            EditText etPass = FindViewById<EditText>(Resource.Id.etPass);
            EditText etUsu = FindViewById<EditText>(Resource.Id.etUsu);

            btnSesion.Click += delegate
            {
                if (etPass.Text == "" || etUsu.Text == "")
                {
                    Toast.MakeText(this, "Usuario o contraseña incorrectos", ToastLength.Long).Show();
                    etPass.Text = "";
                    etUsu.Text = "";
                }

                else
                {
                    Servicio miServicio = new Servicio();
                    paramsSesion parametros = new paramsSesion();
                    parametros.nombre = etUsu.Text;
                    string body = JsonConvert.SerializeObject(parametros);
                    string resultados = miServicio.llamarServicio(body);

                    var r = JsonConvert.DeserializeObject<List<resultsSesion>>(resultados);

                    string p = "";
                    foreach (resultsSesion c in r)
                    {
                        p = c.password.ToString();
                    }

                    if (p == etPass.Text)
                    {
                        StartActivity(typeof(Movimiento));
                    }
                    else
                    {
                        etPass.Text = "";
                        etUsu.Text = "";
                        Toast.MakeText(this, "Usuario o contraseña incorrectos", ToastLength.Long).Show();
                    }
                }
            };
        }
    }
}