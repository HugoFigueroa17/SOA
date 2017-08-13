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
using System.Collections;

namespace Paquetes
{
    public partial class Inicio : MetroForm
    {
        public Inicio()
        {
            InitializeComponent();
            timeActualizar.Interval = 30;
            timeActualizar.Tick += new EventHandler(timeActualizar_Tick);

        }
        public void timeActualizar_Tick(object sender, EventArgs e)//recibe ojbeto tipo sender
        {
            int count = 0;

            if (count < 5)
            {
                Servicio allMovi = new Servicio();
                VerMovimientos mov = new VerMovimientos();
                JavaScriptSerializer serm = new JavaScriptSerializer();
                string cXg = serm.Serialize(mov);

                string resG = allMovi.llamarServicio(cXg);

                var dato = serm.Deserialize<List<allMov>>(resG);
                dgvMovimientos.DataSource = null;
                dgvMovimientos.DataSource = dato;
            }
            else
            {
                count = 0;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            ocultarPanels();
            pInicio.Width = 591;
            pInicio.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pInicio.Location = p;
            pInicio.Visible = true;
        }

        private void pUr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        //Validar Resgistrar Usuario
        validacion checkUsuario = new validacion();

        private void txtNombreU_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkUsuario.aceptarLetras(e);
        }

        private void btnDireccionU_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkUsuario.aceptarLetras(e);
        }

