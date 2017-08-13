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
using MetroFramework;
using System.Web.Script.Serialization;

namespace Paquetes
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Aqua;
            string p = txtPassword.Text;
            string u = txtUser.Text;

            if(p == "" || u == "")
            {
                MetroMessageBox.Show(this, "\n\n\nUsuario/Contraseña incorrectos \n¡Intente nuevamente!", 
                    "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Servicio pw = new Servicio();
                cLogin login = new cLogin(u);
                JavaScriptSerializer log = new JavaScriptSerializer();
                string datos = log.Serialize(login);

                string result = pw.llamarServicio(datos);

                var xgen = log.Deserialize<List<validateLogin>>(result);

                string password = "";
               foreach(validateLogin c in xgen)
                {
                    password = c.password.ToString();
                }
                if(txtPassword.Text == password)
                {
                    Inicio inicio = new Inicio();
                    this.Hide();
                    inicio.Show();
                }
                else
                {
                    MetroMessageBox.Show(this, "\n\n\nUsuario/Contraseña incorrectos \n¡Intente nuevamente!",
                    "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            
            
            btnLogin.BackColor = Color.Green;
            btnLogin.ForeColor = Color.Black;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 192, 0);
            btnLogin.BackColor = color;
            btnLogin.ForeColor = Color.White;
        }

        private void btnRegistrar_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrar.BackColor = Color.Blue;
            btnRegistrar.ForeColor = Color.Black;
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 0, 192);
            btnRegistrar.BackColor = color;
            btnRegistrar.ForeColor = Color.White;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrarse r = new Registrarse();
            r.Show();
        }
    }
}
