using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Paquetes
{
    public partial class Cargando : MetroForm
    {
        public Cargando()
        {
            InitializeComponent();
            tUno.Interval = 30;//cada 200 milisegundos se ejecuta 
            tUno.Tick += new EventHandler(tUno_Tick);//tick cada 200 milisegundos
        }

        public void tUno_Tick(object sender, EventArgs e)//recibe ojbeto tipo sender
        {
            pbInicio.Increment(1);

            //tssUno.Text = "Cargando  " + pbInicio.Value.ToString() + " % de progreso";//valor del progres var 1,2,3,4......
            if (pbInicio.Value == pbInicio.Maximum)//si el valor actual es igual al valor maximo
            {
                tUno.Stop();//lo detengo
                //tssUno.Text = "Completado";
                this.Hide();
                Login l = new Login();
                l.Show();
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (pbInicio.Value != 0)
                pbInicio.Value = 0;

            tUno.Start();//inicializar el taimer 
        }
    }
}
