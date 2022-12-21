using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EZBackups
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        public static FormConfig frmConfig = null;


        private void FormConfig_Load(object sender, EventArgs e)
        {
            try
            {
                cbNormativa.SelectedIndex = frmMain.frm_Main.Config.normativa;
                cbComprimir.Checked = frmMain.frm_Main.Config.comprimir;
                cbPregunta.Checked = frmMain.frm_Main.Config.preguntar;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(frmMain.frm_Main.Config.idioma);
                ActualizaTextos();
                edRuta.Text = frmMain.frm_Main.Config.ruta;
            }
            catch (Exception ex)
            {
                frmMain.frm_Main.Aviso("Error al cargar la antigua configuración.\nEsto no ha debido ocurrir. Porfavor revisa la ventana de configuración");
                ActualizaTextos();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            edRuta.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            ActualizaTextos();
        }

       

        private void ActualizaTextos()
        {
            cbComprimir.Text = Res.cbComprimir;
            cbPregunta.Text = Res.cbPregunta;
            edRuta.Text = Res.edRuta;
            lbEjemplo.Text = Res.lbEjemplo;
            lbNormativa.Text = Res.lbNormativa;
        }

        private void btnEsp_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
            ActualizaTextos();
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlDocument config = new XmlDocument();
            XmlElement raiz = config.CreateElement("Configuracion");
            config.AppendChild(raiz);
            XmlElement ruta = config.CreateElement("Ruta");
            ruta.AppendChild(config.CreateTextNode(edRuta.Text));
            raiz.AppendChild(ruta);
            XmlElement normativa = config.CreateElement("ID_Normativa");
            normativa.AppendChild(config.CreateTextNode(cbNormativa.SelectedIndex.ToString()));
            raiz.AppendChild(normativa);
            XmlElement comprimir = config.CreateElement("Comprimir");
            comprimir.AppendChild(config.CreateTextNode(cbComprimir.Checked.ToString()));
            raiz.AppendChild(comprimir);
            XmlElement pregunta = config.CreateElement("Preguntar");
            pregunta.AppendChild(config.CreateTextNode(cbPregunta.Checked.ToString()));
            raiz.AppendChild(pregunta);
            XmlElement idioma = config.CreateElement("Idioma");
            idioma.AppendChild(config.CreateTextNode(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString()));
            raiz.AppendChild(idioma);
            config.Save(Application.StartupPath + "\\config.xml");

            frmMain.frm_Main.Config.Actualizar();

            GC.Collect();
        }
    }
}
