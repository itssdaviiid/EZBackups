using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace EZBackups
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private Form formHijoActual;
        public Configuracion Config = new Configuracion();
        public static frmMain frm_Main = null;

        private void frmMain_Load(object sender, EventArgs e)
        {
            frm_Main = this;
            AbrirFormHijo(new FormInicio());
            try
            {
                Config.Actualizar();
            }
            catch(Exception ex)
            {
                Aviso("Error al cargar la antigua configuración.\nEsto no ha debido ocurrir. Porfavor revisa la ventana de configuración ");
            }
            
        }

        private void AbrirFormHijo(Form formHijo)
        {
            if(formHijoActual != null)
            {
            formHijoActual.Close();
            }  
            formHijoActual = formHijo;
            formHijoActual.TopLevel = false;
            formHijoActual.FormBorderStyle = FormBorderStyle.None;
            formHijoActual.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(formHijoActual);
            formHijoActual.BringToFront();
            formHijoActual.Show();
        }


        private void btnAjustes_Click(object sender, EventArgs e)
        {
            try
            {
                if (formHijoActual.Name.ToString() == "FormInicio")
                {
                    frm_Main = this;
                    AbrirFormHijo(new FormConfig());
                    btnAjustes.IconChar = FontAwesome.Sharp.IconChar.Home;
                }
                else
                {
                    frm_Main = this;
                    AbrirFormHijo(new FormInicio());
                    btnAjustes.IconChar = FontAwesome.Sharp.IconChar.Cogs;
                }
            }
            catch
            {
                Aviso("Error en la apertura del formulario.\nVuelva a intentarlo.");
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void Aviso(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FrmLogin_Desplazar(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }

    public class Configuracion
    {
        public string ruta;
        public int normativa;
        public bool comprimir;
        public bool preguntar;
        public string idioma;

        public void Actualizar()
        {
            XDocument xdoc = XDocument.Load(Application.StartupPath + "\\config.xml");
            var elementos = from dato in xdoc.Descendants() select dato;
            foreach (var dato in xdoc.Descendants("Configuracion"))
            {
                ruta = dato.Element("Ruta").Value;
                normativa = Convert.ToInt16(dato.Element("ID_Normativa").Value);
                comprimir = Convert.ToBoolean(dato.Element("Comprimir").Value);
                preguntar = Convert.ToBoolean(dato.Element("Preguntar").Value);
                idioma = dato.Element("Idioma").Value;
            }
        }
    }
}
