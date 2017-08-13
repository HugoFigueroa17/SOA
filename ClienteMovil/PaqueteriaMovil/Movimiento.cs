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
    [Activity(Label = "Main")]
    public class Movimiento : Activity
    {
        Spinner sStatus;
        //Spinner sDia;
        //Spinner sMes;
        //string dia;
        //string mes;
        string status;
        ListView lvResultados;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Movimiento);

            sStatus = FindViewById<Spinner>(Resource.Id.sStatus);
            sStatus.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerStatus);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.opciones, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sStatus.Adapter = adapter;

            //sDia = FindViewById<Spinner>(Resource.Id.sDia);
            //sDia.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerDia);
            //var adapter_ = ArrayAdapter.CreateFromResource(this, Resource.Array.dia, Android.Resource.Layout.SimpleSpinnerItem);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //sDia.Adapter = adapter_;

            //sMes = FindViewById<Spinner>(Resource.Id.sMes);
            //sMes.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinnerMes);
            //var adapter__ = ArrayAdapter.CreateFromResource(this, Resource.Array.mes, Android.Resource.Layout.SimpleSpinnerItem);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //sMes.Adapter = adapter__;

            Button btnMovimiento = FindViewById<Button>(Resource.Id.btnAgregarMovimiento);
            EditText etLugar = FindViewById<EditText>(Resource.Id.etLugar);
            EditText etObservaciones = FindViewById<EditText>(Resource.Id.etObservaciones);
            EditText idPedido = FindViewById<EditText>(Resource.Id.idPedido);
            //EditText etAño = FindViewById<EditText>(Resource.Id.etAño);
            TextView fecha= FindViewById<TextView>(Resource.Id.tvFecha);
            lvResultados = FindViewById<ListView>(Resource.Id.listView1);

            fecha.Text += DateTime.Now.ToString("dd/MM/yyyy");

            btnMovimiento.Click += delegate
            {
                if (/*etAño.Text == "" ||*/ idPedido.Text == "" || etLugar.Text == "")
                {
                    Toast.MakeText(this, "Los datos del movimientos no estan completos", ToastLength.Long).Show();
                }

                else
                {
                    //string fecha = dia + "/" + mes + "/" + etAño.Text;
                    int id = Convert.ToInt32(idPedido.Text);

                    Servicio miServicio = new Servicio();
                    AgregarMovimiento parametros = new AgregarMovimiento(/*fecha, etObservaciones.Text, id, status, etLugar.Text*/);
                    parametros.fecha = fecha.Text;
                    parametros.observaciones = etObservaciones.Text;
                    parametros.idPedido = id;
                    parametros.status = status;
                    parametros.lug_Actual = etLugar.Text;
                    string body = JsonConvert.SerializeObject(parametros);
                    string resultados = miServicio.llamarServicio(body);

                    StartActivity(typeof(Agregado));
                }

                //Toast.MakeText(this, resultados, ToastLength.Long).Show();

                //Servicio miServicio = new Servicio();
                //ver parametros = new ver();

                //string body = JsonConvert.SerializeObject(parametros);

                //string resultados = miServicio.llamarServicio(body);

                //var movimiento = JsonConvert.DeserializeObject<List<resultsMovimientos>>(resultados);
                //List<string> lista = new List<string>();
                //lista.Clear();
                //foreach (resultsMovimientos m in movimiento)
                //{
                //    lista.Add(g.idPedido.ToString());

                //}
                //lvResultados.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemActivated1, lista);
            };
        }

        //private void spinnerDia(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    Spinner spinner = (Spinner)sender;
        //    dia = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        //}

        //private void spinnerMes(object sender, AdapterView.ItemSelectedEventArgs e)
        //{
        //    Spinner spinner = (Spinner)sender;
        //    mes = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        //}

        private void spinnerStatus(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            status = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
        }
    }
}