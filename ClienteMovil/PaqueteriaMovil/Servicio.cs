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
using System.Net;
using System.IO;

namespace PaqueteriaMovil
{
    class Servicio
    {
        private string url { get; set; } //Ruta del servicio a consumir
        private HttpWebRequest httpRequest { get; set; } //Para las peticiones
        private HttpWebResponse httpResponse { get; set; } //Para las respuestas
        private StreamWriter streamWriter { get; set; } //Escribir archivos
        private StreamReader streamReader { get; set; } //Leer archivos

        private string body { get; set; }
        private string results { get; set; }

        public Servicio()
        {
            url = "http://192.168.43.81/P&T/";
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json"; //Tipo de contenido en formato JSON
            httpRequest.Method = "POST";//Envio de peticiones por metodo PPOST

            streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        }

        public string llamarServicio(string parametros)
        {
            body = parametros;

            //Escribimos la peticion al servicio
            streamWriter.InitializeLifetimeService();
            streamWriter.Write(body);
            streamWriter.Flush();

            //Obtener la respuesta del web services
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (streamReader = new StreamReader(httpResponse.GetResponseStream()))//Asignar lo que devolvio el servicio
            {
                results = streamReader.ReadToEnd();
            }

            return results;
        }
    }
}