        private void txtTelefonoU_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkUsuario.aceptarNumeros(e);
        }

        private void txtCorreoU_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkUsuario.aceptarLetras(e);
        }

        private void btnRegistrarU_Click(object sender, EventArgs e)
        {


        }

        private void btnRegistrarU_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnRegistrarU_MouseLeave(object sender, EventArgs e)
        {

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarPanels();

            pUv.Width = 591;
            pUv.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pUv.Location = p;
            pUv.Visible = true;
            Servicio cxGenero = new Servicio();
            rUsuario users = new rUsuario();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string cXg = ser.Serialize(users);

            string resG = cxGenero.llamarServicio(cXg);

            var datos = ser.Deserialize<List<allUsers>>(resG);

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = datos;

        }

        private void btnVerU_Click(object sender, EventArgs e)
        {

        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void ocultarPanels()
        {
            pUv.Visible = false;
            pVerMov.Visible = false;
            pRc.Visible = false;
            pC.Visible = false;
            pCe.Visible = false;
            pPg.Visible = false;
            pTodosp.Visible = false;
            pInicio.Visible = false;
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarPanels();
            pVerMov.Width = 591;
            pVerMov.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pVerMov.Location = p;
            pVerMov.Visible = true;
            Servicio allMovi = new Servicio();
            VerMovimientos mov = new VerMovimientos();
            JavaScriptSerializer serm = new JavaScriptSerializer();
            string cXg = serm.Serialize(mov);

            string resG = allMovi.llamarServicio(cXg);

            var dato = serm.Deserialize<List<allMov>>(resG);
            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = dato;

            timeActualizar.Start();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            btnRegistrarC.BackColor = Color.Green;
            btnRegistrarC.ForeColor = Color.Black;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 192, 0);
            btnRegistrarC.BackColor = color;
            btnRegistrarC.ForeColor = Color.White;
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarPanels();
            pRc.Width = 591;
            pRc.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pRc.Location = p;
            pRc.Visible = true;


        }

        private void btnRegistrarC_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string tel = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;

            if (nombre == "" || tel == "" || direccion == "" || email == "")
            {
                MetroMessageBox.Show(this, "\n\n\nFavor de llenar todos los campos \n¡Intente nuevamente!",
                    "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Servicio insertClient = new Servicio();
                cCliente cc = new cCliente(nombre, tel, direccion, email);
                JavaScriptSerializer se = new JavaScriptSerializer();
                string bod = se.Serialize(cc);
                string result = insertClient.llamarServicio(bod);


                MetroMessageBox.Show(this, "\n\n\n",
                    "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
                txtEmail.Text = "";

            }


        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ocultarPanels();
            Servicio r = new Servicio();
            rCliente rc = new rCliente();
            JavaScriptSerializer seri = new JavaScriptSerializer();

            string rcl = seri.Serialize(rc);
            string res = r.llamarServicio(rcl);
            var dato = seri.Deserialize<List<allClientes>>(res);
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = dato;

            pC.Width = 591;
            pC.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pC.Location = p;
            pC.Visible = true;

        }
        validacion txt = new validacion();
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt.aceptarLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt.aceptarNumeros(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        List<int> idsClientes;
        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ocultarPanels();

            cmbEliminar.Items.Clear();

            //Llenar combo box

            Servicio r = new Servicio();
            rCliente rc = new rCliente();
            JavaScriptSerializer seri = new JavaScriptSerializer();

            string rcl = seri.Serialize(rc);
            string res = r.llamarServicio(rcl);
            var dato = seri.Deserialize<List<allClientesId>>(res);

            cmbEliminar.Items.Add("Ver todos los clientes");
            idsClientes = new List<int>();
            idsClientes.Add(0);
            foreach (allClientesId c in dato)
            {
                //cmbEliminar.Items.Add(c.Nombre);
                cmbEliminar.Items.Add(c.Nombre);
                idsClientes.Add(c.idCliente);

            }



            //----------------------------


            pCe.Width = 591;
            pCe.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pCe.Location = p;
            pCe.Visible = true;
        }
        string a;
        private void cmbEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = cmbEliminar.SelectedItem.ToString();
            int c = cmbEliminar.SelectedIndex;
            

            if (a == "Ver todos los clientes")
            {
                Servicio r = new Servicio();
                rCliente rc = new rCliente();
                JavaScriptSerializer seri = new JavaScriptSerializer();

                string rcl = seri.Serialize(rc);
                string res = r.llamarServicio(rcl);
                var dato = seri.Deserialize<List<allClientes>>(res);

                dgvDeleteCliente.DataSource = null;

                dgvDeleteCliente.DataSource = dato;
            }
            else
            {
                
                Servicio r1 = new Servicio();
                
                    rClienteN rc1 = new rClienteN(a);
                    JavaScriptSerializer seri = new JavaScriptSerializer();

                    string rcl1 = seri.Serialize(rc1);
                    string res1 = r1.llamarServicio(rcl1);
                    var dato1 = seri.Deserialize<List<allClienteId>>(res1);
                    dgvDeleteCliente.DataSource = dato1;
                
               
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //Eliminar cliente
            if(a == "Ver todos los clientes")
            {
                Servicio r1 = new Servicio();
                dClienteAll rc1 = new dClienteAll();
                JavaScriptSerializer seri2 = new JavaScriptSerializer();

                string rcl1 = seri2.Serialize(rc1);
                string res1 = r1.llamarServicio(rcl1);
                var dato1 = seri2.Deserialize<List<dClientM>>(res1);
                //dgvDeleteCliente.DataSource = dato1;
                MetroMessageBox.Show(this, "\n\n\n",
                    "Información eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Servicio r1 = new Servicio();
                dCliente rc1 = new dCliente(a);
                JavaScriptSerializer seri1 = new JavaScriptSerializer();

                string rcl1 = seri1.Serialize(rc1);
                string res1 = r1.llamarServicio(rcl1);
                var dato1 = seri1.Deserialize<List<dClientM>>(res1);
                //dgvDeleteCliente.DataSource = dato1;
                MetroMessageBox.Show(this, "\n\n\n",
                    "Información eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            cmbEliminar.Items.Clear();
            dgvDeleteCliente.DataSource = null;
            dgvDeleteCliente.Rows.Clear();

            //Llenar combo box

            Servicio r = new Servicio();
            rCliente rc = new rCliente();
            JavaScriptSerializer seri = new JavaScriptSerializer();

            string rcl = seri.Serialize(rc);
            string res = r.llamarServicio(rcl);
            var dato = seri.Deserialize<List<allClientesId>>(res);

            cmbEliminar.Items.Add("Ver todos los clientes");
            idsClientes = new List<int>();
            idsClientes.Add(0);
            foreach (allClientesId c in dato)
            {
                //cmbEliminar.Items.Add(c.Nombre);
                cmbEliminar.Items.Add(c.Nombre);
                idsClientes.Add(c.idCliente);

            }
        }

        private void btnEliminarC_MouseEnter(object sender, EventArgs e)
        {
            btnEliminarC.BackColor = Color.Green;
            btnEliminarC.ForeColor = Color.Black;
        }

        private void btnEliminarC_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 192, 0);
            btnEliminarC.BackColor = color;
            btnEliminarC.ForeColor = Color.White;
        }
        Hashtable clientePedido;
        Hashtable repartidor;
        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarPanels();

            //
            Servicio r = new Servicio();
            rCliente rc = new rCliente();
            JavaScriptSerializer seri = new JavaScriptSerializer();

            string rcl = seri.Serialize(rc);
            string res = r.llamarServicio(rcl);
            var dato = seri.Deserialize<List<allClientesId>>(res);

            
            
            cbClient.Items.Clear();
            clientePedido = new Hashtable();
            foreach (allClientesId c in dato)
            {
                //cmbEliminar.Items.Add(c.Nombre);
                cbClient.Items.Add(c.Nombre);
                clientePedido.Add(c.Nombre, c.idCliente);
                

            }


            Servicio r1 = new Servicio();
            rUsuario leer = new rUsuario();
            JavaScriptSerializer seri1 = new JavaScriptSerializer();

            string rcl1 = seri1.Serialize(leer);
            string res1 = r1.llamarServicio(rcl1);
            var dato1 = seri1.Deserialize<List<allUserId>>(res1);


            
            cbRepartidor.Items.Clear();
            repartidor = new Hashtable();
            foreach (allUserId x in dato1)
            {
                //cmbEliminar.Items.Add(c.Nombre);
                cbRepartidor.Items.Add(x.Nombre);
                repartidor.Add(x.Nombre, x.idAdmin);
               
                

            }
            //



            pPg.Width = 591;
            pPg.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pPg.Location = p;
            pPg.Visible = true;
        }

        private void metroTile1_MouseEnter_1(object sender, EventArgs e)
        {

            btnGpedido.BackColor = Color.Green;
            btnGpedido.ForeColor = Color.Black;
        }

        private void btnGpedido_MouseLeave(object sender, EventArgs e)
        {
            var color = Color.FromArgb(0, 192, 0);
            btnGpedido.BackColor = color;
            btnGpedido.ForeColor = Color.White;

        }
        validacion p = new validacion();
        private void txtPinicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.aceptarLetras(e);
        }

        private void txtPdestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.aceptarLetras(e);

        }


        int idRepartidor;
        private void cbRepartidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string repartidorP = cbRepartidor.SelectedItem.ToString();
            int id = Convert.ToInt16(repartidor[repartidorP]);
            //MessageBox.Show(id +"  " + repartidorP);
            idRepartidor = id;
                 
        }
        int idCliente;
        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            string clienteP = cbClient.SelectedItem.ToString();
            int id = Convert.ToInt16(clientePedido[clienteP]);
            //MessageBox.Show(id +"  " + clienteP);
            idCliente = id;
        }

        private void btnGpedido_Click(object sender, EventArgs e)
        {
            string producto = txtPproducto.Text;
            string descripcion = txtPdescripcion.Text;
            string fecha1 = txtPfecha1.Text;
            string fecha2 = txtPfecha2.Text;
            int cliente = idCliente;
            string inicio = txtPinicio.Text;
            string destino = txtPdestino.Text;
            int repartidor = idRepartidor;

            if(producto == "" || descripcion == "" || fecha1 == "" || fecha2 == ""
                || inicio == "" || destino == "" || repartidor <0 || cliente < 0)
            {
                MetroMessageBox.Show(this, "\n\n\nFavor de llenar todos los campos \n¡Intente nuevamente!",
                   "Información incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Servicio insertp = new Servicio();
                cPedido pedido = new cPedido(producto, descripcion, fecha1, fecha2, inicio, destino, repartidor, cliente);
                JavaScriptSerializer sp = new JavaScriptSerializer();
                string bod = sp.Serialize(pedido);
                string result = insertp.llamarServicio(bod);


                MetroMessageBox.Show(this, "\n\n\n",
                    "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPproducto.Text = "";
                txtPdescripcion.Text = "";
                txtPfecha1.Text = "";
                txtPfecha2.Text = "";
                cbClient.Text = "Elige el cliente";
                txtPinicio.Text = "";
                txtPdestino.Text = "";
                cbRepartidor.Text = "Elige repartidor";

                
            }
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ocultarPanels();
            pTodosp.Width = 591;
            pTodosp.Height = 301;
            Point p = new Point();
            p.X = 58;
            p.Y = 125;
            pTodosp.Location = p;
            pTodosp.Visible = true;
            Servicio allMovi = new Servicio();
            verPedidos mov = new verPedidos();
            JavaScriptSerializer serm = new JavaScriptSerializer();
            string cXg = serm.Serialize(mov);

            string resG = allMovi.llamarServicio(cXg);

            var dato = serm.Deserialize<List<allPedidos>>(resG);
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = dato;

        }
    }
}
