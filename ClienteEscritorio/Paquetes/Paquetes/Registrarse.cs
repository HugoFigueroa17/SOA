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
    public partial class Registrarse : MetroForm
    {
        public Registrarse()
        {
            InitializeComponent();
            txtPw.PasswordChar = '*';
            txtPw2.PasswordChar = '*';
        }

        private void Registrarse_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DestroyHandle();
            Login l = new Login();
            l.Show();
        }

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrar.BackColor = Color.Green;
            btnRegistrar.ForeColor = Color.Black;
        }

        private void btnRegistrar_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 192, 0);
            btnRegistrar.BackColor = color;
            btnRegistrar.ForeColor = Color.White;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string usuario = txtUsuario.Text;
            string pw = txtPw.Text;
            string pw1 = txtPw2.Text;

            if(nombre != "" & usuario != "" & pw != "" & pw1 != "")
            {
                if(pw == pw1)
                {
                    Servicio insertAdmin = new Servicio();
                    cAdmin cA = new cAdmin(nombre, pw, usuario);
                    JavaScriptSerializer se = new JavaScriptSerializer();
                    string bod = se.Serialize(cA);
                    string result = insertAdmin.llamarServicio(bod);
                    MetroMessageBox.Show(this, "\n\n",
                   "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNombre.Text = "";
                    txtPw.Text = "";
                    txtPw2.Text = "";
                    txtUsuario.Text = "";
                    
                }
                else
                {
                    MetroMessageBox.Show(this, "\n\n \n¡Intente nuevamente!",
                    "Verifique su contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPw.Text = "";
                    txtPw2.Text = "";
                }
            }
            else
            {
                MetroMessageBox.Show(this, "\n\n\n¡Intente nuevamente!",
                    "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        validacion l = new validacion();
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            l.aceptarLetras(e);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
